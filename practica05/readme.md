# .NET - Practica 5


## 🟣 Punto 1

***Codificar la clase Cuenta de tal forma que el siguiente código produzca la salida por consola que se indica.***

~~~c#
Cuenta c1 = new Cuenta();
c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
Cuenta c2 = new Cuenta();
c2.Depositar(200).Depositar(800);
new Cuenta().Depositar(20).Extraer(20);
c2.Extraer(1000).Extraer(1);
Console.WriteLine("\nDETALLE");
Cuenta.ImprimirDetalle();
~~~

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

~~~c#
class Cuenta
{
    public static int Id { get; set; }
    public double TotalDep { get; set; }
    public int Id_cuenta { get; set; }

    public static int CantDepositos { get; set; }
    public static int CantExtraciones { get; set; }
    public static int ExtDen { get; set; }
    
    private static double _monto_extracciones;
    private static double _monto_depositos;
    

    public Cuenta()
    {
        Id++;
        Id_cuenta = Id;
        Console.WriteLine($"Se creó la cuenta Id={Id_cuenta}");
    }

    public static double Extracciones
    {
        get
        {
            return _monto_extracciones;
        }
        set
        {
            _monto_extracciones = value;
        }
    }

    public static double Depositos
    {
        get
        {
            return _monto_depositos;
        }
        set
        {
            _monto_depositos = value;
        }
    }

    public Cuenta Depositar(double monto)
    {
        TotalDep += monto;
        CantDepositos++;
        Depositos += monto;
        Console.WriteLine($"Se depositó {monto} en la cuenta {Id_cuenta} (Saldo={TotalDep})");
        return this;
    }

    public Cuenta Extraer(double monto)
    {
        if (monto <= TotalDep)
        {
            TotalDep -= monto;
            CantExtraciones++;
            Extracciones += monto;
            Console.WriteLine($"Se extrajo {monto} de la cuenta {Id_cuenta} (Saldo={TotalDep})");
        }
        else
        {
            ExtDen++;
            Console.WriteLine("Operación denegada - Saldo insuficiente");
        }
        return this;
    }

    public static void ImprimirDetalle()
    {
        Console.WriteLine($"CUENTAS CREADAS: {Id}");
        Console.Write($"DEPOSITOS: {CantDepositos,7}  ");
        Console.WriteLine($" - Total depositado {_monto_depositos}");
        Console.Write($"EXTRACCIONES: {CantExtraciones,4}  ");
        Console.WriteLine($" - Total extraido {_monto_extracciones}");
        Console.WriteLine($"{"",20} - Saldo {(_monto_depositos - _monto_extracciones),-25}");
        Console.WriteLine($" * Se denegaron {ExtDen} extracciones por falta de fondos");
    }
}
~~~

</details>

>[!NOTE]
>
> Punto 1 --> Contestado en *Cuenta.cs* y *Program.cs*.

## 🟣 Punto 2

***Agregar a la clase Cuenta del ejercicio anterior un método estático GetCuentas() que devuelva un List</Cuenta/> con todas las cuentas creadas. Controlar que la modificación de la lista devuelta, por ejemplo borrando algún elemento, no afecte el listado que internamente mantiene la clase Cuenta. Sin embargo debe ser posible interactuar efectivamente con los objetos Cuenta de la lista devuelta. Verificar que el siguiente código produzca la salida por consola que se indica:***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

~~~c#
public static List<Cuenta> lista {get;set;} = new List<Cuenta>();

//En el constructor solo añadimos la linea que añade una nueva Cuenta a la lista
public Cuenta()     
{
    Id++;
    Id_cuenta = Id;
    lista.Add(this);    // <-- ACA
    Console.WriteLine($"Se creó la cuenta Id={Id_cuenta}");
}

//Metodo estático
public static List<Cuenta> GetCuentas()
{
    List<Cuenta> aux = new List<Cuenta>();
    foreach (Cuenta obj in lista)
        aux.Add(obj);
    return aux;
}
~~~

</details>

>[!NOTE]
>
> Punto 2 --> Contestado en *Cuenta.cs* y *Program.cs*.

## 🟣 Punto 3

***Reemplazar el método estático GetCuentas() del ejercicio anterior por una propiedad estática de sólo lectura.***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

~~~c#
//PROPIEDAD ESTÁTICA EN Cuenta.cs
public static List<Cuenta> GetCuentas
{
    get
    {
        List<Cuenta> aux = new List<Cuenta>();
        foreach (Cuenta obj in lista)
            aux.Add(obj);
        return aux;
    }
}

