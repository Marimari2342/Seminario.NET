namespace ejercicios;

public class Persona
{
    public string Nombre { get; set; }
    public char Sexo { get; set; }
    public int DNI { get; set; }
    public DateTime FechaNac { get; set; }

    public int Edad
    {
        get
        {
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - FechaNac.Year;
            if (hoy.Month < FechaNac.Month)
            {
                edad--;
            }
            else if (hoy.Month == FechaNac.Month)
            {
                if (hoy.Day < FechaNac.Day)
                {
                    edad--;
                }
            }
        }
    }

    public object this[int i]
    {
        get
        {
            if (i == 0) return Nombre;
            else if (i == 1) return Sexo;
            else if (i == 2) return DNI;
            else if (i == 3) return FechaNac;
            else return Edad;
        }
        set
        {
            if (i == 0) Nombre = (string)value;
            else if (i == 1) Sexo = (char)value;
            else if (i == 2) DNI = (int)value;
            else if (i == 3) FechaNac = (DateTime)value;
        }
    }
}

