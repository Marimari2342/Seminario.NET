# PRACTICA 2

## Punto 1
1) Dado el siguiente código: El tipo object es un tipo referencia, por lo tanto luego
de la sentencia o2 = o1 ambas variables están apuntando a la misma dirección. ¿Cómo
explica entonces que el resultado en la consola no sea “Z Z”?
~~~
object o1 = "A";
object o2 = o1;
o2 = "Z";
Console.WriteLine(o1 + " " + o2);
~~~
Esto es porque son dos objetos distintos tengo:
object o1 = "A";    o1 --> A
                    o2 --> ?
object o2 = o1;     o1 --> A
                    o2 --> A
o2 = "Z";       o1 --> A
                o2 --> Z
