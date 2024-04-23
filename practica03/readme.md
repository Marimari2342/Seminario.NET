# .NET - Practica 3


## 🟢 Punto 1
***Ejecutar y analizar cuidadosamente el siguiente programa:***

~~~c#
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


## 🟢 Punto 2
***Implementar un método para imprimir por consola todos los elementos de una matriz (arreglo de dos dimensiones) pasada como parámetro. Debe imprimir todos los elementos de una fila en la misma línea en la consola. Ayuda: Si A es un arreglo, A.GetLength(i) devuelve la longitud del arreglo en la dimensión i.***


~~~c#
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


## 🟢 Punto 3
***Implementar el método ImprimirMatrizConFormato, similar al anterior pero ahora con un
parámetro más que representa la plantilla de formato que debe aplicarse a los números al imprimirse. La plantilla de formato es un string de acuerdo a las convenciones de formato compuesto, por ejemplo “0.0” implica escribir los valores reales con un dígito para la parte decimal.***


~~~c#
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


## 🟢 Punto 4
***Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que devuelven un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la matriz no es cuadrada generar una excepción ArgumentException.***

~~~c#
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


## 🟢 Punto 5
***Implementar un método que devuelva un arreglo de arreglos con los mismos elementos que la matriz pasada como parámetro:***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        //Declaro y cargo la matriz
        double[,] matriz = new double[3, 3];
        for (int i = 0; i < 9; i++)
        {
            matriz[i / 3, i % 3] = i + 1;
        }

        //Mostrar Matriz en pantalla
        ImprimirMatriz(matriz);

        //Llamo al método que devuelva un arreglo de arreglos (y lo imprima)
        ImprimirArreglos(GetArregloDeArreglo(matriz));


        static double[][] GetArregloDeArreglo(double[,] matriz)
        {
            int a = matriz.GetLength(0);
            int b = matriz.GetLength(1);
            double[][] arreglo = new double[b][];
            for (int i = 0; i < a; i++)
            {
                arreglo[i] = new double[a];
                for (int j = 0; j < b; j++)
                {
                    arreglo[i][j] = matriz[i, j];
                }
            }
            return arreglo;
        }

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],-5}");
                }
                Console.Write("\n");
            }
        }

        static void ImprimirArreglos(double[][] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.WriteLine("Arreglo {0} :", i+1);
                for (int j = 0; j < arreglo[i].Length; j++)
                {
                    Console.Write($"{arreglo[i][j],-5}");
                }
                Console.Write("\n");
            }
        }
    }
}
~~~


