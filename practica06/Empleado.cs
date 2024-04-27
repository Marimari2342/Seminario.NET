internal class Program
{
    abstract class Empleado
    {
        //Propiedades
        public string Nombre { get; protected set; }
        public int DNI { get; protected set; }
        public DateTime FechaDeIngreso { get; protected set; }
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
        public Empleado(string nombre, int dni, DateTime ingreso, double salBase)
        {
            this.Nombre = nombre;
            this.DNI = dni;
            this.FechaDeIngreso = ingreso;
            this.SalarioBase = salBase;
        }

        //Metodos
        public abstract void AumentarSalario();
        public override string ToString()
        {
            return $"Nombre: {Nombre}, DNI: {DNI} Antiguedad: {Antiguedad} \nSalario Base: {SalarioBase}, ";
        }
    }

    class Administrativo : Empleado
    {
        //Propiedades
        public double Premio { get; set; }
        public override double Salario { get { return Premio + SalarioBase; } }

        //Constructores
        public Administrativo(string nombre, int dni, DateTime ingreso, double salBase) : base(nombre, dni, ingreso, salBase) { }

        //Metodos
        public override void AumentarSalario()
        {
            this.SalarioBase += this.SalarioBase * this.Antiguedad / 100;
        }
        public override string ToString()
        {
            return "Administrativo" + base.ToString() + $"Salario: {Salario} \n-------------";
        }
    }

    class Vendedor : Empleado
    {
        //Propiedades
        public double Comision { get; set; }
        public override double Salario { get { return Comision + SalarioBase; } }

        //Constructores
        public Vendedor(string nombre, int dni, DateTime ingreso, double salBase) : base(nombre, dni, ingreso, salBase) { }

        //Metodos
        public override void AumentarSalario()
        {
            if (this.Antiguedad < 10)
            {
                this.SalarioBase += this.SalarioBase * 5 * this.Antiguedad / 100;
            }
            else
            {
                this.SalarioBase += this.SalarioBase * this.Antiguedad / 10;
            }
        }
        public override string ToString()
        {
            return "Vendedor" + base.ToString() + $"Salario: {Salario} \n-------------";
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
