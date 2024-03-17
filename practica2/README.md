# PRÁCTICA 2

## Punto 1
### 1) Dado el siguiente código: El tipo object es un tipo referencia, por lo tanto luego de la sentencia o2 = o1 ambas variables están apuntando a la misma dirección. ¿Cómo explica entonces que el resultado en la consola no sea “Z Z”?
~~~
object o1 = "A";
object o2 = o1;
o2 = "Z";
Console.WriteLine(o1 + " " + o2);
~~~
Esto es porque son dos objetos distintos tengo:
~~~
object o1 = "A";    o1 --> A
                    o2 --> ?
object o2 = o1;     o1 --> A
                    o2 --> A
o2 = "Z";       o1 --> A
                o2 --> Z
~~~

## Punto 2
2) Qué líneas del siguiente código provocan conversiones boxing y unboxing.

Las conversiones boxing y unboxing permiten asignar variables de tipo de valor a variables de tipo de referencia y viceversa.
* Cuando una variable de algun tipo de valor se asigna a una de tipo de referencia, se dice que se le aplicó la conversión BOXING.
* Cuando una variable de algun tipo de referencia se asigna a una de tipo de valor, se dice que se le aplicó la conversión UNBOXING.
~~~
char c1 = 'A'; 
string st1 = "A"; 
object o1 = c1; // o1(referencia) <-- c1(valor) == BOXING
object o2 = st1; // o2(referencia) <-- st1(valor) == BOXING
char c2 = (char)o1; // c2(valor) <-- o1(referencia) == UNBOXING
string st2 = (string)o2; // st2(valor) <-- o2(referencia) == UNBOXING
~~~
