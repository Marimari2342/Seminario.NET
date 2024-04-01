# .NET - Practica 4


## Punto 1
***Definir una clase Persona con 3 campos públicos: Nombre, Edad y DNI. Escribir un algoritmo que permita al usuario ingresar en una consola una serie de datos de esta forma:***

* **Nombre,Documento,Edad </ENTER/>.**

***Una vez finalizada la entrada de datos, el programa debe imprimir en la consola un listado con 4 columnas de la siguiente forma:***

![ImagenEjemplo](/../main/recursos/imagen6.png)

***NOTA: Se puede utilizar: Console.SetIn(new System.IO.StreamReader(nombreDeArchivo)); para cambiar la entrada estándar de la consola y poder leer directamente desde un archivo de texto.***

Armé un vector de personas, y la dimensión del vector la indico en la primer linea del archivo *personas.txt*. Esto no lo indica el ejercicio pero lo armé así para no sobreescribir la persona ya leida y armar una estructura, para poder luego usar en el punto 3 a la hora de comparar las edades.

~~~
StreamReader listaDatos = new System.IO.StreamReader("recursos/personas.txt");
int dF = int.Parse(listaDatos.ReadLine());
Persona[] vectorPersonas = new Persona[dF];
string? datos;

for (int i = 0; i < dF; i++)
{
    datos = listaDatos.ReadLine();
    string nombre = datos.Split(",")[0];
    int edad = Int32.Parse(datos.Split(",")[1]);
    string dni = datos.Split(",")[2];
    vectorPersonas[i] = new Persona(nombre, edad, dni, i + 1);
}
~~~


>[!NOTE]
>
> Punto 1 --> Contestado en *Persona.cs* y *Program.cs* (buscar archivos dentro de la carpeta [ejercicios](/practica04/ejercicios/)).

## Punto 2
***Modificar el programa anterior haciendo privados todos los campos. Definir un constructor adecuado y un método público Imprimir() que escriba en la consola los campos del objeto con el formato requerido para el listado.***

~~~
//CONSTRUCTOR

public Persona(string unNombre, int unaEdad, string unDni, int unNum)
{
    Nombre = unNombre;
    Edad = unaEdad;
    DNI = unDni;
    Num = unNum;
}
~~~

~~~
//METODO Imprimir()

public string Imprimir() =>
    $"{Num+")",-5} {Nombre,-15} {Edad,-5} {DNI,-10}";
~~~

>[!NOTE]
>
> Punto 2 --> Contestado en *Persona.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).

## Punto 3
***Agregar a la clase Persona un método EsMayorQue(Persona p) que devuelva verdadero si la persona que recibe el mensaje tiene más edad que la persona enviada como parámetro. Utilizarlo para realizar un programa que devuelva la persona más jóven de la lista.***

~~~
//METODO EsMayorQue(Persona p)

public bool EsMayorQue(Persona p) //Punto 3
{
    bool cumple = false;
    if (p.Edad < this.Edad)
    {
        cumple = true;
    }
    return cumple;
}
~~~

Buscar la persona más joven usando el método *EsMayorQue(p)*.
~~~
Persona masJoven = new Persona("", 100, "", 0);
for (int i = 0; i < dF; i++)
{
    if (masJoven.EsMayorQue(vectorPersonas[i]))
    {
        masJoven = vectorPersonas[i];
    }
}
Console.WriteLine("Persona más joven:");
Console.WriteLine(masJoven.Imprimir());
~~~


>[!NOTE]
>
> Punto 3 --> Contestado en *Persona.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).


## Punto 4
***Codificar la clase Hora de tal forma que el siguiente código produzca la salida por consola que se observa.***

![ImagenPantalla](/../main/recursos/imagen7.png)

En el programa principal:
~~~
Hora h = new Hora(23, 30, 15);
Console.WriteLine(h.Imprimir());
~~~

En la clase Hora:
~~~
namespace ejercicios;

public class Hora
{
    private int Horas;
    private int Minutos;
    private int Segundos;

    public Hora(int unaHora, int unMin, int unSeg)
    {
        Horas = unaHora;
        Minutos = unMin;
        Segundos = unSeg;
    }

    public string Imprimir() =>
        $"{Horas} horas, {Minutos} minutos y {Segundos} segundos";
}
~~~

>[!NOTE]
>
> Punto 4 --> Contestado en *Hora.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).


