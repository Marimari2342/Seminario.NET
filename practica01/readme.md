# .NET - Practica 1


## Punto 1
***Consultar en la documentación de Microsoft y responder cuál es la diferencia entre los métodos WriteLine() y Write() de la clase System.Console ¿Cómo funciona el método ReadKey() de la misma clase? Escribir un programa que imprima en la consola la frase “Hola Mundo” haciendo una pausa entre palabra y palabra esperando a que el usuario presione una tecla para continuar. Tip: usar los métodos ReadKey() y Write() de la clase System.Console.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>
    
* WriteLine() -->  Imprime en pantalla y salta de linea al final.
* Write() -->      Imprime en pantalla sin saltar de linea al final.
* ReadKey() -->    Obtiene la siguiente tecla de carácter o de función presionada por el usuario. La tecla presionada se muestra en la ventana de la consola.

~~~c#
Console.Write("Hola");

Console.ReadKey();

Console.Write("Mundo");
~~~
</details>

## Punto 2
***Investigar por las secuencias de escape \n, \t , \\" y \\\. Escribir un programa que las utilice para imprimir distintos mensajes en la consola.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

* \n --> nueva linea (funciona como un ENTER)
* \t --> tabulacion horizontal (el cursos se desplaza horizontalmente despues de imprimir)
* \\" --> comillas dobles (lo uso si quiero imprimir " en pantalla, puesto que si no lo indico así, el código entiendo que estoy abriendo o cerrando un string que quiero mostrar)
* \\\ --> barra diagonal inversa (lo mismo que el anterior pero con la barra invertida)

~~~c#
Console.Write ("Voy a hacer un salto de linea \n");

Console.WriteLine("Ahora voy a escribir las comillas: \" y una barra diagonal: \\");

Console.WriteLine("Voy a hacer una tabulación horizontal --> \t asi");
~~~
</details>

## Punto 3
***El carácter @ delante de un string desactiva los códigos de escape. Probar el siguiente fragmento de código, eliminar el carácter @ y utilizar las secuencias de escape necesarias para que el programa siga funcionando de igual manera***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

Saco el @ y para que no me tire error uso el codigo de escape \\\ de barra diagonal inversa.
~~~c#
string st = "c:\\windows\\system";

Console.WriteLine(st);
~~~

</details>

## Punto 4
***Escribir un programa que solicite al usuario ingresar su nombre e imprima en la consola un saludo personalizado utilizando ese nombre o la frase “Hola mundo” si el usuario ingresó una línea en blanco. Para ingresar un string desde el teclado utilizar Console.ReadLine()***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
Console.WriteLine("Ingrese su nombre:");
string nombre = Console.ReadLine();
if (nombre == "")
{
    Console.WriteLine("Hola mundo");
}
else
{
    Console.WriteLine("Hola " + nombre + " bienvenido/a");
}
~~~

</details>

## Punto 5
***Idem. al ejercicio anterior salvo que se imprimirá un mensaje de saludo diferente según sea el nombre ingresado por el usuario. Así para “Juan” debe imprimir “¡Hola amigo!”, para “María” debe imprimir “Buen día señora”, para “Alberto” debe imprimir “Hola Alberto”. En otro caso, debe imprimir “Buen día ” seguido del nombre ingresado o “¡Buen día mundo!” si se ha ingresado una línea vacía.***

***a) utilizando if ... else if***

<details><summary> <code> Respuesta 🖱 </code></summary>

~~~c#
Console.WriteLine("Ingrese su nombre:");
string nombre = Console.ReadLine();
if (nombre == "Juan")
{ 
    Console.WriteLine("¡Hola amigo!");
}
else if (nombre == "Maria")
{
    Console.WriteLine("Buen dia señora");
}
else if (nombre == "Alberto")
{
    Console.WriteLine("Hola "+nombre);
}
else if (nombre == "")
{
    Console.WriteLine("¡Buen dia mundo!");
}
else
{
    Console.WriteLine("Buen dia "+nombre);
}
~~~

</details>

***b) utilizando switch***

