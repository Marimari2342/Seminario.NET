# Práctica 2


## 🟠 Punto 1
***Dado el siguiente código: El tipo object es un tipo referencia, por lo tanto luego de la sentencia o2 = o1 ambas variables están apuntando a la misma dirección. ¿Cómo explica entonces que el resultado en la consola no sea “Z Z”?***

~~~c#
object o1 = "A";

object o2 = o1;

o2 = "Z";

Console.WriteLine(o1 + " " + o2);
~~~
Esto es porque son dos objetos distintos tengo:
~~~c#
object o1 = "A";    o1 --> A
                    o2 --> ?

object o2 = o1;     o1 --> A
                    o2 --> A

o2 = "Z";           o1 --> A
                    o2 --> Z
~~~


## 🟠 Punto 2
***¿Qué líneas del siguiente código provocan conversiones boxing y unboxing?***


Las conversiones boxing y unboxing permiten asignar variables de tipo de valor a variables de tipo de referencia y viceversa.
* Cuando una variable de algun tipo de valor se asigna a una de tipo de referencia, se dice que se le aplicó la conversión **BOXING**.
* Cuando una variable de algun tipo de referencia se asigna a una de tipo de valor, se dice que se le aplicó la conversión **UNBOXING**.
~~~c#
char c1 = 'A';

string st1 = "A";

object o1 = c1; // o1(referencia) <-- c1(valor) == BOXING

object o2 = st1; // o2(referencia) <-- st1(valor) == BOXING

char c2 = (char)o1; // c2(valor) <-- o1(referencia) == UNBOXING

string st2 = (string)o2; // st2(valor) <-- o2(referencia) == UNBOXING
~~~


## 🟠 Punto 3
***¿Qué diferencias existen entre las conversiones de tipo implícitas y explícitas?***


* **Conversiones implícitas:** son aquellas en las que no hace falta indicar entre paréntesis la conversion. Ejemplo --> double num = 10;
* **Conversiones explicitas:** tengo que indicar entre paréntesis el tipo de dato al que quiero convertir. Ejemplo --> int num = (int) 10.0; Si no aclaro entre paréntesis el tipo de conversion me va a tirar error.


## 🟠 Punto 4
***Resolver los errores de compilación en el siguiente fragmento de código. Utilizar el operador as cuando sea posible.***


~~~c#
object o = "Hola Mundo!";
string? st = o as string; //string acepta valores null entonces puedo usar as

int i = 12;
byte b = (byte)i; //no puedo usar as porque byte no acepta valores null

double d = i;
float f = (float)d; //no puedo usar as porque float no acepta valores null

o = i;
i = (int) o+ 1; //no puedo usar as porque int no acepta valores null
~~~


## 🟠 Punto 6
***Supongamos que Program.cs sólo tiene dos líneas ¿Por qué no compila?***


~~~c#
int i;

Console.WriteLine(i);
~~~

Porque no le asigno ningún valor a la variable i, entonces no puedo imprimirla en pantalla.


## 🟠 Punto 7
***¿Cuál es la salida por consola del siguiente fragmento de código? ¿Por qué la tercera y sexta línea producen resultados diferentes?***


~~~c#
char c1 = 'A';

char c2 = 'A';

Console.WriteLine(c1 == c2); //Aca comparo dos char y sin iguales porque A==A

object o1 = c1;

object o2 = c2;

Console.WriteLine(o1 == o2);    /*Aca comparo dos objetos y son distintos porque o1 no 
                                es o2, el contenido en ambos es el mismo pero son dos
                                objetos diferentes*/
~~~
La salida por consola será true - false, pues en el primer caso compara dos char que son iguales, y en el segundo caso compara dos objetos, que aunque ambos tengan el mismo contenido, no dejan de ser dos objetos distintos.


## 🟠 Punto 8
***Investigar acerca de la clase StringBuilder del espacio de nombre System.Text ¿En qué circunstancias es preferible utilizar StringBuilder en lugar de utilizar string? Implementar un caso de ejemplo en el que el rendimiento sea claramente superior utilizando StringBuilder en lugar de string y otro en el que no.***