## Punto 5
***Agregar un segundo constructor a la clase Hora para que pueda especificarse la hora por medio de un único valor que admita decimales. Por ejemplo 3,5 indica la hora 3 y 30 minutos. Si se utiliza este segundo constructor, el método imprimir debe mostrar los segundos con tres dígitos decimales. Así el siguiente código debe producir la salida por consola que se observa.***

~~~
new Hora(23, 30, 15).Imprimir();
new Hora(14.43).Imprimir();
new Hora(14.45).Imprimir();
new Hora(14.45114).Imprimir();
~~~

![ImagenPantalla](/../main/recursos/imagen8.png)

Segundo Constructor:
~~~
public Hora(double hora)
{
    this.Horas = (int)hora;
    this.Minutos = (int)((hora - this.Horas) * 60);
    this.SegDec = (hora - (this.Horas + this.Minutos / 60.0)) * Math.Pow(60, 2);
    //Math.Pow(num, pot)--> eleva un numero a la potencia indicada en pot
}
~~~

También cambiamos el método imprimir, (lo pasamos de string a void pues tiene que devolver la hora sin necesidad de usar Console.WriteLine() en el programa principal).

~~~
public void Imprimir()
{
    if (this.SegDec == -1)
    {
        Console.WriteLine($"{this.Horas} horas, {this.Minutos} minutos y {this.Segundos} segundos");
    }
    else
    {
        Console.WriteLine($"{this.Horas} horas, {this.Minutos} minutos y {this.SegDec:0.000} segundos");
    }
}
~~~

>[!NOTE]
>
> Punto 5 --> Contestado en *Hora.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).


## Punto 6
***Codificar una clase llamada Ecuacion2 para representar una ecuación de 2º grado. Esta clase debe tener 3 campos privados, los coeficientes a, b y c de tipo double. La única forma de establecer los valores de estos campos será en el momento de la instanciación de un objeto Ecuacion2.***

~~~
public class Ecuacion2
{
    private double a;
    private double b;
    private double c;

    public Ecuacion2(double uno, double dos, double tres)
    {
        this.a = uno;
        this.b = dos;
        this.c = tres;
    }
}
~~~

***Codificar los siguientes métodos:***

* ***GetDiscriminante(): devuelve el valor del discriminante (double), el discriminante tiene la siguiente formula, (b^2)-4*a*c.***

~~~
public double GetDiscriminante()
{
    return Math.Pow(this.b, 2) - 4 * this.a * this.c;
}
~~~

* ***GetCantidadDeRaices(): devuelve 0, 1 ó 2 dependiendo de la cantidad de raíces reales que posee la ecuación. Si el discriminante es negativo no tiene raíces reales, si el discriminante es cero tiene una única raíz, si el discriminante es mayor que cero posee 2 raíces reales.***

~~~
public int GetCantidadDeRaices()
{
    return GetDiscriminante() < 0 ? 0 : GetDiscriminante() == 0 ? 1 : 2;
}
~~~

* ***ImprimirRaices(): imprime la única o las 2 posibles raíces reales de la ecuación. En caso de no poseer soluciones reales debe imprimir una leyenda que así lo especifique.***

~~~
public void ImprimirRaices()
{
    if (this.GetCantidadDeRaices() == 0)
    {
        Console.WriteLine("La ecuación cuadrática no tiene raices reales.");
    }
    else if (this.GetCantidadDeRaices() == 1)
    {
        double raiz = -this.b / 2 * this.a;
        Console.WriteLine("La ecuación tiene una raíz igual a:{0:0.00}", raiz);
    }
    else
    {
        double raiz1 = (-this.b + Math.Sqrt(this.GetDiscriminante())) / 2 * this.a;
        double raiz2 = (-this.b - Math.Sqrt(this.GetDiscriminante())) / 2 * this.a;
        Console.WriteLine("La ecuación tiene dos raices reales r1: {0:0.00} y r2: {1:0.00}", raiz1, raiz2);
    }
}
~~~

>[!NOTE]
>
> Punto 6 --> Contestado en *Ecuacion2.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).


## Punto 7
***Implementar la clase Matriz que se utilizará para trabajar con matrices matemáticas. Implementar los dos constructores y todos los métodos que se detallan a continuación:***