<details><summary> <code> Respuesta 🖱 </code></summary>
    
~~~c#
Console.WriteLine("Ingrese su nombre:");
string nombre = Console.ReadLine();
switch (nombre)
{
    case "Juan":
        Console.WriteLine("¡Hola amigo!");
        break;
    case "Maria":
        Console.WriteLine("Buen dia señora");
        break;
    case "Alberto":
        Console.WriteLine("Hola "+nombre);
        break;
    case "":
        Console.WriteLine("¡Buen dia mundo!");
        break;
    default:
        Console.WriteLine("Buen dia "+nombre);
        break;
}
~~~

</details>

## Punto 6
***Utilizar Console.ReadLine() para leer líneas de texto (secuencia de caracteres que finaliza al presionar <ENTER>) por la consola. Por cada línea leída se debe imprimir inmediatamente la cantidad de caracteres de la misma. El programa termina al ingresar la cadena vacía. Tip: si st es una variable de tipo string, entonces st.Length devuelve la cantidad de caracteres del string.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
Console.WriteLine("Ingrese una palabra");

string st = Console.ReadLine();

int i = st.Length;

while (i>0)

{

    Console.WriteLine("cantidad de letras: "+i);

    Console.WriteLine("Ingrese otra palabra");

    st = Console.ReadLine();

    i = st.Length;

}
~~~

</details>

## Punto 7
***¿Qué hace la instrucción Console.WriteLine("100".Length); ?***

<details><summary> <code> click para ver resolución 🖱 </code></summary>
    
~~~c#
Console.WriteLine("100".Length);
~~~

Lo que hace es decirme la cantidad de caracteres que componen el string "100", es decir devuelve 3 en pantalla.

</details>

## Punto 8
***Sea st una variable de tipo string correctamente declarada. ¿Es válida la siguiente instrucción: Console.WriteLine(st=Console.ReadLine());?***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
string st;

Console.WriteLine(st = Console.ReadLine());
~~~
Si, lo que va a hacer esta sentencia es pedirte que ingreses un string y automaticamente escribirlo abajo.

</details>

## Punto 9
***Escribir un programa que lea dos palabras separadas por un blanco que terminan con <ENTER>, y determinar si son simétricas (Ej: 'abbccd' y 'dccbba' son simétricas). Tip: si st es un string, entonces st[0] devuelve el primer carácter de st, y st[st.Length-1] devuelve el último carácter de st.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

**st.Split(' ');** hace un array de subcadenas utilizando el carácter espacio (' ') como delimitador. Por ejemplo, si el usuario ingresa "hola mundo" en st, entonces st.Split(' ') creará un array con dos elementos: "hola" y "mundo". Entonces, después de esa línea de código, si imprimes st[0], obtendrás "hola", y si imprimes st[1], tendrás "mundo". Me ayuda a saber cuantos espacios hubo, tantos como elementos en el arreglo.


~~~c#
Console.WriteLine("Escriba dos palabras separadas por un espacio");
string st = Console.ReadLine();

if (st.Length == 0)
{
    Console.WriteLine("ERROR, no ingreso dos palabras");
}
else
{
    string st1 = st.Split(" ")[0]; //palabra1
    string st2 = st.Split(" ")[1]; //palabra2

    if (st1.Length! > st2.Length)
    {
        Console.WriteLine("Las palabras no son simétricas y tienen distintas dimensiones");
    }
    else
    {
        bool ok = true;
        for (int i = 0; i < st1.Length; i++)
        {
            if (st1[i] != st2[st1.Length - 1 - i])
            {
                ok = false;
                break;
            }
        }
        if (ok)
        {
            Console.WriteLine("Las palabras son simetricas");
        }
        else
        {
            Console.WriteLine("Las palabras NO son simetricas");
        }
    }
}
~~~

</details>

## Punto 10
***Escribir un programa que imprima en la consola todos los múltiplos de 17 o de 29 comprendidos entre 1 y 1000.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
for (int num=1;num <=1000;num++)
{
    if (num % 17 == 0||num % 29 == 0)
    {
        Console.Write(num+" ");
    }
}
~~~