//CAMBIOS EN EL MAIN Program.cs
List<Cuenta> cuentas = Cuenta.GetCuentas(); // <-- ANTES con metodo GetCuentas()
cuentas = Cuenta.GetCuentas();
        
List<Cuenta> cuentas = Cuenta.GetCuentas; // <-- AHORA con propiedad GetCuentas
cuentas = Cuenta.GetCuentas;
~~~

</details>

>[!NOTE]
>
> Punto 3 --> Contestado en *Cuenta.cs* y *Program.cs*.

## 🟣 Punto 5

***Qué líneas del código siguiente provocan error de compilación? Analizar cuándo es posible acceder a miembros estáticos y de instancia.***

~~~c#
class A
{
    char c;
    static string st;
    void metodo1()
    {
        st = "string";
        c = 'A';
    }
    static void metodo2()
    {
        new ClaseA().c = 'a'; //[1]
        st = "st2";
        c = 'B'; //[2]
        new A().st = "otro string"; //[3]
    }
}
~~~

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

* [1] <i>El nombre del tipo o del espacio de nombres 'ClaseA' no se encontró.</i> Esto es porque la clase es A en lugar de ClaseA. Entonces <code>new ClaseA().c = 'a';</code> debe ser cambiado por <code>new A().c = 'a';</code>

* [2] <i>Se requiere una referencia de objeto para el campo, método o propiedad 'A.c' no estáticos.</i> Este error dado en la linea <code>c = 'B';</code> es porque quiero acceder a una variable de instancia dentro del metodo2() que es estático.

* [3] <i>No se puede obtener acceso al miembro 'A.st' con una referencia de instancia; califíquelo con un nombre de tipo en su lugar.</i> Este error dado en la linea <code>new A().st = "otro string";</code> se da porque quiero modificar una variable de instancia estática desde un método.

</details>

## 🟣 Punto 6

***Modificar la definición de la clase Matriz realizada en la práctica 4. Eliminar los métodos SetElemento(...) y GetElemento(...). Definir un indizador adecuado para leer y escribir elementos de la matriz. Eliminar los métodos GetDiagonalPrincipal() y GetDiagonalSecundaria() reemplazándolos por las propiedades de sólo lectura DiagonalPrincipal y DiagonalSecundaria.***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

Eliminar los métodos SetElemento() y GetElemento()
~~~C#
public double[,] MiMatriz { get; set; }
~~~
Eliminar los métodos GetDiagonalPrincipal() y GetDiagonalSecundaria() reemplazándolos por las propiedades de sólo lectura DiagonalPrincipal y DiagonalSecundaria.
~~~C#
public double[] GetDiagonalPrincipal
{
    get
    {
        EsCuadrada(this.MiMatriz.GetLength(0), this.MiMatriz.GetLength(1));
        double[] diagPrinc = new double[this.MiMatriz.GetLength(0)];
        for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
        {
            diagPrinc[i] = this.MiMatriz[i, i];
        }
        return diagPrinc;
    }
}

public double[] GetDiagonalSecundaria()
{
    Get{
        EsCuadrada(this.MiMatriz.GetLength(0), this.MiMatriz.GetLength(1));
        double[] diagSec = new double[this.MiMatriz.GetLength(0)];
        for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
        {
            diagSec[i] = this.MiMatriz[i, this.MiMatriz.GetLength(0) - i - 1];
        }
        return diagSec;
    }
}
~~~

</details>

## 🟣 Punto 7

***Definir la clase Persona con las siguientes propiedades de lectura y escritura: Nombre de tipo string, Sexo de tipo char, DNI de tipo int, y FechaNacimiento de tipo DateTime. Además definir una propiedad de sólo lectura (calculada) Edad de tipo int. Definir un indizador de lectura/escritura que permita acceder a las propiedades a través de un índice entero. Así, si p es un objeto Persona, con p[0] se accede al nombre, p[1] al sexo p[2] al DNI, p[3] a la fecha de nacimiento y p[4] a la edad. En caso de asignar p[4] simplemente el valor es descartado. Observar que el tipo del indizador debe ser capaz almacenar valores de tipo int, char, DateTime y string.***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

~~~C#
class Persona
{
    public string Nombre { get; set; }
    public char Sexo { get; set; }
    public int DNI { get; set; }
    public DateTime FechaNac { get; set; }

    public Persona()
    {
        Nombre = "";
    }

    public int Edad
    {
        get
        {
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - FechaNac.Year;
            if (hoy.Month < FechaNac.Month)
            {
                edad--;
            }
            else if (hoy.Month == FechaNac.Month)
            {
                if (hoy.Day < FechaNac.Day)
                {
                    edad--;
                }
            }
            return edad;
        }
    }

