﻿internal class Program
{
    //Interfaces
    /*alquilables   vendibles   lavables    reciclables     atendibles*/
    interface IAlquilable
    {
        void SeAlquilaA(Persona p);
        void SeDevuelvePor(Persona p);
    }

    interface IVendible
    {
        void SeVendeA(Persona p);
    }

    interface ILavable
    {
        void SeLava();
        void SeSeca();
    }

    interface IReciclable
    {
        void SeRecicla();
    }

    interface IAtendible
    {
        void SeAtiende();
    }

    //Clases
    /*Libros    Peliculas   Autos   Perros  Personas*/
    class Libro : IAlquilable, IReciclable
    {
        public void SeAlquilaA(Persona p)
        {
            Console.WriteLine("Alquilando libro a persona");
        }
        public void SeDevuelvePor(Persona p)
        {
            Console.WriteLine("Libro devuelto por persona");
        }
        public void SeRecicla()
        {
            Console.WriteLine("Reciclando libro");
        }
    }

    class Pelicula : IAlquilable
    {
        //PUNTO2 --> Agrego "virtual" así puedo modificar el método desde la clase que hereda
        public virtual void SeAlquilaA(Persona p) 
        {
            Console.WriteLine("Alquilando película a persona");
        }
        public virtual void SeDevuelvePor(Persona p)
        {
            Console.WriteLine("Película devuelta por persona");
        }
    }

    //PUNTO2 --> PeliculaClásica derivada de Pelicula
    class PeliculaClasica : Pelicula, IVendible
    {
        public override void SeAlquilaA(Persona p)
        {
            Console.WriteLine("Alquilando película clásica a persona");
        }
        public override void SeDevuelvePor(Persona p)
        {
            Console.WriteLine("Película clásica devuelta por persona");
        }
        public void SeVendeA(Persona p)
        {
            Console.WriteLine("Vendiendo película clásica a persona");
        }
    }
    //

    class Auto : IVendible, ILavable, IReciclable
    {
        public void SeVendeA(Persona p)
        {
            Console.WriteLine("Vendiendo auto a persona");
        }
        public void SeLava()
        {
            Console.WriteLine("Lavando auto");
        }
        public void SeSeca()
        {
            Console.WriteLine("Secando Auto");
        }
        public void SeRecicla()
        {
            Console.WriteLine("Reciclando auto");
        }
    }

    class Perro : IVendible, IAtendible, ILavable
    {
        public void SeVendeA(Persona p)
        {
            Console.WriteLine("Vendiendo perro a persona");
        }
        public void SeAtiende()
        {
            Console.WriteLine("Atendiendo perro");
        }
        //PUNTO2 --> Incorporar la posibilidad de lavar a los perros
        public void SeLava()
        {
            Console.WriteLine("Lavando perro");
        }
        public void SeSeca()
        {
            Console.WriteLine("Secando perro");
        }
        //
    }

    class Persona : IAtendible
    {
        public void SeAtiende()
        {
            Console.WriteLine("Atendiendo persona");
        }
    }

    //Procesador
    static class Procesador
    {
        public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
        public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelvePor(p);
        public static void Vender(IVendible x, Persona p) => x.SeVendeA(p);
        public static void Lavar(ILavable x) => x.SeLava();
        public static void Secar(ILavable x) => x.SeSeca();
        public static void Reciclar(IReciclable x) => x.SeRecicla();
        public static void Atender(IAtendible x) => x.SeAtiende();
    }

    //Main
    private static void Main(string[] args)
    {
        Auto auto = new Auto();
        Libro libro = new Libro();
        Persona persona = new Persona();
        Perro perro = new Perro();
        Pelicula pelicula = new Pelicula();
        Procesador.Alquilar(pelicula, persona);
        Procesador.Alquilar(libro, persona);
        Procesador.Atender(persona);
        Procesador.Atender(perro);
        Procesador.Devolver(pelicula, persona);
        Procesador.Devolver(libro, persona);
        Procesador.Lavar(auto);
        Procesador.Reciclar(libro);
        Procesador.Reciclar(auto);
        Procesador.Secar(auto);
        Procesador.Vender(auto, persona);
        Procesador.Vender(perro, persona);
        //PUNTO2
        PeliculaClasica peliculaClasica = new PeliculaClasica();
        Procesador.Alquilar(peliculaClasica, persona);
        Procesador.Devolver(peliculaClasica, persona);
        Procesador.Vender(peliculaClasica, persona);
    }
}