## 🟢 Punto 6
***Implementar los siguientes métodos que devuelvan la suma, resta y multiplicación de matrices pasadas como parámetros. Para el caso de la suma y la resta, las matrices deben ser del mismo tamaño, en caso de no serlo devolver null. Para el caso de la multiplicación la cantidad de columnas de A debe ser igual a la cantidad de filas de B, en caso contrario generar una excepción ArgumentException.***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int f = int.Parse(args[0]);
        int c = int.Parse(args[1]);
        int f2 = int.Parse(args[2]);
        int c2 = int.Parse(args[3]);

        //Crear matriz
        double[,] matriz1 = CrearMatriz(f, c);
        double[,] matriz2 = CrearMatriz(f2, c2);

        //Mostrar matriz
        MostrarMatriz(matriz1, "1");
        MostrarMatriz(matriz2, "2");

        double[,] suma = Suma(matriz1, matriz2);
        double[,] resta = Resta(matriz1, matriz2);
        if (suma != null && resta != null)
        {
            MostrarMatriz(suma, "Suma");
            MostrarMatriz(resta, "Resta");
        }
        else
        {
            Console.WriteLine("No puedo calcular Suma y Resta de matrices que no tienen el mismo tamaño.");
        }

        MostrarMatriz(Multiplicacion(matriz1, matriz2), "Producto");


        //METODOS
        static double[,] CrearMatriz(int f, int c)
        {
            double[,] matriz = new double[f, c];
            for (int i = 0; i < f * c; i++)
            {
                matriz[i / c, i % c] = i + 1;
            }
            return matriz;
        }

        static void MostrarMatriz(double[,] matriz, string dato)
        {
            Console.WriteLine("Matriz {0} :", dato);
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],-5}");
                }
                Console.Write("\n");
            }
        }

        //Metodo SUMA
        double[,]? Suma(double[,] A, double[,] B)
        {
            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                double[,] suma = new double[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        suma[i, j] = A[i, j] + B[i, j];
                    }
                }
                return suma;
            }
            else
            {
                return null;
            }
        }

        //Metodo RESTA
        double[,]? Resta(double[,] A, double[,] B)
        {
            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                double[,] resta = new double[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        resta[i, j] = A[i, j] - B[i, j];
                    }
                }
                return resta;
            }
            else
            {
                return null;
            }
        }

        //Metodo PRODUCTO
        double[,] Multiplicacion(double[,] A, double[,] B)
        {
            CompararFilasColumnas(A.GetLength(1), B.GetLength(0));
            double[,] mul = new double[A.GetLength(0), B.GetLength(1)];
            double suma;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    suma=0;
                    for (int k=0;k<B.GetLength(0);k++)
                    {
                        suma+=A[i,k]*B[k,j];
                    }
                    mul[i, j] = suma;
                }
            }
            return mul;
        }

        //Metodo ArgumentException
        static void CompararFilasColumnas(int a, int b)
        {
            if (a != b)
            {
                throw new ArgumentException("La cantidad de columnas de la matriz 1 es distinto a la cantidad de filas de la matriz 2");
            }
        }
    }
}
~~~


## 🟢 Punto 7
***¿De qué tipo quedan definidas las variables x, y, z en el siguiente código?***


~~~c#
int i = 10;
var x = i * 1.0;
var y = 1f;
var z = i * y;

Console.WriteLine("i: {0}",i.GetType());      //i: System.Int32
Console.WriteLine("x: {0}",x.GetType());      //x: System.Double (int*double=double)
Console.WriteLine("y: {0}", y.GetType());     //y: System.Single (float)
Console.WriteLine("z: {0}", z.GetType());     //z: System.Single (double*float=float)
~~~


## 🟢 Punto 8
***Señalar errores de compilación y/o ejecución en el siguiente código***


~~~c#
object obj = new int[10];
dynamic dyna = 13;
Console.WriteLine(obj.Length);
Console.WriteLine(dyna.Length);
~~~

* Errores de Compilación

obj.Length--> El tipo object no tiene una definición para "Length" ni un método de
extensión accesible "Length" que acepte un primer argumento del tipo object.

* Errores de Ejecución

dyna.Length--> El tipo int no tiene una definición para "Length" ni un método "Length"
definido, pero como la variable dyna fue definida como dynamic, el error no salta en 
la compilación, sino en la ejecución.


## 🟢 Punto 9
***¿Qué líneas del siguiente método provocan error de compilación y por qué?***


~~~c#
var a = 3L;
dynamic b = 32;
object obj = 3;
a = a * 2.0;                                        //ERROR
b = b * 2.0;
b = "hola";
obj = b;
b = b + 11;
obj = obj + 11;                                     //ERROR
var c = new { Nombre = "Juan" };
var d = new { Nombre = "María" };
var e = new { Nombre = "Maria", Edad = 20 };
var f = new { Edad = 20, Nombre = "Maria" };
f.Edad = 22;                                        //ERROR
d = c;
e = d;                                              //ERROR
f = e;                                              //ERROR
~~~

