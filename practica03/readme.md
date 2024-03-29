# .NET - Practica 3


## Punto 1
***Ejecutar y analizar cuidadosamente el siguiente programa:***

~~~
Console.CursorVisible = false;              //a
ConsoleKeyInfo k = Console.ReadKey(true);   //b
while (k.Key != ConsoleKey.End)             //c
{
Console.Clear();
Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}");
k = Console.ReadKey(true);
}
~~~


(a) Con Console.CursorVisible establezco si el cursor es no o visible mediante true/false.

(b) En la variable k de tipo ConsoleKeyInfo se guardará que tecla presiono

(c) Entro en loop y evaluo que k.Key sea distinto de la tecla End. Dentro del loop:

* Console.Clear(); **-->** limpio la consola.
* Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}"); **-->** se muestran en pantalla los modificadores, el identificador de la tecla presionada, y el valor de la misma.
* k = Console.ReadKey(true); **-->** el programa espera a que se presione una nueva tecla. 


## Punto 2
***Implementar un método para imprimir por consola todos los elementos de una matriz (arreglo de dos dimensiones) pasada como parámetro. Debe imprimir todos los elementos de una fila en la misma línea en la consola. Ayuda: Si A es un arreglo, A.GetLength(i) devuelve la longitud del arreglo en la dimensión i.***


~~~
internal class Program
{
    private static void Main(string[] args)
    {
        double[,] matriz = new double[3, 3];
        for (int i = 0; i < 9; i++)
        {
            matriz[i / 3, i % 3] = i + 1;
        }
        ImprimirMatriz(matriz);

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
~~~


## Punto 3
***Implementar el método ImprimirMatrizConFormato, similar al anterior pero ahora con un
parámetro más que representa la plantilla de formato que debe aplicarse a los números al imprimirse. La plantilla de formato es un string de acuerdo a las convenciones de formato compuesto, por ejemplo “0.0” implica escribir los valores reales con un dígito para la parte decimal.***


~~~
internal class Program
{
    private static void Main(string[] args)
    {
        double[,] matriz = new double[3, 3];
        for (int i = 0; i < 9; i++)
        {
            matriz[i / 3, i % 3] = i + 1;
        }
        string formato = "0.0";
        ImprimirMatrizConFormato(matriz,formato);

        static void ImprimirMatrizConFormato(double[,] matriz, string formatString)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j].ToString(formatString),-7}");
                }
                Console.Write("\n");
            }
        }
    }
}
~~~


## Punto 4
***Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que devuelven un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la matriz no es cuadrada generar una excepción ArgumentException.***

~~~
internal class Program
{
    private static void Main(string[] args)
    {
        int f = int.Parse(args[0]);
        int c = int.Parse(args[1]);
        //Cargo la matriz
        double[,] matriz = new double[f,c]; 
        int aux=1;
        for (int i=0;i<f;i++)
        {
            for (int j=0;j<c;j++)
            {
                matriz[i,j]= aux;
                aux++;
            }
        }

        //Muestro la matriz
        for (int i = 0; i < f; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.Write($"{matriz[i,j],-5}");
            }
            Console.Write("\n");
        }

        try
        {
            double[] vecPrinc = GetDiagonalPrincipal(matriz);
            double[] vecSec = GetDiagonalSecundaria(matriz);
        }
        catch
        {
            throw new ArgumentException("La matriz no es cuadrada");
        }

        static double[] GetDiagonalPrincipal(double[,] matriz)
        {
            EsCuadrada(matriz.GetLength(0), matriz.GetLength(1));
            double[] vecPrinc = new double[matriz.GetLength(0)];
            for (int i=0;i<matriz.GetLength(0);i++)
            {
                vecPrinc[i] = matriz[i,i];
            }
            return vecPrinc;
        }

        static double[] GetDiagonalSecundaria(double[,] matriz)
        {
            EsCuadrada(matriz.GetLength(0), matriz.GetLength(1));
            double[] vecSec = new double[matriz.GetLength(0)];
            for (int i = matriz.GetLength(0)-1; i>=0; i++)
            {
                vecSec[i] = matriz[i, i];
            }
            return vecSec;
        }

        static void EsCuadrada(int f,int c)
        {
            if (f!=c)
            {
                throw new ArgumentException("La matriz no es cuadrada");
            }
            return;
        }
    }
}
~~~


## Punto5
***Implementar un método que devuelva un arreglo de arreglos con los mismos elementos que la matriz pasada como parámetro:***

