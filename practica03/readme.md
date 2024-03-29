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