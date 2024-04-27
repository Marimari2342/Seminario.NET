//Interfaces
/*alquilables   vendibles   lavables    reciclables     atendibles*/
interface IAlquilables
{
    void esAlquilada();
    void esDevuelta();
}

interface IVendibles
{
    void esVendida();
}

interface ILavables
{
    void esLavada();
    void esSecada();
}

interface IReciclables
{
    void esReciclada();
}

interface IAtendibles
{
    void esAtendida();
}

//Clases
/*Libros    Peliculas   Autos   Perros  Personas*/
class Libro : IAlquilables, IReciclables
{
    public void esAlquilada()
    {
        Console.WriteLine("Alquilando libro a persona");
    }
    public void esDevuelta()
    {
        Console.WriteLine("Libro devuelto por persona");
    }
    public void esReciclada()
    {
        Console.WriteLine("Reciclando libro");
    }
}

class Pelicula : IAlquilables
{
    public void esAlquilada()
    {
        Console.WriteLine("Alquilando película a persona");
    }
    public void esDevuelta()
    {
        Console.WriteLine("Película devuelta por persona");
    }
}
//Main