* a = a * 2.0; --> No puedo convertir implícitamente un tipo double en un tipo long.
* obj = obj + 11; --> El operador + no se puede aplicar a operandos del tipo object e int.
* f.Edad = 22; --> El indizador es de sólo lectura, no puedo asignarle un valor.
* e = d; --> No puedo convertir implicitamente el tipo <anonymous type: string Nombre> en <anonymous type: string Nombre, int Edad>.
* f = e; --> No puedo convertir implicitamente el tipo <anonymous type: string Nombre, int Edad> en <anonymous type: int Edad, string Nombre>.


## 🟢 Punto 10
***Verificar con un par de ejemplos si la sección opcional [:formatString] de formatos compuestos redondea o trunca cuando se formatean números reales restringiendo la cantidad de decimales. Plantear los ejemplos con cadenas de formato compuesto y con cadenas interpoladas.***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        double num = 3.12569;
        Console.WriteLine("Mi numero es {0}",num);

        Console.WriteLine($"Numero: {num:0.0}");         //Numero: 3,1
        Console.WriteLine("Numero: {0:0.0}",num);
        Console.WriteLine($"Numero: {num:0.00}");        //Numero: 3,13
        Console.WriteLine("Numero: {0:0.00}",num);
        Console.WriteLine($"Numero: {num:0.000}");       //Numero: 3,126
        Console.WriteLine("Numero: {0:0.000}",num);
    }
}
~~~

En el ejemplo notamos que al darle formato al número, este no se trunca, sino que redondea para arriba en el caso de que el decimal siguiente sea mayor o igual a 5, o para abajo en caso contrario. Tanto en los ejemplos con cadenas de formato compuesto como en los ejemplos con cadenas interpoladas, el redondeo sucede de igual modo.


## 🟢 Punto 11
***Señalar errores de ejecución en el siguiente código***


~~~c#
List<int> a = [ 1, 2, 3, 4 ];
a.Remove(5);
a.RemoveAt(4);
~~~

* a.Remove(5); --> Remueve el número indicado de la lista, como el 5 no está en la lista se genera un error.

* a.RemoveAt(4); --> Remueve el elemento de la lista ubicado en la posición indicada, la primer posición es 0, por lo tanto en una lista de 4 elementos, la última posición es 3, entonces como la posición 4 no está en la lista se genera un error.


