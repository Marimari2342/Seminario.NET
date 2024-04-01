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

            //Punto 7
            Matriz m1 = new Matriz(2, 3); //2x3
            double[,] aux1 = new double[,] { { 6, 5, 4 }, { 3, 2, 1 } }; //2x3
            Matriz m2 = new Matriz(aux1);
            double[,] aux2 = new double[,] { { 1, 2 }, { 3, 4 } }; //2x2
            Matriz m3 = new Matriz(aux2);
            m1.SetElemento(0, 0, 5);
            m1.SetElemento(0, 1, 3);
            m3.GetElemento(0, 0);
            m1.Imprimir();
            m2.Imprimir();
            m3.Imprimir("0.00");
            m1.Sumarle(m2);
            m1.restarle(m2);
            m1.Sumarle(m3);
            m1.restarle(m3);
            m1.Imprimir();
            m2.Imprimir();
            m1.multiplicarPor(m2);
            m3.multiplicarPor(m2);
            double[] fila = m1.GetFila(0);
            double[] columna = m2.GetColumna(0);
            double[] diagP = m3.GetDiagonalPrincipal();
            double[] diagS = m3.GetDiagonalSecundaria();
            double[][] arrDeArr = m3.GetArregloDeArreglo();

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