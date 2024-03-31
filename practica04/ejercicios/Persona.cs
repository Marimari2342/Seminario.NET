/*PUNTO 1 - CLASE PERSONA*/
namespace ejercicios;

public class Persona
{
    string Nombre;
    string Edad;
    string DNI;

    public Persona(string unNombre, string unaEdad, string unDni)
    {
        Nombre = unNombre;
        Edad = unaEdad;
        DNI = unDni;
    }

    public string ObtenerDescripcion(int num) =>
        $"{num+")",-5} {Nombre,-15} {Edad,-5} {DNI,-10}";

}