El objeto String es inmutable. Cada vez que se usa uno de los métodos de la clase System.String, se crea un objeto de cadena en la memoria, lo que requiere una nueva asignación de espacio para ese objeto. En las situaciones en las que es necesario realizar modificaciones repetidas en una cadena, la sobrecarga asociada a la creación de un objeto String puede ser costosa. 

La clase **System.Text.StringBuilder** se puede usar para modificar una cadena sin crear un objeto. Por ejemplo, el uso de la clase StringBuilder puede mejorar el rendimiento al concatenar muchas cadenas en un bucle.

**Debo usar String:**
* Cuando la cantidad de cambios que su aplicación realizará en una cadena es pequeña.
* Cuando está realizando un número fijo de operaciones de concatenación. 
* Cuando se realizan operaciones de búsqueda extensas al construir la cadena.

~~~c#
string nombre = "Hola soy Juanita";

Console.WriteLine(nombre);
~~~

**Debo usar StringBuilder:**
* Cuando espera que su aplicación realice un número desconocido o una cantidad significativa de cambios en una cadena.

~~~c#
using System.Text; //StringBuilder esta definido en el espacio System.Text, por eso escribo esto.

StringBuilder num = new StringBuilder("Los numeros del 1 al 1000 son: ");
for (int i = 1; i < 1000; i++)
{
    num.Append(i.ToString());
}
Console.WriteLine(num);
~~~


## 🟠 Punto 9
***Investigar sobre el tipo DateTime y usarlo para medir el tiempo de ejecución de los algoritmos implementados en el ejercicio anterior.***


EL tipo **DateTime** nos permite trabajar con tiempos estandarizados. Podemos definir valores pasados, futuros o recibir la información actual. Podemos utilizar distintos formatos predefinidos o definir el nuestro propio.

Para poder medir el tiempo de ejecución con DateTime, debemos establecer dos variables, una al inicio de la suseción de lineas, y una al final del código a testear; luego realizamos la resta de ambas y exponemos la diferencia.

Primer caso: conviene usar string.
~~~c#
//using System.Text;

DateTime start = DateTime.Now;
string nombre = "Hola soy Juanita";
//StringBuilder nombre = new StringBuilder("Hola soy Juanita");
Console.WriteLine(nombre);
DateTime end = DateTime.Now;

TimeSpan tiempo = end - start;
Console.WriteLine("Tiempo transcurrido usando string: " + tiempo);
//Console.WriteLine("Tiempo transcurrido usando StringBuilder: " + tiempo);
~~~

Segundo caso: conviene usar StringBuilder.
~~~c#
using System.Text;

DateTime start = DateTime.Now;
//string num = "Los numeros del 1 al 1000 son: ";
StringBuilder num = new StringBuilder("Los numeros del 1 al 1000 son: ");
for (int i = 1; i < 1000; i++)
{
    //num += i.ToString();
    num.Append(i.ToString());
}
Console.WriteLine(num);
DateTime end = DateTime.Now;

TimeSpan tiempo = end - start;
//Console.WriteLine("Tiempo transcurrido usando string: " + tiempo);
Console.WriteLine("Tiempo transcurrido usando StringBuilder: " + tiempo);
~~~


## 🟠 Punto 10
***Comprobar el funcionamiento del siguiente programa y dibujar el estado de la pila y la memoria heap cuando la ejecución alcanza los puntos indicados (comentarios en el código)***


~~~c#
using System.Text;
object[] v = new object[10];
v[0] = new StringBuilder("Net");
for (int i = 1; i < 10; i++)
{
    v[i] = v[i - 1];
}
(v[5] as StringBuilder).Insert(0, "Framework .");
foreach (StringBuilder s in v)
    Console.WriteLine(s);
//dibujar el estado de la pila y la mem. heap
//en este punto de la ejecución [CASO1]
v[5] = new StringBuilder("CSharp");
foreach (StringBuilder s in v)
    Console.WriteLine(s);
//dibujar el estado de la pila y la mem. heap
//en este punto de la ejecución [CASO2]
~~~

En el **CASO 1**, asignamos a todos los objetos del vector, el contenido del objeto en v[0], al ser por referencia, todos apuntan a la misma dirección del Heap, pues se comparte la dirección del objeto v[0].

![Caso1](/../main/recursos/imagen1.png)

