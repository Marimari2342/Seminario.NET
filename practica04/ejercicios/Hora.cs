namespace ejercicios;

public class Hora
{
    private int Horas;
    private int Minutos;
    private int Segundos;
    private double SegDec = -1;

    public Hora(int unaHora, int unMin, int unSeg)
    {
        this.Horas = unaHora;
        this.Minutos = unMin;
        this.Segundos = unSeg;
    }

    public Hora(double hora)
    {
        this.Horas = (int)hora;
        this.Minutos = (int)((hora - this.Horas) * 60);
        this.SegDec = (hora - (this.Horas + this.Minutos / 60.0)) * Math.Pow(60, 2);
        //Math.Pow(num, pot)--> eleva un numero a la potencia indicada en pot
    }

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
}


