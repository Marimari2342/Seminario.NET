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
            if (datos != null)
            {
                string nombre = (string)datos.Split(",")[0];
                string edad = datos.Split(",")[1];
                string dni = datos.Split(",")[2];
                cant++;
                Persona p;
                p = new Persona(nombre, edad, dni);
                Console.WriteLine(p.Imprimir(cant));
            }
        }
    }
}