En el **CASO 2**, creamos un nuevo StringBuilder y lo asignamos a v[5], entonces, ahora v[5] va a estar apuntando a una dirección distinta, mientras que el resto de los objetos del vector apuntan a la misma dirección pues comparten 1 sóla dirección con v[0].

![Caso2](/../main/recursos/imagen2.png)


## 🟠 Punto 11
***¿Para qué sirve el método Split de la clase string? Usarlo para escribir en la consola todas las palabras (una por línea) de una frase ingresada por consola por el usuario.***


El método String.Split crea una matriz de subcadenas mediante la división de la cadena de entrada en función de uno o varios delimitadores. A menudo, este método es la manera más fácil de separar una cadena en límites de palabras. También sirve para dividir las cadenas en otras cadenas o caracteres específicos.

~~~c#
Console.WriteLine("Ingrese una frase: ");
string? frase = Console.ReadLine();
string[] palabras = frase.Split(' ');

foreach (var palabra in palabras)
{
    System.Console.WriteLine($"{palabra}");
}
~~~


## 🟠 Punto 12
***Definir el tipo de datos enumerativo llamado Meses y utilizarlo para:***
* ***Imprimir en la consola el nombre de cada uno de los meses en orden inverso (diciembre, noviembre, … , enero).***
* ***Solicitar al usuario que ingrese un texto y responder si el texto tipeado corresponde al nombre de un mes.***
***Nota: en todos los casos utilizar un for iterando sobre una variable de tipo Meses***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        string[] meses = Enum.GetNames(typeof(Meses));

        //a) Imprimo los meses en orden inverso
        for (int i = meses.Length - 1; i >= 0; i--)
        {
            Console.Write(meses[i]+" | ");
        }

        //b) Buscar un mes
        Console.WriteLine("\n Ingrese un palabra");
        string texto = Console.ReadLine();
        bool esMes = false;
        for (int i = 0; i < meses.Length; i++)
        {
            if (meses[i] == texto)
            {
                Console.WriteLine("El texto ingresado es un mes");
                esMes = true;
            }
        }
        if (!esMes)
        {
            Console.WriteLine("El texto ingresado NO es un mes");
        }
    }
}

//Defino tipo de dato enumerativo Meses
enum Meses
{
    enero, febrero, marzo, abril, mayo, junio, julio, 
    agosto, septiembre, octubre, noviembre, diciembre
}
~~~


## 🟠 Punto 13
***¿Cuál es la salida por consola si no se pasan argumentos por la línea de comandos?***


~~~c#
Console.WriteLine(args == null);
Console.WriteLine(args.Length);
~~~

Si no paso argumentos por la linea de comandos y no los definí en el archivo launch.json, la salida por consola será: 
* Primer linea --> **false**, pues args <> null
* Segunda linea --> **0**, pues no tengo ningún argumento definido ni pasado por la linea de comandos.

## 🟠 Punto 14
***¿Qué hace la instrucción? ¿Asigna a la variable vector el valor null?***


~~~c#
int[]? vector = new int[0];
~~~

No, lo que hace la instrucción es indicar que el vector de enteros acepta valores null, y luego declara un vector de 0 elementos enteros. Si en lugar de tener 0 elementos tuviera 1 elemento, ese elemento al querer leerlo devolvería 0.


## 🟠 Punto 15
***Determinar qué hace el siguiente programa y explicar qué sucede si no se pasan parámetros cuando se invoca desde la línea de comandos.***


~~~c#
Console.WriteLine("¡Hola {0}!", args[0]);
~~~

Este programa muestra en pantalla el mensaje ¡Hola <arg[0]>!, donde arg[0] es un String que pasé como parámetro o definí previamente. Si no paso argumentos por la linea de comandos y no los definí en el archivo launch.json, el programa me dará error puesto que args[0] mo está definido. 
Por ejemplo si args[0]: "Juana", el programa devolverá --> ¡Hola Juana!


## 🟠 Punto 16
***Escribir un programa que reciba una lista de nombres como parámetro por la línea de comandos e imprima por consola un saludo personalizado para cada uno de ellos.***

***a) Utilizando la sentencia for***

