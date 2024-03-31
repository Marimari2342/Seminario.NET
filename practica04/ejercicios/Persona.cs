/*PUNTO 1 - CLASE PERSONA*/
namespace ejercicios;

public class Persona
{
    private string Nombre;
    private int Edad;
    private string DNI;
    private int Num;

    public Persona(string unNombre, int unaEdad, string unDni, int unNum)
    {
        Nombre = unNombre;
        Edad = unaEdad;
        DNI = unDni;
        Num = unNum;
    }

    public Persona()
    {
        Nombre = " ";
        Edad = 0;
        DNI = " ";
        Num = 0;
    }

    public string Imprimir() =>
        $"{Num+")",-5} {Nombre,-15} {Edad,-5} {DNI,-10}";

    public bool EsMayorQue(Persona p) //Punto 3
    {
        bool cumple = false;
        if (p.Edad < this.Edad)
        {
            cumple = true;
        }
        return cumple;
    }

}
