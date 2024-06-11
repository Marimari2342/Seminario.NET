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

***Existe un alto nivel de acoplamiento entre las clases ContadorDeLineas e Ingresador, habiendo una referencia circular: un objeto ContadorDeLineas posee una referencia a un objeto Ingresador y éste último posee una referencia al primero. Esto no es deseable, hace que el código sea difícil de mantener. Eliminar esta referencia circular utilizando un evento, de tal forma que ContadorDeLineas posea una referencia a Ingresador pero que no ocurra lo contrario.***

## ⚫ Punto 4

***Codificar una clase Ingresador con un método público Ingresar() que permita al usuario ingresar líneas por la consola hasta que se ingrese la línea con la palabra "fin". Ingresador debe implementar dos eventos. Uno sirve para notificar que se ha ingresado una línea vacía ( "" ). El otro para indicar que se ha ingresado un valor numérico (debe comunicar el valor del número ingresado como argumento cuando se genera el evento). A modo de ejemplo observar el siguiente código que hace uso de un objeto Ingresador.***

~~~c#
Ingresador ingresador = new Ingresador();
ingresador.LineaVaciaIngresada += (sender, e) =>
    { Console.WriteLine("Se ingresó una línea en blanco"); };
ingresador.NroIngresado += (sender, e) =>
    { Console.WriteLine($"Se ingresó el número {e.Valor}"); };
ingresador.Ingresar();
~~~

## ⚫ Punto 5

***Codificar la clase Temporizador con un evento Tic que se genera cada cierto intervalo de tiempo medido en milisegundos una vez que el temporizador se haya habilitado. La clase debe contar con dos propiedades: Intervalo de tipo int y Habilitado de tipo bool. No se debe permitir establecer la propiedad Habilitado en true si no existe ninguna suscripción al evento Tic. No se debe permitir establecer el valor de Intervalo menor a 100. En el lanzamiento del evento, el temporizador debe informar la cantidad de veces que se provocó el evento. Para detener los eventos debe establecerse la propiedad Habilitado en false. A modo de ejemplo, el siguiente código debe producir la salida indicada.***

~~~c#
Temporizador t = new Temporizador();
t.Tic += (sender, e) =>
{
    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ");
    if (e.Tics == 5)
    {
        t.Habilitado = false;
    }
};
t.Intervalo = 2000;
t.Habilitado = true;
~~~

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>