~~~c#
for (int i = 0; i< args.Length; i++)
{
    Console.WriteLine("Hola " + args[i] + ", ¡Buen día!");
}
~~~

***b) Utilizando la sentencia foreach***

~~~c#
foreach (string nombre in args)
{
    Console.WriteLine("Hola "+nombre+", ¡Buen día!");
}
~~~


## 🟠 Punto 17
***Implementar un programa que muestre todos los números primos entre 1 y un número natural dado (pasado al programa como argumento por la línea de comandos). Definir el método bool EsPrimo(int n) que devuelve true sólo si n es primo. Esta función debe comprobar si n es divisible por algún número entero entre 2 y la raíz cuadrada de n. (Nota: Math.Sqrt(d) devuelve la raíz cuadrada de d)***


~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        for (int i = 1; i < n; i++)
        {
            if (EsPrimo(i))
            {
                Console.Write(i + " ");
            }
        }


        static bool EsPrimo(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
~~~


## 🟠 Punto 18
***Escribir una función (método int Fac(int n)) que calcule el factorial de un número n pasado al programa como parámetro por la línea de comando***

***a) Definiendo una función no recursiva***

~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        Console.WriteLine("Factorial del numero ingresado: "+Fac(n));

        static int Fac(int n)
        {
            int tot=1;
            for (int i=n;i>1;i--)
            {
                tot*=i;
            }
            return tot;
        }
    }
}
~~~

***b) Definiendo una función recursiva***

~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        Console.WriteLine("Factorial del numero ingresado: "+Fac(n));

        static int Fac(int n)
        {
            if (n==1)
            {
                return n;
            }
            else
            {
                return n*Fac(n-1);
            }
        }
    }
}
~~~

***c) idem a b) pero con expression-bodied methods (Tip: utilizar el operador condicional ternario)***

~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        Console.WriteLine("Factorial del numero ingresado: "+Fac(n));

        static int Fac(int n) => n==1 ? 1 : n * Fac(n - 1);
    }
}
~~~


## 🟠 Punto 19
***Idem. al ejercicio 18.a) y 18.b) pero devolviendo el resultado en un parámetro de salida void Fac(int n, out int f)***

* Función NO recursiva que devuelve el resultado en un parámetro de salida

~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        Fac(n, out int f);
        Console.WriteLine("Factorial del numero ingresado: " + f);

        static void Fac(int n,out int f)
        {
            f = 1;
            for (int i = n; i > 1; i--)
            {
                f *= i;
            }
        }
    }
}
~~~
  
* Función recursiva que devuelve el resultado en un parámetro de salida

~~~c#
internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(args[0]);
        Fac(n, out int f);
        Console.WriteLine("Factorial del numero ingresado: " + f);

        static void Fac(int n, out int f)
        {
            if (n == 1)
            {
                f = n;
            }
            else
            {
                Fac(n - 1, out f);
                f = n * f;
            }
        }
    }
}
~~~


## 🟠 Punto 20
***Codificar el método Swap que recibe 2 parámetros enteros e intercambia sus valores. El cambio debe apreciarse en el método invocador.***


~~~c#
Console.WriteLine("Ingrese dos números:");
string st1 = Console.ReadLine();
string st2 = Console.ReadLine();
int num1 = int.Parse(st1);
int num2 = int.Parse(st2);
Console.WriteLine("Sin cambiar {0} == {1}", num1, num2);
Swap( ref num1, ref num2);
Console.WriteLine("Swap {0} == {1}", num1, num2);


static void Swap(ref int num1, ref int num2)
{
    int aux = num2;
    num2 = num1;
    num1 = aux;
}
~~~


## 🟠 Punto 21
***Codificar el método Imprimir para que el siguiente código produzca la salida por consola que se observa. Considerar que el usuario del método Imprimir podría querer más adelante imprimir otros datos, posiblemente de otros tipos pasando una cantidad distinta de parámetros cada vez que invoque el método. Tip: usar params***

~~~c#
Imprimir(1, "casa", 'A', 3.4, DayOfWeek.Saturday);
Imprimir(1, 2, "tres");
Imprimir();
Imprimir("-------------");

static void Imprimir(params object[] vector)
{
    foreach (object i in vector)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine(" ");
}
~~~

<br>
<br>
<br>



<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>
