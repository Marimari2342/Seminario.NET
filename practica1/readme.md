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
***Investigar por las secuencias de escape \n, \t , \" y \\. Escribir un programa que las utilice para imprimir distintos mensajes en la consola.***


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


Saco el @ y para que no me tire error uso el codigo de escape \\ de barra diagonal inversa.
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
