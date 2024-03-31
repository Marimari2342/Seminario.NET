/*PUNTO 1 - CLASE PERSONA*/
namespace ejercicios;

public class Persona
{
    private string Nombre;
    private int Edad;
    private string DNI;

    public Persona(string unNombre, int unaEdad, string unDni)
    {
        Nombre = unNombre;
        Edad = unaEdad;
        DNI = unDni;
    }

    public string Imprimir(int num) =>
        $"{num+")",-5} {Nombre,-15} {Edad,-5} {DNI,-10}";

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
