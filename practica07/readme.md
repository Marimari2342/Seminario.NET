# .NET - Practica 7


## 🟡 Punto 1
***Codificar las clases e interfaces necesarias para modelar un sistema que trabaja con las siguientes entidades: Autos, Libros, Películas, Personas y Perros. Algunas de estas entidades pueden ser: alquilables (pueden ser alquiladas y devueltas por una persona), vendibles (pueden ser vendidas a una persona), lavables (se pueden lavar y secar) reciclables (se pueden reciclar) y atendibles (se pueden atender). A continuación se describen estas relaciones:***

* ***Son Alquilables: Libros y Películas***

* ***Son Vendibles: Autos y Perros***

* ***Son Lavables: Autos***

* ***Son Reciclables: Libros y Autos***

* ***Son Atendibles: Personas y Perros***

***Completar el código de la clase estática Procesador:***

~~~c#
static class Procesador
{
    public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
    public static . . .
    . . .
}
~~~

***Para que el siguiente código produzca la salida indicada:***

~~~c#
Auto auto = new Auto();
Libro libro = new Libro();
Persona persona = new Persona();
Perro perro = new Perro();
Pelicula pelicula = new Pelicula();
Procesador.Alquilar(pelicula, persona);
Procesador.Alquilar(libro, persona);
Procesador.Atender(persona);
Procesador.Atender(perro);
Procesador.Devolver(pelicula, persona);
Procesador.Devolver(libro, persona);
Procesador.Lavar(auto);
Procesador.Reciclar(libro);
Procesador.Reciclar(auto);
Procesador.Secar(auto);
Procesador.Vender(auto, persona);
Procesador.Vender(perro, persona);
~~~

SALIDA POR CONSOLA

![ImagenPantalla](/../main/recursos/imagen14.png)

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

## 🟡 Punto 2

***Incorporar al ejercicio anterior la posibilidad también de lavar a los perros. También se debe incorporar una clase derivada de Película, las “películas clásicas” que además de alquilarse pueden venderse. Estos cambios deben poder realizarse sin necesidad de modificar la clase estática Procesador. El siguiente código debe producir la salida indicada:***

~~~c#
Auto auto = new Auto();
Libro libro = new Libro();
Persona persona = new Persona();
Perro perro = new Perro();
Pelicula pelicula = new Pelicula();
Procesador.Alquilar(pelicula, persona);
Procesador.Alquilar(libro, persona);
Procesador.Atender(persona);
Procesador.Atender(perro);
Procesador.Devolver(pelicula, persona);
Procesador.Devolver(libro, persona);
Procesador.Lavar(auto);
Procesador.Reciclar(libro);
Procesador.Reciclar(auto);
Procesador.Secar(auto);
Procesador.Vender(auto, persona);
Procesador.Vender(perro, persona);
Procesador.Lavar(perro);
Procesador.Secar(perro);
PeliculaClasica peliculaClasica = new PeliculaClasica();
Procesador.Alquilar(peliculaClasica, persona);
Procesador.Devolver(peliculaClasica, persona);
Procesador.Vender(peliculaClasica, persona);
~~~

SALIDA POR CONSOLA

![ImagenPantalla](/../main/recursos/imagen15.png)

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>