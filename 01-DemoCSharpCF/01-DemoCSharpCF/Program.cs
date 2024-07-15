// See https://aka.ms/new-console-template for more information


DateTime a = DateTime.UtcNow;
DateTime b = DateTime.Now;

Console.WriteLine(a);
Console.WriteLine(a.ToLocalTime());

Puntos Punto;
Punto = new Puntos();
Puntos.saluda();

class Puntos
{
    private double _x;
    private double _y;
    public double X
    {
        get { return _y; }
        set { _y = value; }
    }
    public double Y
    {
        get { return _x; }
        set { _x = value; }
    }

    public static void saluda()
    {
        Console.WriteLine("Ola K Ase");
        return;
    }
}


