using ejercicios;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            //Punto 1 y 2
            StreamReader listaDatos = new System.IO.StreamReader("recursos/personas.txt");
            int dF = int.Parse(listaDatos.ReadLine());
            Persona[] vectorPersonas = new Persona[dF];
            string? datos;

            for (int i = 0; i < dF; i++)
            {
                datos = listaDatos.ReadLine();
                string nombre = datos.Split(",")[0];
                int edad = Int32.Parse(datos.Split(",")[1]);
                string dni = datos.Split(",")[2];
                vectorPersonas[i] = new Persona(nombre, edad, dni, i + 1);
            }

            for (int i = 0; i < dF; i++)
            {
                Console.WriteLine(vectorPersonas[i].Imprimir());
            }
            //Punto 3
            Console.WriteLine(vectorPersonas[0].EsMayorQue(vectorPersonas[1]));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}