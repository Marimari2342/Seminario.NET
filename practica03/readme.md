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
        double[,] matriz = new double[f, c];
        int aux = 1;
        for (int i = 0; i < f; i++)
        {
            for (int j = 0; j < c; j++)
            {
                matriz[i, j] = aux;
                aux++;
            }
        }

        //Muestro la matriz
        for (int i = 0; i < f; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.Write($"{matriz[i, j],-5}");
            }
            Console.Write("\n");
        }

        try
        {
            Mostrar(GetDiagonalPrincipal(matriz), "Diagonal Principal");
            Mostrar(GetDiagonalSecundaria(matriz), "Diagonal Secundaria");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        static double[] GetDiagonalPrincipal(double[,] matriz)
        {
            EsCuadrada(matriz.GetLength(0), matriz.GetLength(1));
            double[] vecPrinc = new double[matriz.GetLength(0)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                vecPrinc[i] = matriz[i, i];
            }
            return vecPrinc;
        }

        static double[] GetDiagonalSecundaria(double[,] matriz)
        {
            EsCuadrada(matriz.GetLength(0), matriz.GetLength(1));
            double[] vecSec = new double[matriz.GetLength(0)];
            for (int i = 0;i<matriz.GetLength(0); i++)
            {
                vecSec[i] = matriz[i, matriz.GetLength(0)-i-1];
            }
            return vecSec;
        }

        static void Mostrar(double []diagonal,string st)
        {
            Console.WriteLine(st);
            for (int i=0;i<diagonal.Length;i++)
            {
                Console.Write($"{diagonal[i],5}");
            }
            Console.WriteLine("\n");
        }
        
        static void EsCuadrada(int f, int c)
        {
            if (f != c)
            {
                throw new Exception("La matriz NO es cuadrada");
            }
            return;
        }
    }
}
~~~


## Punto5
***Implementar un método que devuelva un arreglo de arreglos con los mismos elementos que la matriz pasada como parámetro:***


~~~
double[][] GetArregloDeArreglo(double [,] matriz)
~~~


## Punto6
***Implementar los siguientes métodos que devuelvan la suma, resta y multiplicación de matrices pasadas como parámetros. Para el caso de la suma y la resta, las matrices deben ser del mismo tamaño, en caso de no serlo devolver null. Para el caso de la multiplicación la cantidad de columnas de A debe ser igual a la cantidad de filas de B, en caso contrario generar una excepción ArgumentException.***


~~~
double[,]? Suma(double[,] A, double[,] B)
double[,]? Resta(double[,] A, double[,] B)
double[,] Multiplicacion(double[,] A, double[,] B)
~~~


## Punto7
***¿De qué tipo quedan definidas las variables x, y, z en el siguiente código?***


~~~
int i = 10;
var x = i * 1.0;
var y = 1f;
var z = i * y;
~~~


## Punto8
***Señalar errores de compilación y/o ejecución en el siguiente código***


~~~
object obj = new int[10];
dynamic dyna = 13;
Console.WriteLine(obj.Length);
Console.WriteLine(dyna.Length);
~~~


## Punto9
***¿Qué líneas del siguiente método provocan error de compilación y por qué?***


~~~
var a = 3L;
dynamic b = 32;
object obj = 3;
a = a * 2.0;
b = b * 2.0;
b = "hola";
obj = b;
b = b + 11;
obj = obj + 11;
var c = new { Nombre = "Juan" };
var d = new { Nombre = "María" };
var e = new { Nombre = "Maria", Edad = 20 };
var f = new { Edad = 20, Nombre = "Maria" };
f.Edad = 22;
d = c;
e = d;
f = e;
~~~


## Punto10
***Verificar con un par de ejemplos si la sección opcional [:formatString] de formatos compuestos redondea o trunca cuando se formatean números reales restringiendo la cantidad de decimales. Plantear los ejemplos con cadenas de formato compuesto y con cadenas interpoladas.***


~~~

~~~


## Punto11
***Señalar errores de ejecución en el siguiente código***


