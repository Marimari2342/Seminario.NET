# .NET - Practica 8


## ⚫ Punto 1

***Responder sobre el siguiente código***

~~~c#
-----------Program.cs-----------
AccionInt a1 = (ref int i) => i = i * 2;
a1 += a1;
a1 += a1;
a1 += a1;
int i = 1;
a1(ref i);
-----------AccionInt.cs-----------
delegate void AccionInt(ref int i);
~~~

***¿Cuál es el tamaño de la lista de invocación de a1 y cual es el valor de la variable i luego de la invocación a1(ref i)?***

<details><summary> <code> Respuesta 🖱 </code></summary><br>

En el código se utiliza un delegado AccionInt para representar una acción que toma una referencia a un entero y lo modifica. Luego, en el archivo Program.cs, se crea una instancia de este delegado llamada a1 que se utiliza varias veces.

El tamaño de la lista de invocación de a1 será 4, ya que se agrega la misma acción (a1) cuatro veces usando el operador +=.

El valor de la variable i después de la invocación a1(ref i) dependerá de cuántas veces se haya ejecutado la acción. En la acción a1, se multiplica el valor de i por 2 cada vez que se ejecuta. La primera vez que se ejecuta, i es 1, luego se convierte en 2, luego 4, luego 8 y finalmente 16. Pero la acción se ejecuta cuatro veces debido a que la estás agregando a sí misma cuatro veces en la lista de invocación. Entonces, el valor final de i será 1×2^4=16×2^4=256.

</details>

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>