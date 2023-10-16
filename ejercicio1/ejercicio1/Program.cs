
class EditorGrafico
{
    static void Main (){
        Console.WriteLine("Editor grafico");

        var punto = new Punto (100,100);
        var rectangulo = new Rectangulo (200,200,50,80);
        var circulo = new Circulo (300,300,30);

        var graficoCompuesto = new GraficoCompuesto();
        graficoCompuesto.AgregarGrafico(punto);
        graficoCompuesto.AgregarGrafico(rectangulo);
        graficoCompuesto.AgregarGrafico(circulo);

        Console.WriteLine("Grafico Creado:");
        graficoCompuesto.dibujar();

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Acciones:");
            Console.WriteLine("1. Mover el gráfico");
            Console.WriteLine("2. Salir.");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la nueva coordenada X: ");
                    int newX = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la nueva coordenada Y: ");
                    int newY = int.Parse(Console.ReadLine());

                    if (graficoCompuesto.mover(newX, newY))
                    {
                        Console.WriteLine("Gráfico movido con éxito.");
                        graficoCompuesto.dibujar();
                    }
                    else
                    {
                        Console.WriteLine("El Gráfico está fuera de la pantalla (800x600).");
                    }
                    break;
                case "2":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
    }
}

interface IGrafico
{
    bool mover(int x, int y);
    void dibujar();
}


class GraficoCompuesto: IGrafico
{
    private List<IGrafico> ListaGrafico = new List<IGrafico>();

    public void AgregarGrafico(IGrafico grafico)
    {
        ListaGrafico.Add(grafico);
    }

    public void dibujar()
    {
        foreach (var grafico in ListaGrafico)
        {
            grafico.dibujar();
        }
    }

    public bool mover(int x, int y)
    {
        foreach( var grafico in ListaGrafico)
        {
            if(!grafico.mover(x,y)){
                return false;
            }
        }
        return true;
    }
}

class Punto: IGrafico
{
    public int X {  get; protected set; }
    public int Y { get; protected set; }

    public Punto(int x, int y)
    {
        X = x;
        Y = y;
    }
    public bool mover(int x, int y)
    {
        if (EsValido(x, y))
        {
            X = x;
            Y =y;
            return true;
        }
        return false;
    }

    public void dibujar()
    {
        Console.WriteLine($"Punto en ({X}, {Y})");
    }

    protected  bool EsValido (int x, int y)
    {
        return x >= 0 && x <= 800 && y >= 0 && y <= 600;
    }
}

class Circulo : Punto
{
    public int Radio { get; private set; }

    public Circulo(int x, int y, int radio) : base(x, y)
    {
        Radio = radio;
    }

    public new bool Mover(int x, int y)
    {
        if (base.EsValido(x, y))
        {
            X = x;
            Y = y;
            return true;
        }
        return false;
    }

    public new void Dibujar()
    {
        Console.WriteLine($"Circulo en ({X}, {Y}) con radio {Radio}");
    }
}
class Rectangulo : Punto
{
    public int Ancho { get; private set; }
    public int Alto { get; private set; }

    public Rectangulo(int x, int y, int ancho, int alto) : base(x, y)
    {
        Ancho = ancho;
        Alto = alto;
    }

    public new bool Mover(int x, int y)
    {
        if (base.EsValido(x, y) && base.EsValido(x + Ancho, y + Alto))
        {
            X = x;
            Y = y;
            return true;
        }
        return false;
    }

    public new void Dibujar()
    {
        Console.WriteLine($"Rectangulo en ({X}, {Y}) con ancho {Ancho} y alto {Alto}");
    }
}

}