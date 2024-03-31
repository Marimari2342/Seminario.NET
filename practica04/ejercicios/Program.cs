/*PUNTO 1 - 2 */
using ejercicios;

internal class Program
{
    private static void Main(string[] args)
    {
        string? datos = " ";
        int cant = 0;
        //datos = Console.SetIn(new System.IO.StreamReader("recursos/personas.txt"));
        while (datos != "FIN")
        {
            Console.WriteLine("Ingrese nombre, edad y DNI separados por una coma, o FIN para salir");
            datos = Console.ReadLine();
            if (datos != "FIN" && datos != null)
            {
                string nombre = (string)datos.Split(",")[0];
                int edad = Int32.Parse(datos.Split(",")[1]);
                string dni = datos.Split(",")[2];
                cant++;
                Persona p;
                p = new Persona(nombre, edad, dni);
                Console.WriteLine(p.ObtenerDescripcion(cant));
            }
            //Punto 3
            Persona p2 = new Persona("Juana", 15, "47839248");
            Persona p3 = new Persona("Lucrecia", 17, "46521895");
            Console.WriteLine(p2.ObtenerDescripcion(1));
            Console.WriteLine(p3.ObtenerDescripcion(2));
            Console.WriteLine(p2.EsMayorQue(p3));
        }
        }
    }
}