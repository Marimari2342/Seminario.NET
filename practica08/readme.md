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

## ⚫ Punto 2

***Dado el siguiente código:***

~~~c#
-------Program.cs---------
Trabajador t1 = new Trabajador();
t1.Trabajando = T1Trabajando;
t1.Trabajar();

void T1Trabajando(object? sender, EventArgs e)
=> Console.WriteLine("Se inició el trabajo");

-------Trabajador.cs---------
class Trabajador
{
    public EventHandler? Trabajando; //No es necesario definir un tipo delegado propio
    //porque la plataforma provee el tipo EventHandler
    //que se adecua a lo que se necesita
    public void Trabajar()
    {
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        Console.WriteLine("Trabajo concluido");
    }
}
~~~

***a) Ejecutar paso a paso el programa y observar cuidadosamente su funcionamiento. Para ejecutar paso a paso colocar un punto de interrupción (breakpoint) en la primera línea ejecutable del método Main().***

***Ejecutar el programa y una vez interrumpido, proseguir paso a paso, en general la tecla asociada para ejecutar paso a paso entrando en los métodos que se invocan es F11, sin embargo también es posible utilizar el botón de la barra que aparece en la parte superior del editor cuando el programa está con la ejecución interrumpida.***

***b) ¿Qué salida produce por Consola?***

<details><summary> <code> Respuesta 🖱 </code></summary><br>

~~~
Se inició el trabajo
Trabajo concluido
~~~

</details>

***c) Borrar (o comentar) la instrucción t1.Trabajando = T1Trabajando; del método Main y contestar: ¿Cuál es el error que ocurre? ¿Dónde y por qué? ¿Cómo se debería implementar el método Trabajar() para evitarlo?***

<details><summary> <code> Respuesta 🖱 </code></summary><br>

El programa tira dos warning:

* Trabajador.cs(8,9) --> La función local "T1Trabajando" se declara pero nunca se usa.

* Trabajador.cs(3,26) --> El campo 'Trabajador.Trabajando' nunca se asigna y siempre tendrá el valor predeterminado null.

Luego se muestra la siguiente excepción:

Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.

* at Trabajador.Trabajar() in Trabajador.cs:line 8

* at Program. </Maín/> $(String[] args) in Program.cs:line 14

</details>

***d) Eliminar el método T1Trabajando en Program.cs y suscribirse al evento con una expresión lambda.***

***e) Reemplazar el campo público Trabajando de la clase Trabajador, por un evento público generado por el compilador (event notación abreviada). ¿Qué operador se debe usar en la suscripción?***

***f) Cambiar en la clase Trabajador el evento generado automáticamente por uno implementado de manera explícita con los dos descriptores de acceso y haciendo que, al momento en que alguien se suscriba al evento, se dispare el método Trabajar(), haciendo innecesaria la invocación t1.Trabajar(); en Program.cs***

## ⚫ Punto 3

***Analizar el siguiente código:***

~~~c#
-------Program.cs---------
ContadorDeLineas contador = new ContadorDeLineas();
contador.Contar();
-------ContadorDeLineas.cs---------
class ContadorDeLineas
{
    private int _cantLineas = 0;
    public void Contar()
    {
        Ingresador _ingresador = new Ingresador();
        _ingresador.Contador = this;
        _ingresador.Ingresar();
        Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
    }
    public void UnaLineaMas() => _cantLineas++;
}
-------Ingresador.cs---------
class Ingresador
{
    public ContadorDeLineas? Contador { get; set; }
    public void Ingresar()
    {
        string st = Console.ReadLine()??"";
        while (st != "")
        {
            Contador?.UnaLineaMas();
            st = Console.ReadLine()??"";
        }
    }
}
~~~

## ⚫ Punto 4

## ⚫ Punto 5

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>