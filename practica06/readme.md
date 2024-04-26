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



<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>