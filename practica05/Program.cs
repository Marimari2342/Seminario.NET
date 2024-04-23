﻿using practica05;
internal class Program

{

    private static void Main(string[] args)
    {
        //Punto1
        /*Cuenta c1 = new Cuenta();
        c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
        Cuenta c2 = new Cuenta();
        c2.Depositar(200).Depositar(800);
        new Cuenta().Depositar(20).Extraer(20);
        c2.Extraer(1000).Extraer(1);
        Console.WriteLine("\nDETALLE");
        Cuenta.ImprimirDetalle();*/

        //Punto2
        new Cuenta();
        new Cuenta();
        List<Cuenta> cuentas = Cuenta.GetCuentas();
        // se recuperó la lista de cuentas creadas
        cuentas[0].Depositar(50);
        // se depositó 50 en la primera cuenta de la lista devuelta
        cuentas.RemoveAt(0);
        Console.WriteLine(cuentas.Count);
        // se borró un elemento de la lista devuelta
        // pero la clase Cuenta sigue manteniendo todos
        // los datos "La cuenta id: 1 tiene 50 de saldo"
        cuentas = Cuenta.GetCuentas();
        // se recuperó nuevamente la lista de cuentas
        Console.WriteLine(cuentas.Count);
        cuentas[0].Extraer(30);
        //se extrajo 30 de la cuenta id: 1 que tenía 50 de saldo
    }
}