~~~
List<int> a = [ 1, 2, 3, 4 ];
a.Remove(5);
a.RemoveAt(4);
~~~


## Punto12
***Realizar un análisis sintáctico para determinar si los paréntesis en una expresión aritmética están bien balanceados. Verificar que por cada paréntesis de apertura exista uno de cierre en la cadena de entrada. Utilizar una pila para resolverlo. Los paréntesis de apertura de la entrada se almacenan en una pila hasta encontrar uno de cierre, realizándose entonces la extracción del último paréntesis de apertura almacenado. Si durante el proceso se lee un paréntesis de cierre y la pila está vacía, entonces la cadena es incorrecta. Al finalizar el análisis, la pila debe quedar vacía para que la cadena leída sea aceptada, de lo contrario la misma no es válida.***


~~~

~~~


## Punto13
***Utilizar la clase Stack<T> (pila) para implementar un programa que pase un número en base 10 a otra base realizando divisiones sucesivas. Por ejemplo para pasar 35 en base 10 a binario dividimos sucesivamente por dos hasta encontrar un cociente menor que el divisor, luego el resultado se obtiene leyendo de abajo hacia arriba el cociente de la última división seguida por todos los restos.***


~~~

~~~


## Punto14
***Utilizar la clase Queue<T> para implementar un programa que realice el cifrado de un texto aplicando la técnica de clave repetitiva. La técnica de clave repetitiva consiste en desplazar un carácter una cantidad constante de acuerdo a la lista de valores que se encuentra en la clave. Por ejemplo: para la siguiente tabla de caracteres:***

![Imagen1](/../main/recursos/imagen3.png)

***Si la clave es 5,3,9,7 y el mensaje a cifrar es “HOLA MUNDO”, se cifra de la siguiente manera:***

![Imagen1](/../main/recursos/imagen4.png)

***A cada carácter del mensaje original se le suma la cantidad indicada en la clave. En el caso que la suma fuese mayor que 28 se debe volver a contar desde el principio, Implementar una cola con los números de la clave encolados y a medida que se desencolen para utilizarlos en el cifrado, se vuelvan a encolar para su posterior utilización. Programar un método para cifrar y otro para descifrar.***


~~~

~~~


## Punto15
***¿Qué salida por la consola produce el siguiente código? ¿Qué se puede inferir respecto de la excepción división por cero en relación al tipo de los operandos?***


~~~
int x = 0;
try
{
    Console.WriteLine(1.0 / x);
    Console.WriteLine(1 / x);
    Console.WriteLine("todo OK");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
~~~


## Punto16
***Implementar un programa que permita al usuario ingresar números por la consola. Debe ingresarse un número por línea finalizado el proceso cuando el usuario ingresa una línea vacía. A medida que se van ingresando los valores el sistema debe mostrar por la consola la suma acumulada de los mismos. Utilizar double.Parse() y try/catch para validar que la entrada ingresada sea un número válido, en caso contrario advertir con un mensaje al usuario y proseguir con el ingreso de datos.***


~~~

~~~


## Punto17
***Cuál es la salida por consola del siguiente programa:***


~~~
try
{
    Metodo1();
}
catch
{
    Console.WriteLine("Método 1 propagó una excepción no tratada");
}
try
{
    Metodo2();
}
catch
{
    Console.WriteLine("Método 2 propagó una excepción no tratada");
}
try
{
    Metodo3();
}
catch
{
    Console.WriteLine("Método 3 propagó una excepción");
}

void Metodo1()
{
    object obj = "hola";
    try
    {
        int i = (int)obj;
    }
    finally
    {
        Console.WriteLine("Bloque finally en Metodo1");
    }
}

void Metodo2()
{
    object obj = "hola";
    try
    {
        int i = (int)obj;
    }
    catch (OverflowException)
    {
        Console.WriteLine("Overflow");
    }
}

void Metodo3()
{
    object obj = "hola";
    try
    {
        int i = (int)obj;
    }
    catch (InvalidCastException)
    {
        Console.WriteLine("Excepción InvalidCast en Metodo3");
        throw;
    }
}
~~~

