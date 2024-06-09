class Trabajador
{
    public EventHandler? Trabajando = (object sender, EventArgs e) => Console.WriteLine("Se inició el trabajo");

    public void Trabajar()
    {
        if (Trabajando != null)
        {
            Trabajando(this, EventArgs.Empty);
            //realiza algún trabajo
            Console.WriteLine("Trabajo concluido");
        }
    }
}

