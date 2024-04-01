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