</details>

## Punto 11
***Comprobar el funcionamiento del siguiente fragmento de código, analizar el resultado y contestar las preguntas.***

***a) ¿Qué se puede concluir respecto del operador de división “/” ?***

<details><summary> <code> Respuesta 🖱 </code></summary>

Este operador lo que hace es redondear para abajo el número y cortarlo en el caso de que el resultado sea un decimal (en el caso de dividir dos enteros), entonces si por ejemplo quiero dividir dos numeros enteros 5/2 , el resultado no será 2,5 sino 2 pues me corta el número ya que devuelve un entero. Ahora si a uno de mis dos números le pongo un .
me lo toma como un double y no me redondea los decimales.

</details>

***b) ¿Cómo funciona el operador + entre un string y un dato numérico?***

<details><summary> <code> Respuesta 🖱 </code></summary>

Si dos numeros se suman se obtiene la suma aritmetica, si dos strings se suman, se concatenan, ahora si sumo un string y un numero, obtengo la concatenación entre ambos.

~~~c#
Console.WriteLine("10/3 = " + 10 / 3);

Console.WriteLine("10.0/3 = " + 10.0 / 3);

Console.WriteLine("10/3.0 = " + 10 / 3.0);

int a = 10, b = 3;

Console.WriteLine("Si a y b son variables enteras, si a=10 y b=3");

Console.WriteLine("entonces a/b = " + a / b);

double c = 3;

Console.WriteLine("Si c es una variable double, c=3");

Console.WriteLine("entonces a/c = " + a / c);
~~~
</details>

## Punto 12
***Escribir un programa que imprima todos los divisores de un número entero ingresado desde la consola. Para obtener el entero desde un string st utilizar int.Parse(st).***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
Console.WriteLine("Ingrese un numero: ");
int num = int.Parse(Console.ReadLine()); //obtengo el entero desde un string
Console.WriteLine("Divisores de "+num+": ");
for (int i = 1;i<=num;i++)
{
    if (num%i == 0)
    {
        Console.Write(i+" ");
    }
}
~~~
</details>

## Punto 13
***Si a y b son variables enteras, identificar el problema (y la forma de resolverlo) de la siguiente expresión. Tip: observar qué pasa cuando b = 0.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
Console.WriteLine("Ingrese enteros a y b: ");

int a = int.Parse(Console.ReadLine());

int b = int.Parse(Console.ReadLine());

if ((b != 0) && (a/b > 5)) Console.WriteLine(a/b);
~~~

El problema es que si b=0, igual evalua la segunda condición dentro del if, entonces divide entre 0 y eso tira error, porque no puedo tener un cero en el denominador. El modo de solucionarlo es poner && en lugar de & (AND en cortocircuito) que lo que hace es, si ve que la primer condición del if es falsa, no evalua la segunda y directamente
sigue con el programa.

</details>

## Punto 14
***Utilizar el operador ternario condicional para establecer el contenido de una variable entera con el menor valor de otras dos variables enteras.***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

~~~c#
int a = 80;
int b = 19;
int num = (a<b) ? a : b;
Console.WriteLine(num);
~~~

</details>

## Punto 15
***¿Cuál es el problema del código siguiente y cómo se soluciona?***

<details><summary> <code> click para ver resolución 🖱 </code></summary>

Declaro la variable i dos veces. Para solucionar hago:
~~~c#
for (int i = 1; i <= 10;)
{
    Console.WriteLine(i++);
}
~~~

</details>

## Punto 16
***Analizar el siguiente código. ¿Cuál es la salida por consola?***

<details><summary> <code> click para ver resolución 🖱 </code></summary>
    
~~~c#
int i = 1;
if (--i == 0)   //pre decremento: resto 1 y luego evaluo [1 - 1 = 0 == 0]
{
    Console.WriteLine("cero");
}
if (i++ == 0)   //post incremento: evaluo y luego sumo 1 [0 == 0 + 1 = 1]
{
    Console.WriteLine("cero");
}
Console.WriteLine(i);
~~~
</details>

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>
