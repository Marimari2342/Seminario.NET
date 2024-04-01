using System.Runtime.CompilerServices;

namespace ejercicios;

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

    //METODOS

    public double GetDiscriminante()
    {
        return Math.Pow(this.b, 2) - 4 * this.a * this.c;
    }

    public int GetCantidadDeRaices()
    {
        return GetDiscriminante() < 0 ? 0 : GetDiscriminante() == 0 ? 1 : 2;
    }

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
}