~~~
public Matriz(int filas, int columnas)
public Matriz(double[,] matriz)
public void SetElemento(int fila, int columna, double elemento)
public double GetElemento(int fila, int columna)
public void imprimir()
public void imprimir(string formatString)
public double[] GetFila(int fila)
public double[] GetColumna(int columna)
public double[] GetDiagonalPrincipal()
public double[] GetDiagonalSecundaria()
public double[][] getArregloDeArreglo()
public void sumarle(Matriz m)
public void restarle(Matriz m)
public void multiplicarPor(Matriz m)
~~~


## Punto 8
***Prestar atención a los siguientes programas (ninguno funciona correctamente). ¿Qué se puede decir acerca de la inicialización de los objetos? ¿En qué casos son inicializados
automáticamente y con qué valor?***

~~~
Foo f = new Foo();
f.Imprimir();
class Foo
{
    string? _bar;
    public void Imprimir()
    {
        Console.WriteLine(_bar.Length);
    }
}
~~~

~~~
Foo f = new Foo();
f.Imprimir();
class Foo
{
    public void Imprimir()
    {
        string? bar;
        Console.WriteLine(bar.Length);
    }
}
~~~


## Punto 9
***¿Qué se puede decir en relación a la sobrecarga de métodos en este ejemplo?***

~~~
class A
{
    public void Metodo(short n) {
        Console.Write("short {0} - ", n);
    }
    public void Metodo(int n) {
        Console.Write("int {0} - ", n);
    }
    public int Metodo(int n) {
        return n + 10;
    }
}
~~~

## Punto 10
***Completar la clase Cuenta para que el siguiente código produzca la salida indicada. Utilizar en la medida de lo posible la sintaxis :this en el encabezado de los constructores para invocar a otro constructor ya definido.***

~~~
Cuenta cuenta = new Cuenta();
cuenta.Imprimir();
cuenta = new Cuenta(30222111);
cuenta.Imprimir();
cuenta = new Cuenta("José Perez");
cuenta.Imprimir();
cuenta = new Cuenta("Maria Diaz", 20287544);
cuenta.Imprimir();
cuenta.Depositar(200);
cuenta.Imprimir();
cuenta.Extraer(150);
cuenta.Imprimir();
cuenta.Extraer(1500);

class Cuenta
{
    private double _monto;
    private int _titularDNI;
    private string? _titularNobre;
}
~~~

![ImagenPantalla](/../main/recursos/imagen9.png)


>[!NOTE]
>
> Punto 10 --> Contestado en *Cuenta.cs* y *Program.cs* (buscar archivos dentro de la carpeta ejercicios).

## Punto 11
***Reemplazar estas líneas de código por otras equivalentes que utilicen el operador null-coalescing (?? ) y / o la asignación null-coalescing (??=)***

~~~
...
if (st1 == null)
{
    if (st2 == null)
    {
        st = st3;
    }
    else
    {
        st = st2;
    }
}
else
{
    st = st1;
}
if (st4 == null)
{
    st4 = "valor por defecto";
}
...
~~~


## Punto 12
***Crear una solución con tres proyectos: una biblioteca de clases llamada Automotores, una biblioteca de clases llamada Figuras y una aplicación de consola llamada Aplicacion. La biblioteca Automotores debe contener una clase pública Auto (codificada de la misma manera que la vista en la teoría). La biblioteca Figuras debe contener las clases públicas Circulo y Rectangulo, codificadas de tal forma que el siguiente código (escrito en Program.cs del proyecto Aplicacion) produzca la siguiente salida***

![ImagenPantalla](/../main/recursos/imagen10.png)

~~~
using Figuras;
using Automotores;
//El constructor de Circulo espera recibir el radio
List<Circulo> listaCirculos = [
    new Circulo(1.1),
    new Circulo(3),
    new Circulo(3.2)
];
//El constructor de Rectángulo espera recibir la base y la altura
List<Rectangulo> listaRectangulos = [
    new Rectangulo(3, 4),
    new Rectangulo(4.3, 4.4)
];
//La clase Auto está codificada como la vista en la teoría
List<Auto> listaAutos = [
    new Auto("Nissan", 2017),
    new Auto("Ford", 2015),
    new Auto("Renault")
];

foreach (Circulo c in listaCirculos)
{
    Console.WriteLine($"Área del círculo {c.GetArea()}");
}
foreach (Rectangulo r in listaRectangulos)
{
    Console.WriteLine($"Área del rectángulo {r.GetArea()}");
}
foreach (Auto a in listaAutos)
{
    Console.WriteLine(a.GetDescripcion());
}
~~~

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>