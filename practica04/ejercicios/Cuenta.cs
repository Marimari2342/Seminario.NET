namespace ejercicios;

public class Cuenta
{
    private double _monto;
    private int _titularDNI;
    private string? _titularNombre;

    //Constructores

    public Cuenta()
    {
        this._titularNombre = " ";
        this._titularDNI = 0;
        this._monto = 0;
    }

    public Cuenta (int dni)
    {
        this._titularNombre = " ";
        this._titularDNI = dni;
        this._monto = 0;
    }

    public Cuenta(string nombre)
    {
        this._titularNombre = nombre;
        this._titularDNI = 0;
        this._monto = 0;
    }

    public Cuenta(string nombre,int dni)
    {
        this._titularNombre = nombre;
        this._titularDNI = dni;
        this._monto = 0;
    }

    //Metodos
    public void Imprimir()
    {
        string aux = "No especificado";
        if (this._titularNombre == " " & this._titularDNI == 0)
        {
            Console.WriteLine("Nombre: {0}, DNI: {0}, Monto: {1}",aux,this._monto);
        }
        else if (this._titularNombre == " ")
        {
            Console.WriteLine("Nombre: {0}, DNI: {1}, Monto: {2}", aux, this._titularDNI,this._monto);
        }
        else if (this._titularDNI == 0)
        {
            Console.WriteLine("Nombre: {0}, DNI: {1}, Monto: {2}", this._titularNombre,aux, this._monto);
        }
        else
        {
            Console.WriteLine("Nombre: {0}, DNI: {1}, Monto: {2}", this._titularNombre, this._titularDNI, this._monto);
        }
    }

    public void Depositar(double monto)
    {
        this._monto += monto; 
    }

    public void Extraer(double monto)
    {
        if (monto<this._monto)
        {
            this._monto -= monto;
        }
        else
        {
            Console.WriteLine("Operación cancelada, monto insuficiente.");
        }
    }

}



/*Cuenta cuenta = new Cuenta();
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

class Cuenta
{
    private double _monto;
    private int _titularDNI;
    private string? _titularNobre;
}*/