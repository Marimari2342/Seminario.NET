//Interfaces
/*alquilables   vendibles   lavables    reciclables     atendibles*/
interface IAlquilables
{
    void SeAlquilaA(Persona p);
    void SeDevuelveA(Persona p);
}

interface IVendibles
{
    void SeVendeA(Persona p);
}

interface ILavables
{
    void SeLava();
    void SeSeca();
}

interface IReciclables
{
    void SeRecicla();
}

interface IAtendibles
{
    void SeAtiende();
}

//Clases
/*Libros    Peliculas   Autos   Perros  Personas*/
class Libro : IAlquilables, IReciclables
{
    public void SeAlquilaA(Persona p)
    {
        Console.WriteLine("Alquilando libro a persona");
    }
    public void SeDevuelveA(Persona p)
    {
        Console.WriteLine("Libro devuelto por persona");
    }
    public void SeRecicla()
    {
        Console.WriteLine("Reciclando libro");
    }
}

class Pelicula : IAlquilables
{
    public void SeAlquilaA(Persona p)
    {
        Console.WriteLine("Alquilando película a persona");
    }
    public void SeDevuelveA(Persona p)
    {
        Console.WriteLine("Película devuelta por persona");
    }
}

class Auto : IVendibles, ILavables, IReciclables
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

class Perro : IVendibles, IAtendibles
{
    public void SeVendeA(Persona p)
    {
        Console.WriteLine("Vendiendo perro a persona");
    }
    public void SeAtiende()
    {
        Console.WriteLine("Atendiendo perro");
    }
}

class Persona : IAtendibles
{
    public void SeAtiende()
    {
        Console.WriteLine("Atendiendo persona");
    }
}
//Main