## 🟢 Punto 12
***Realizar un análisis sintáctico para determinar si los paréntesis en una expresión aritmética están bien balanceados. Verificar que por cada paréntesis de apertura exista uno de cierre en la cadena de entrada. Utilizar una pila para resolverlo. Los paréntesis de apertura de la entrada se almacenan en una pila hasta encontrar uno de cierre, realizándose entonces la extracción del último paréntesis de apertura almacenado. Si durante el proceso se lee un paréntesis de cierre y la pila está vacía, entonces la cadena es incorrecta. Al finalizar el análisis, la pila debe quedar vacía para que la cadena leída sea aceptada, de lo contrario la misma no es válida.***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese texto a analizar: ");
        string? txt = Console.ReadLine();

        if (txt != null)
        {
            try
            {
                //Convierto string en un vector de char
                char[] arr;
                arr = txt.ToCharArray(0, txt.Length);

                Stack<char> pila = new Stack<char>();
                
                for (int i = 0; i < txt.Length; i++)
                {
                    if(arr[i]=='(')
                    {
                        pila.Push(arr[i]);
                    }
                    else if (arr[i]==')' && pila.Count>0)
                    {
                        pila.Pop();
                    }
                    else if (arr[i] == ')' && pila.Count == 0)
                    {
                        throw new ArgumentException("Cadena incorrecta.");
                    }
                }
                if (pila.Count != 0)
                {
                    throw new ArgumentException("Cadena incorrecta.");
                }
                else 
                {
                    Console.WriteLine("Cadena balanceada.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
~~~


## 🟢 Punto 13
***Utilizar la clase Stack<T> (pila) para implementar un programa que pase un número en base 10 a otra base realizando divisiones sucesivas. Por ejemplo para pasar 35 en base 10 a binario dividimos sucesivamente por dos hasta encontrar un cociente menor que el divisor, luego el resultado se obtiene leyendo de abajo hacia arriba el cociente de la última división seguida por todos los restos.***


~~~c#
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int numD = int.Parse(args[0]);
        try
        {
            Stack<int> pila = new Stack<int>();
            int aux;
            while (numD != 0)
            {
                aux = numD % 2;
                numD = numD / 2;
                pila.Push(aux);
            }
            StringBuilder bin = new StringBuilder();
            while (pila.Count > 0)
            {
                bin.Append(pila.Pop());
            }
            Console.WriteLine("El numero decimal {0} es {1} en binario.",args[0],bin);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
~~~


## 🟢 Punto 14
***Utilizar la clase Queue<T> para implementar un programa que realice el cifrado de un texto aplicando la técnica de clave repetitiva. La técnica de clave repetitiva consiste en desplazar un carácter una cantidad constante de acuerdo a la lista de valores que se encuentra en la clave. Por ejemplo: para la siguiente tabla de caracteres:***

![Imagen1](/../main/recursos/imagen4.png)

***Si la clave es 5,3,9,7 y el mensaje a cifrar es “HOLA MUNDO”, se cifra de la siguiente manera:***

![Imagen1](/../main/recursos/imagen3.png)

***A cada carácter del mensaje original se le suma la cantidad indicada en la clave. En el caso que la suma fuese mayor que 28 se debe volver a contar desde el principio, Implementar una cola con los números de la clave encolados y a medida que se desencolen para utilizarlos en el cifrado, se vuelvan a encolar para su posterior utilización. Programar un método para cifrar y otro para descifrar.***

~~~c#
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese frase a cifrar: ");
        string? txt = Console.ReadLine();
        if (txt != null)
        {
            txt = txt.ToUpper(); //Paso a Mayus
            //Console.WriteLine(txt);

            int[] clave = { 5, 3, 9, 7 };
            //Declaro el queue y le guardo el codigo
            Queue<int> codigo;
            codigo = CargarQueue(clave);

            StringBuilder txtCifr = Cifrar(txt, codigo);
            Console.WriteLine("Texto cifrado: {0}.", txtCifr);
            string code = txtCifr.ToString();
            codigo = CargarQueue(clave);
            StringBuilder txtDescif = Descifrar(code, codigo);
            Console.WriteLine("Texto descifrado {0}.", txtDescif);
        }


        //METODOS

        static Queue <int> CargarQueue(int [] clave)
        {
            Queue <int> codigo = new Queue <int> ();
            for (int i = 0; i < clave.Length; i++)
            {
                codigo.Enqueue(clave[i]);
            }
            return codigo;
        }
        

        static StringBuilder Cifrar(string txt, Queue<int> q)
        {
            StringBuilder txtCod = new StringBuilder();
            char[] txtSinCifrar = txt.ToCharArray();
            char[] txtCifrado = new char[txt.Length];
            int cod;
            int num;
            int numCod;
            for (int i = 0; i < txt.Length; i++)
            {
                cod = q.Dequeue();
                num = txtSinCifrar[i];
                //Console.WriteLine("cod: {0}, num: {1}", cod, num);
                numCod = Decod(cod, num,"Cifrar");
                //Console.WriteLine("numCod: {0}", numCod);
                txtCifrado[i] = Cod(numCod);
                txtCod.Append(txtCifrado[i]);
                q.Enqueue(cod);
            }
            return txtCod;
        }

        static StringBuilder Descifrar(string txt, Queue<int> q)
        {
            StringBuilder txtCod = new StringBuilder();
            char[] txtCifrado = txt.ToCharArray();
            char[] txtDescifrado = new char[txt.Length];
            int cod;
            int num;
            int numCod;
            for (int i = 0; i < txt.Length; i++)
            {
                cod = q.Dequeue();
                num = txtCifrado[i];
                //Console.WriteLine("cod: {0}, num: {1}", cod, num);
                numCod = Decod(cod, num,"Descifrar");
                //Console.WriteLine("numCod: {0}", numCod);
                txtDescifrado[i] = Cod(numCod);
                txtCod.Append(txtDescifrado[i]);
                q.Enqueue(cod);
            }
            return txtCod;
        }

        static int Decod(int cod, int num,string op)
        {
            int aux;
            if (num >= 65 && num < 79)
            {
                num = num - 64;
            }
            else if (num >= 79 && num <= 90)
            {
                num = num - 63;
            }
            else if (num == (int)'Ñ')
            {
                num = 15;
            }
            else if (num == (int)' ')
            {
                num = 28;
            }

            if (op== "Cifrar")
            {
                aux = cod + num;
            }
            else
            {
                aux = num - cod;
            }
            return aux;
        }

        static char Cod(int num)
        {
            if (num > 28)
            {
                num = num - 28;
            }
            else if (num <=0 )
            {
                num = num + 28;
            }
            if (num == 15)
            {
                return 'Ñ';
            }
            else if (num >= 1 && num < 15)
            {
                return (char)(num + 64);
            }
            else if (num >= 15 && num <= 27)
            {
                return (char)(num + 63);
            }
            else
            {
                return ' ';
            }
        }
    }
}

~~~


## 🟢 Punto 15
***¿Qué salida por la consola produce el siguiente código? ¿Qué se puede inferir respecto de la excepción división por cero en relación al tipo de los operandos?***


~~~c#
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

Salida por consola: **Attempted to divide by zero.** Esto se debe a que no se puede dividir por cero. Además, hay que tener en cuenta que la linea que produce una excepción es *Console.WriteLine(1 / x);*, en donde divido un entero por cero. En el caso de la primer linea, *Console.WriteLine(1.0 / x);* divido un double por cero y en ese caso devuelve infinito (es como si tomara límite cuando el denominador tiende a cero y el numerador es un real).

## 🟢 Punto 16
***Implementar un programa que permita al usuario ingresar números por la consola. Debe ingresarse un número por línea, finalizando el proceso cuando el usuario ingresa una línea vacía. A medida que se van ingresando los valores el sistema debe mostrar por la consola la suma acumulada de los mismos. Utilizar double.Parse() y try/catch para validar que la entrada ingresada sea un número válido, en caso contrario advertir con un mensaje al usuario y proseguir con el ingreso de datos.***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        string dato = "ok";
        double num = 0;
        while (dato != "")
        {
            try
            {
                Console.WriteLine("Ingrese un numero");
                dato = Console.ReadLine();
                if (dato != "")
                {
                    num = num + double.Parse(dato);
                    Console.WriteLine("Suma acumulada {0}", num);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
~~~


## 🟢 Punto 17
***Cuál es la salida por consola del siguiente programa:***


~~~c#
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

Salida por consola del siguiente programa:

![ImagenPantalla](/../main/recursos/imagen5.png)

* Bloque finally en Metodo1: en el Método 1 se produce una excepción por querer castear un string como si fuera int. Como este método no posee un manejador catch, se produce primero el finally dentro del método.
* Método 1 propagó una excepción no tratada: Esta es la propagación del error del punto anterior siendo manejada por el catch dentro del Main.
* Método 2 propagó una excepción no tratada: El Método 2 realiza la misma acción que desencadena en una excepción, a diferencia del Metodo 1 este tiene un manejador catch, pero el mismo esta destinado a tratar con excepciones tipo OverflowException. Por lo tanto, la excepción será manejada en el catch correspondiente en el Main.
* Excepción InvalidCast en Metodo3: El Método 3 si posee un catch especializado en la excepción InvalidCastException**.
* Método 3 propagó una excepción: Dentro del manejador catch en el método 3, hay una propagación (throw) que lo envía a ser manejado por el método que lo llamó. En este caso, se ve en el catch correspondiente del método Main.

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>