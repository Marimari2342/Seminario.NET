

internal class Program
{
    //PUNTO1
    class A
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
    }
    private static void Main(string[] args)
    {
        /*A[] vector = [new A(3), new B(5), new C(15), new D(41)];
        foreach (A a in vector)
        {
            a.Imprimir();
        }*/
        Console.WriteLine("Punto2");
        A[] vector = [new C(1), new D(2), new B(3), new D(4), new B(5)];
        foreach (A a in vector)
        {
            if (a is B && a is not C && a is not D)
            {
                a.Imprimir();
            }
        }
    }
}

