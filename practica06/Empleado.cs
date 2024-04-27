internal class Program
{
    abstract class Empleado
    {
        //Propiedades
        public string Nombre { get; protected set; }
        public string DNI { get; protected set; }
        public DateType FechaDeIngreso { get; protected set; }
        public double SalarioBase { get; protected set; }
        public abstract double Salario { get; }
        public int Antiguedad
        {
            get
            {
                DateTime hoy = DateTime.Now;
                int antig = hoy.Year - FechaDeIngreso.Year;
                if (hoy.Month < FechaDeIngreso.Month)
                {
                    antig--;
                }
                else if (hoy.Month == FechaDeIngreso.Month)
                {
                    if (hoy.Day < FechaDeIngreso.Day)
                    {
                        antig--;
                    }
                }
                return antig;
            }
        }

        //Constructores
        public Empleado(string nombre, string dni, DateType ingreso, double base )
        {
            this.Nombre = nombre;
            this.DNI = dni;
            this.FechaDeIngreso = ingreso;
            this.SalarioBase = base;
        }

        //Metodos
        public abstract void AumentarSalario();
    }

    class Administrativo : Empleado
    {
        public double Premio { get; set; }
        public override double Salario { get { return Premio + SalarioBase; } }
        public override void AumentarSalario()
        {
            this.Salario += this.Salario * this.Antiguedad / 100;
        }
    }

    class Vendedor : Empleado
    {
        public double Comision { get; set; }
        public override double Salario { get { return Comision + SalarioBase; } }
        public override void AumentarSalario()
        {
            if (this.Antiguedad < 10)
            {
                this.Salario += this.Salario * 5 * this.Antiguedad / 100;
            }
            else
            {
                this.Salario += this.Salario * this.Antiguedad / 10;
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Punto8");
        Empleado[] empleados = new Empleado[] {
        new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
        new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
        new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
    };
        foreach (Empleado e in empleados)
        {
            Console.WriteLine(e);
            e.AumentarSalario();
            Console.WriteLine(e);
        }
    }
}
