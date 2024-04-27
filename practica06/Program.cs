
/*
internal class Program
{
    //PUNTO1
    /*class A
    {
        protected int _id; //variable _id
        public A(int id) => _id = id; //constructor que recibe valor id y lo guarda en _id
        public virtual void Imprimir() => Console.WriteLine($"A_{_id}"); //podemos sobreescribirlo por --> [virtual]
    }
    class B : A
    {
        public B(int id) : base(id) { }
        public override void Imprimir()
        {
            Console.Write($"B_{_id} --> ");
            base.Imprimir();
        }
    }
    class C : B
    {
        public C(int id) : base(id) { }
        public override void Imprimir()
        {
            Console.Write($"C_{_id} --> ");
            base.Imprimir();
        }
    }
    class D : C
    {
        public D(int id) : base(id) { }
        public override void Imprimir()
        {
            Console.Write($"D_{_id} --> ");
            base.Imprimir();
        }
    }*/

    //PUNTO4
    /*class Auto
    {
        public string Marca { get; private set; } = "Ford";
        public Auto(string marca) => this.Marca = marca;
        public Auto() { }
    }
    class Taxi : Auto
    {
        public int Pasajeros { get; private set; }
        public Taxi(int pasajeros) : base("Chevrolet") => this.Pasajeros = pasajeros;
    }*/

    /*class Persona
    {
        public string Nombre { get; set; }
    }
    public class Auto
    {
        private Persona _dueño1, _dueño2;
        public Persona GetPrimerDueño() => _dueño1;
        protected Persona SegundoDueño
        {
            set => _dueño2 = value;
        }
    }*/

    
/*
    abstract class ClaseMadre
    {
        public abstract void Imprimir();
    }
    class A : ClaseMadre
    {
        public override void Imprimir() => Console.WriteLine("Soy una instancia A");
    }
    class B : ClaseMadre
    {
        public override void Imprimir() => Console.WriteLine("Soy una instancia B");
    }
    class C : ClaseMadre
    {
        public override void Imprimir() => Console.WriteLine("Soy una instancia C");
    }
    class D : ClaseMadre
    {
        public override void Imprimir() => Console.WriteLine("Soy una instancia D");
    }
    static class Imprimidor
    {
        public static void Imprimir(params object [] vector)
        {
            foreach (ClaseMadre aux in vector)
            {
                aux.Imprimir();
            }
        }
    }

    private static void Main(string[] args)
    {
        /*A[] vector = [new A(3), new B(5), new C(15), new D(41)];
        foreach (A a in vector)
        {
            a.Imprimir();
        }*/

        /*Console.WriteLine("Punto2");
        A[] vector = [new C(1), new D(2), new B(3), new D(4), new B(5)];
        foreach (A a in vector)
        {
            if (a is B && a is not C && a is not D)
            {
                a.Imprimir();
            }
        }*/

        /*Console.WriteLine("Punto2b");
        A[] vector = [new C(1), new D(2), new B(3), new D(4), new B(5)];
        foreach (A a in vector)
        {
            Type tipo = a.GetType();
            if (tipo.Equals(typeof(B)))
            {
                a.Imprimir();
            }
        }*/

        /*Console.WriteLine("Punto4");
        Taxi t = new Taxi(3);
        Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");*/
/*
        Imprimidor.Imprimir(new A(), new B(), new C(), new D());
    }
}*/

