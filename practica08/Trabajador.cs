class Trabajador
{
    public EventHandler? Trabajando; //No es necesario definir un tipo delegado propio
    //porque la plataforma provee el tipo EventHandler
    //que se adecua a lo que se necesita
    public void Trabajar()
    {
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        Console.WriteLine("Trabajo concluido");
    }
}