# Práctica 2

## Punto 1
**Dado el siguiente código: El tipo object es un tipo referencia, por lo tanto luego de la sentencia o2 = o1 ambas variables están apuntando a la misma dirección. ¿Cómo explica entonces que el resultado en la consola no sea “Z Z”?**
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

o2 = "Z";           o1 --> A
                    o2 --> Z
~~~

## Punto 2
**¿Qué líneas del siguiente código provocan conversiones boxing y unboxing?**

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

## Punto 3
**¿Qué diferencias existen entre las conversiones de tipo implícitas y explícitas?**

* Conversiones implícitas: son aquellas en las que no hace falta indicar entre paréntesis la conversion. Ejemplo --> double num = 10;
* Conversiones explicitas: tengo que indicar entre paréntesis el tipo de dato al que quiero convertir. Ejemplo --> int num = (int) 10.0; Si no aclaro entre paréntesis el tipo de conversion me va a tirar error.

## Punto 4
**Resolver los errores de compilación en el siguiente fragmento de código. Utilizar el operador as cuando sea posible.**

~~~
object o = "Hola Mundo!";
string? st = o as string; //string acepta valores null entonces puedo usar as

int i = 12;
byte b = (byte)i; //no puedo usar as porque byte no acepta valores null

double d = i;
float f = (float)d; //no puedo usar as porque float no acepta valores null

o = i;
i = (int) o+ 1; //no puedo usar as porque int no acepta valores null
~~~

## Punto 6
**Supongamos que Program.cs sólo tiene dos líneas ¿Por qué no compila?**

~~~
int i;

Console.WriteLine(i);
~~~

Porque no le asigno ningún valor a la variable i, entonces no puedo imprimirla en pantalla.

## Punto 7
**¿Cuál es la salida por consola del siguiente fragmento de código? ¿Por qué la tercera y sexta línea producen resultados diferentes?**

~~~
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

## Punto 8
**Investigar acerca de la clase StringBuilder del espacio de nombre System.Text ¿En qué circunstancias es preferible utilizar StringBuilder en lugar de utilizar string? Implementar un caso de ejemplo en el que el rendimiento sea claramente superior utilizando StringBuilder en lugar de string y otro en el que no.**

El objeto String es inmutable. Cada vez que se usa uno de los métodos de la clase System.String, se crea un objeto de cadena en la memoria, lo que requiere una nueva asignación de espacio para ese objeto. En las situaciones en las que es necesario realizar modificaciones repetidas en una cadena, la sobrecarga asociada a la creación de un objeto String puede ser costosa. La clase System.Text.StringBuilder se puede usar para modificar una cadena sin crear un objeto. Por ejemplo, el uso de la clase StringBuilder puede mejorar el rendimiento al concatenar muchas cadenas en un bucle.
**Debo usar String:**
*Cuando la cantidad de cambios que su aplicación realizará en una cadena es pequeña.
*Cuando está realizando un número fijo de operaciones de concatenación. 
*Cuando hay se realizan operaciones de búsqueda extensas mientras al construir la cadena.
**Debo usar StringBuilder:**
*Cuando espera que su aplicación realice un número desconocido o una cantidad
*significativa de cambios en una cadena.
