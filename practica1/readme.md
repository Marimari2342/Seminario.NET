# .NET - Practica 1


## Punto 1
***Consultar en la documentación de Microsoft y responder cuál es la diferencia entre los métodos WriteLine() y Write() de la clase System.Console ¿Cómo funciona el método ReadKey() de la misma clase? Escribir un programa que imprima en la consola la frase “Hola Mundo” haciendo una pausa entre palabra y palabra esperando a que el usuario presione una tecla para continuar. Tip: usar los métodos ReadKey() y Write() de la clase System.Console.***


* WriteLine() -->  Imprime en pantalla y salta de linea al final.
* Write() -->      Imprime en pantalla sin saltar de linea al final.
* ReadKey() -->    Obtiene la siguiente tecla de carácter o de función presionada por el usuario. La tecla presionada se muestra en la ventana de la consola.

~~~
Console.Write("Hola");

Console.ReadKey();

Console.Write("Mundo");
~~~


## Punto 2
***Investigar por las secuencias de escape \n, \t , \\" y \\\. Escribir un programa que las utilice para imprimir distintos mensajes en la consola.***


* \n --> nueva linea (funciona como un ENTER)
* \t --> tabulacion horizontal (el cursos se desplaza horizontalmente despues de imprimir)
* \\" --> comillas dobles (lo uso si quiero imprimir " en pantalla, puesto que si no lo indico así, el código entiendo que estoy abriendo o cerrando un string que quiero mostrar)
* \\\ --> barra diagonal inversa (lo mismo que el anterior pero con la barra invertida)

~~~
Console.Write ("Voy a hacer un salto de linea \n");

Console.WriteLine("Ahora voy a escribir las comillas: \" y una barra diagonal: \\");

Console.WriteLine("Voy a hacer una tabulación horizontal --> \t asi");
~~~


## Punto 3
***El carácter @ delante de un string desactiva los códigos de escape. Probar el siguiente fragmento de código, eliminar el carácter @ y utilizar las secuencias de escape necesarias para que el programa siga funcionando de igual manera***


Saco el @ y para que no me tire error uso el codigo de escape \\\ de barra diagonal inversa.
~~~
string st = "c:\\windows\\system";

Console.WriteLine(st);
~~~


## Punto 4
***Escribir un programa que solicite al usuario ingresar su nombre e imprima en la consola un saludo personalizado utilizando ese nombre o la frase “Hola mundo” si el usuario ingresó una línea en blanco. Para ingresar un string desde el teclado utilizar Console.ReadLine()***


~~~
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


## Punto 5
***Idem. al ejercicio anterior salvo que se imprimirá un mensaje de saludo diferente según sea el nombre ingresado por el usuario. Así para “Juan” debe imprimir “¡Hola amigo!”, para “María” debe imprimir “Buen día señora”, para “Alberto” debe imprimir “Hola Alberto”. En otro caso, debe imprimir “Buen día ” seguido del nombre ingresado o “¡Buen día mundo!” si se ha ingresado una línea vacía.***

***a) utilizando if ... else if***

~~~
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

***b) utilizando switch***
~~~
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


## Punto 6
***Utilizar Console.ReadLine() para leer líneas de texto (secuencia de caracteres que finaliza al presionar <ENTER>) por la consola. Por cada línea leída se debe imprimir inmediatamente la cantidad de caracteres de la misma. El programa termina al ingresar la cadena vacía. Tip: si st es una variable de tipo string, entonces st.Length devuelve la cantidad de caracteres del string.***

~~~
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


##Punto 7
***¿Qué hace la instrucción Console.WriteLine("100".Length); ?***

~~~
Console.WriteLine("100".Length);
~~~

Lo que hace es decirme la cantidad de caracteres que componen el string "100", es decir devuelve 3 en pantalla.

![Gracias](xtras/firmagith.png)
