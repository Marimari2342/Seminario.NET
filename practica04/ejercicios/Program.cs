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

            //Punto 6
            Ecuacion2 ec1 = new Ecuacion2(5, 2, 1);
            Console.WriteLine(ec1.GetDiscriminante());
            Console.WriteLine(ec1.GetCantidadDeRaices());
            ec1.ImprimirRaices();
            Ecuacion2 ec2 = new Ecuacion2(-1, 2, 1);
            Console.WriteLine(ec2.GetDiscriminante());
            Console.WriteLine(ec2.GetCantidadDeRaices());
            ec2.ImprimirRaices();
            Ecuacion2 ec3 = new Ecuacion2(1, 2, 1);
            Console.WriteLine(ec3.GetDiscriminante());
            Console.WriteLine(ec3.GetCantidadDeRaices());
            ec3.ImprimirRaices();

            //Punto 10
            Cuenta cuenta = new Cuenta();
            cuenta.Imprimir();
            cuenta = new Cuenta(30222111);
            cuenta.Imprimir();
            cuenta = new Cuenta("José Perez");
            cuenta.Imprimir();
            cuenta = new Cuenta("Maria Diaz", 20287544);
            cuenta.Imprimir();
            cuenta.Depositar(200);
            cuenta.Imprimir();
            cuenta.Extraer(150);
            cuenta.Imprimir();
            cuenta.Extraer(1500);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}