    public object this[int i]
    {
        get
        {
            if (i == 0) return Nombre;
            else if (i == 1) return Sexo;
            else if (i == 2) return DNI;
            else if (i == 3) return FechaNac;
            else return Edad;
        }
        set
        {
            if (i == 0) Nombre = (string)value;
            else if (i == 1) Sexo = (char)value;
            else if (i == 2) DNI = (int)value;
            else if (i == 3) FechaNac = (DateTime)value;
        }
    }
}
~~~

El Main (en Program.cs)

~~~c#
Persona p = new Persona();
p[0] = "Maria Paez";
p[1] = 'F';
p[2] = 30326545;
p[3] = new DateTime(1980, 08, 12);
Console.WriteLine($"Nombre: {p[0]}");
Console.WriteLine("Sexo: {0}", p[1].Equals('M') ? "Masculino" : "Femenino");
Console.WriteLine($"DNI: {p[2]}");
Console.WriteLine($"Nacimiento: {p[3]:dd/MM/yyyy}");
Console.WriteLine($"Edad: {p[4]}");
~~~
</details>

>[!NOTE]
>
> Punto 7 --> Contestado en *Persona.cs* y *Program.cs*.

## 🟣 Punto 8

***Dada la siguiente definición incompleta de clase:***

~~~c#
class ListaDePersonas
{
    public void Agregar(Persona p)
    {
        . . .
    }
    . . .
}
~~~

***Completarla y agregar dos indizadores de sólo lectura:***
 
* ***Un índice entero que permite acceder a las personas de la lista por número de documento. Por ejemplo p=lista[30456345] devuelve el objeto Persona que tiene DNI=30456345 o null en caso que no exista en la lista.***

* ***Un índice de tipo char que devuelve un List<string> con todos los nombres de las personas de la lista que comienzan con el carácter pasado como índice.***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>
</details>

## 🟣 Punto 9

***¿Cuál es el error en el siguiente programa?***

~~~c#
Auto a = new Auto();
a.Marca = "Ford";
Console.WriteLine(a.Marca);
class Auto
{
    private string marca;
    public string Marca
    {
        set
        {
            Marca = value;
        }
        get
        {
            return marca;
        }
    }
}
~~~

***Nota: Observar que utilizar la convención de prefijar a los campos privados con guión bajo, hace más difícil cometer este tipo de errores***

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>
</details>

## 🟣 Punto 10

***Identificar todos los miembros en la siguiente declaración de clase. Indicar si se trata de un constructor, método, campo, propiedad o indizador, si es estático o de instancia, y en caso que corresponda si es de sólo lectura, sólo escritura o lectura y escritura. En el caso de las propiedades indicar también si se trata de una propiedad auto-implementada. Nota: La clase compila perfectamente. Sólo prestar atención a la sintaxis, la semántica es irrelevante.***

~~~c#
class A
{
    private static int a; //Variable de clase estática de tipo entero
    private static readonly int b; //Variable de clase estática de solo lectura
    A() { } //Constructor privado
    public A(int i) : this() { } //Constructor publico que recibe un entero e implementa el constructor privado de arriba
    static A() => b = 2; //Constructor estático que se ejecuta en la compilación
    int c; //Variable privada de tipo entero
    public static void A1() => a = 1; //Metodo publico y estatico que asigna 1 a la variable a (y no retorna nada)
    public int A1(int a) => A.a + a; //Metodo publico que recibe un entero y retorna otro
    public static int A2; //Variable de clase estática pública de tipo entero
    static int A3 => 3; //Propiedad de solo lectura
    private int A4() => 4; //Metodo privado que siempre retorna el entero 4
    public int A5 { get => 5; } //Propiedad publica de solo lectura que siempre retorna un 5
    int A6 { set => c = value; } //Propiedad de solo escritura que settea el valor de c
    public int A7 { get; set; } //Propiedad de lectura/escritura
    public int A8 { get; } = 8; //Propiedad de solo lectura
    public int this[int i] => i; //Indizador que retorna un entero pasado por parámetro
}
~~~

## 🟣 Punto 11

***¿Qué diferencia hay entre estas dos declaraciones?***

~~~c#
public int X = 3; // a)
public int X => 3; // b)
~~~

<details><summary> <code> click para ver resolución 🖱 </code></summary><br>

La diferencia entre ambas declaraciones es que la primera <code>public int X = 3;</code> es una variable pública de tipo entero a la cual se le asigna el 3 y la segunda <code>public int X => 3;</code> es una Propiedad de solo lectura que retorna un 3. 

</details>

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>