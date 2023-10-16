class EditorGrafico
{

}

interface IGrafico
{
    public bool mover(int x, int y);
    public void dibujar();
}


class GraficoCompuesto: IGrafico
{
    private List<IGrafico> ListaGrafico;

    public void dibujar()
    {
        throw new NotImplementedException();
    }

    public bool mover(int x, int y)
    {
        throw new NotImplementedException();
    }
}

class Punto: IGrafico
{
    public int x {  get; private set; }
    public int y { get; private set; }

    void PuntoFun(int x, int y){
        
    }

    public bool mover(int x, int y){
        throw new NotImplementedException();
    }

    public void dibujar()
    {
        throw new NotImplementedException();
    }
}

class Circulo: Punto
{
    public int radio { get; private set; }

    void creaCirculo (int x, int y, int radio){

    }

}

class Rectangulo: Punto
{
    public int ancho { get; private set; }
    public int alto { get; private set; }

    public void creaRectangulo(int x, int y, int ancho, int alto){
        
    }

}