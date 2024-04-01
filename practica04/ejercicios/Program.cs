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
            Persona masJoven = new Persona("", 100, "", 0);
            for (int i = 0; i < dF; i++)
            {
                if (masJoven.EsMayorQue(vectorPersonas[i]))
                {
                    masJoven = vectorPersonas[i];
                }
            }
            Console.WriteLine("Persona más joven:");
            Console.WriteLine(masJoven.Imprimir());

            //Punto 4
            Hora h = new Hora(23, 30, 15);
            h.Imprimir();
            //Punto 5
            new Hora(23, 30, 15).Imprimir();
            new Hora(14.43).Imprimir();
            new Hora(14.45).Imprimir();
            new Hora(14.45114).Imprimir();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}