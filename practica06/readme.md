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

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

## 🟣 Punto 5

***¿Qué líneas del siguiente código provocan error de compilación y por qué?***

~~~c#
class Persona
{
    public string Nombre { get; set; }
}
public class Auto
{
    private Persona _dueño1, _dueño2;
    public Persona GetPrimerDueño() => _dueño1;
    protected Persona SegundoDueño
    {
        set => _dueño2 = value;
    }
}
~~~

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

## 🟣 Punto 7

***Ofrecer una implementación polimórfica para mejorar el siguiente programa:***

~~~c#
Imprimidor.Imprimir(new A(), new B(), new C(), new D());

class A {
    public void ImprimirA() => Console.WriteLine("Soy una instancia A");
}
class B {
    public void ImprimirB() => Console.WriteLine("Soy una instancia B");
}
class C {
    public void ImprimirC() => Console.WriteLine("Soy una instancia C");
}
class D {
    public void ImprimirD() => Console.WriteLine("Soy una instancia D");
}
static class Imprimidor
{
    public static void Imprimir(params object[] vector)
    {
        foreach (object o in vector)
        {
            if (o is A a) { a.ImprimirA(); }
            else if (o is B b) { b.ImprimirB(); }
            else if (o is C c) { c.ImprimirC(); }
            else if (o is D d) { d.ImprimirD(); }
        }
    }
}
~~~

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

## 🟣 Punto 8

***Crear un programa para gestionar empleados en una empresa. Los empleados deben tener las propiedades públicas de sólo lectura Nombre, DNI, FechaDeIngreso, SalarioBase y Salario. Los valores de estas propiedades (a excepción de Salario que es una propiedad calculada) deben establecerse por medio de un constructor adecuado.***

***Existen dos tipos de empleados: Administrativo y Vendedor. No se podrán crear objetos de la clase padre empleado, pero sí de sus clases hijas (Administrativo y Vendedor). Aparte de las propiedades de solo lectura mencionadas, el administrativo tiene otra propiedad pública de lectura/escritura llamada Premio y el vendedor tiene otra propiedad pública de lectura/escritura llamada Comision.***

***La propiedad de solo lectura Salario, se calcula como el salario base más la comisión o el premio según corresponda. Las clases tendrán además un método público llamado AumentarSalario() que tendrá una implementación distinta en cada clase. En el caso del administrativo se incrementará el salario base en un 1% por cada año de antigüedad que posea en la empresa, en el caso del vendedor se incrementará el salario base en un 5% si su antigüedad es inferior a 10 años o en un 10% en caso contrario.***

***El siguiente código (ejecutado el día 9/4/2022) debería mostrar en la consola el resultado indicado:***

~~~c#
Empleado[] empleados = new Empleado[] {
    new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
    new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
    new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
};
foreach (Empleado e in empleados)
{
    Console.WriteLine(e);
    e.AumentarSalario();
    Console.WriteLine(e);
}
~~~

SALIDA POR CONSOLA

![ImagenPantalla](/../main/recursos/imagen13.png)

***Recomendaciones: Observar que el método AumentarSalario() y la propiedad de solo lectura Salario en la clase Empleado pueden declararse como abstractos. Intentar no usar campos sino propiedades auto-implementadas todas las veces que sea posible. Además sería deseable que la propiedad SalarioBase definida en Empleado sea pública para la lectura y protegida para la escritura, para que pueda establecerse desde las subclases Administrativo y Vendedor.***

<details><summary> <code> Respuesta 🖱 </code></summary><br>
</details>

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>