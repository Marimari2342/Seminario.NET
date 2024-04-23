namespace practica05;
using System;
using System.Collections;

class Cuenta
{
    public static int Id { get; set; }
    public double TotalDep { get; set; }
    public static int CantDepositos { get; set; }
    public static int CantExtraciones { get; set; }
    public static int ExtDen { get; set; }
    private static double _monto_extracciones;
    private static double _monto_depositos;
    public int Id_cuenta { get; set; }

    public static List<Cuenta> lista {get;set;} = new List<Cuenta>();
    public Cuenta()
    {
        Id++;
        Id_cuenta = Id;
        lista.Add(this);
        Console.WriteLine($"Se creó la cuenta Id={Id_cuenta}");
    }

    public static List<Cuenta> GetCuentas()
    {
        List<Cuenta> aux = new List<Cuenta>();
        foreach (Cuenta obj in lista)
            aux.Add(obj);
        return aux;
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