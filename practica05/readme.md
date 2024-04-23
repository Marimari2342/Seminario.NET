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

<br>
<br>
<br>


<p><img align="center" src="https://github.com/Marimari2342/Marimari2342/blob/main/firmagith.png" alt="marigit"/></p>