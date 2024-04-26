# .NET - Practica 6


## 🟣 Punto 1

***Sin borrar ni modificar ninguna línea, completar la definición de las clases B, C y D para que el siguiente código produzca la salida indicada:***

~~~c#
class A
{
    protected int _id;
    public A(int id) => _id = id;
    public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
}
class B : A
{
    . . .
}
class C : B
{
    . . .
}
class D : C
{
    . . .
    public override void Imprimir()
    {
        . . .
        base.Imprimir();
    }
}

A[] vector = [new A(3),new B(5),new C(15),new D(41)];
foreach (A a in vector)
{
a.Imprimir();
}
~~~

SALIDA POR CONSOLA

![ImagenPantalla](/../main/recursos/imagen11.png)


## 🟣 Punto 2

***Aunque consultar en el código por el tipo de un objeto indica habitualmente un diseño ineficiente, por motivos didácticos vamos a utilizarlo. Completar el siguiente código, que utiliza las clases definidas en el ejercicio anterior, para que se produzca la salida indicada:***

~~~c#
A[] vector = [ new C(1),new D(2),new B(3),new D(4),new B(5)];
foreach (A a in vector)
{
    ...
}
~~~

***Es decir, se deben imprimir sólo los objetos cuyo tipo exacto sea B***

* ***Utilizando el operador is***

* ***Utilizando el método GetType() y el operador typeof() (investigar sobre éste último en la documentación en línea de .net)***

SALIDA POR CONSOLA

![ImagenPantalla](/../main/recursos/imagen12.png)

## 🟣 Punto 3

***¿Por qué no funciona el siguiente código? ¿Cómo se puede solucionar fácilmente?***

~~~c#
class Auto
{
    double velocidad;
    public virtual void Acelerar() => Console.WriteLine("Velocidad = {0}", velocidad += 10);
}
class Taxi : Auto
{
    public override void Acelerar() => Console.WriteLine("Velocidad = {0}", velocidad += 5);
}
~~~

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

## 🟣 Punto 4

***Respecto al siguiente programa: ¿Por qué no es necesario agregar :base en el constructor de Taxi? Eliminar el segundo constructor de la clase Auto y modificar la clase Taxi para el programa siga funcionando.***

~~~c#
Taxi t = new Taxi(3);
Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");
class Auto
{
    public string Marca { get; private set; } = "Ford";
    public Auto(string marca) => this.Marca = marca;
    public Auto() { }
}
class Taxi : Auto
{
    public int Pasajeros { get; private set; }
    public Taxi(int pasajeros) => this.Pasajeros = pasajeros;
}
~~~

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>