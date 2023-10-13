// See https://aka.ms/new-console-template for more information
var circulo = new Circulo(100, 200, 50); // prueba de la clase Círculo
circulo.Mover(300, 500); 
var rectangulo = new Rectangulo(100, 200, 50, 25); //prueba de la clase Rectángulo
var punto = new Punto(60, 80); // pureba de la clase Punto
var compuesto = new GraficoCompuesto(); // prueba de la clase GraficoCompuesto
compuesto.añadirGraficos(rectangulo);
compuesto.añadirGraficos(circulo);
Console.WriteLine(compuesto.Dibujar());
var miEditor = new EditorGrafico(); // prueba de la clase EditorGrafico
miEditor.graficosEditor(punto);
miEditor.graficosEditor(compuesto);
Console.WriteLine(miEditor.dibujar());

internal class EditorGrafico  //clase EditorGrafico 
{
    protected List<IGrafico> listaGraficos {  get; set; }
    protected int ancho = 800;
    protected int alto = 600;
   public void graficosEditor (IGrafico grafico)  // metodo para añadir gráficos al editor 
    {
        this.listaGraficos.Add(grafico);
    }
    public string dibujar()  // método para mostrar todos los gráficos de nuestro editor 
    {
        var muestraEditor = "";
        for (int i = 0; i  < listaGraficos.Count; i++)
        {
            muestraEditor += listaGraficos[i].Dibujar() + "\n ";
        }
        return muestraEditor;
    }
}

interface IGrafico  // interfaz IGrafico
{
    public bool Mover(int x, int y);
    public string Dibujar();
}
internal class Punto : IGrafico  // clase  Punto
{
    protected int x
    {
        get => x;
        set
        {
            if (value >= 0 && value <= 800)
            {
                x = value;  // si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor pedimos un nuevo valor que sea válido
                Console.WriteLine("El parámetro indicado se encuentra fuera de los límites del editor, introduzca un valor entre 0 y 800");
                x = int.Parse(Console.ReadLine());
            }
        }
    }
    protected int y
    {
        get => y;
        set
        {
            if (value >= 0 && value <= 600)
            {
                y = value; // si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor pedimos un nuevo valor que sea válido
                Console.WriteLine("El parámetro indicado se encuentra fuera de los límites del editor, introduzca un valor entre 0 y 800");
                y = int.Parse(Console.ReadLine());
            }
        }
    }
    public Punto (int x, int y) // constructor de la clase
    {
        this.x = x;
        this.y = y;
    }
    public string Dibujar() // método dibujar 
    {
       return this.x + " : " + this.y;
    }
    public bool Mover(int x, int y) // método mover 
    {
        if (x > 800)
        {
            return false;
        }
        else if (y > 600)
        {
            return false;
        }
        else if ((x & y) < 0)
        {
            return false;
        }
        else  // si el movimiento es posible se cambian los atributos "x" e "y" del objeto 
        {
            this.x = x;
            this.y = y;
            return true;
        }
    }
}
internal class Circulo : Punto
{
    protected int Radio
    {
        get => Radio;
        set
        {
            if (value-this.x >= 0 && value+this.Radio <= 800)
            {
                Radio = value;// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            {// si al crear o modificar el atributo está fuera de los límites del editor pedimos un nuevo valor que sea válido
                Console.WriteLine("El parámetro indicado se encuentra fuera de los límites del editor, introduzca un valor dentro de los límites del editor");
                Radio = int.Parse(Console.ReadLine());
            }
        }
    }
    public Circulo(int x, int y, int radio) : base(x, y) //contructor de la clase 
    {
        this.x = x;
        this.y = y;
        Radio = radio;
    }
    
    new public bool  Mover(int x, int y) // método mover 
    {
        
        if ((x + this.Radio) > 800)
        {
            return false;
        }
        else if ((x - this.Radio) < 0)
        {
            return false;
        }
        else if ((y + this.Radio) > 600)
        {
            return false;
        }
        else if ((y - this.Radio) < 0)
        {
            return false;
        }
        else // si el movimiento es posible se cambian los atributos "x" e "y" del objeto 
        {
            this.x = x;
            this.y = y;
            return true;
        }
              
    }
    new public string Dibujar() // método dibujar de la clase
    {       
        return base.Dibujar()+" :" + this.Radio;
    }
}
internal class Rectangulo : Punto // clase Rectángulo 
{
    protected int Ancho
    {
        get => Ancho;
        set
        {
            if (value + this.x < 800) { Ancho = value; }// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor pedimos un nuevo valor que sea válido
                Console.WriteLine("El ancho indicado excede los límites del editor, introduzca un valor nuevo");
                Ancho = int.Parse(Console.ReadLine());
            }
        }
    }
    protected int  Alto
    {
        get => Alto;
        set
        {
            if (this.y - value > 0) { Alto = value; }// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            else
            {// si al crear o modificar el atributo está fuera de los límites del editor pedimos un nuevo valor que sea válido
                Console.WriteLine("El alto indicado excede los límites del editor, introduzca un valor nuevo");
                Alto = int.Parse(Console.ReadLine());
            }
        }
    }
    public Rectangulo(int x, int y, int ancho, int alto) : base(x, y) // constructor de la clase 
    {
        this.x = x;
        this.y = y;
        Ancho = ancho;
        Alto = alto;
    }
    new public bool Mover(int x, int y) // método mover
    {
        if ((x + Ancho) > 800)
        {
            return false;
        }
        else if ((y - Alto) < 0)
        {
            return false;
        }
        else if(!base.Mover(x,y))
        {
            return false;
        }
        else
        {  // si el movimiento es posible se cambian los atributos "x" e "y" del objeto 
            this.x = x;
            this.y = y;
            return true;
        }
    }
    new public string Dibujar() // método dibujar 
    {  
       return base.Dibujar() + " : " + this.Alto + " : " + this.Ancho;
    }
}

internal class GraficoCompuesto : IGrafico // clase GraficoCompuesto
{
    protected List<IGrafico> componentes = new List<IGrafico>();
    public string Dibujar() // metodo dibujar 
    {
        var  muestraComponentes = "";
        for(int i = 0; i < componentes.Count; i++)
        {
            muestraComponentes += componentes[i].Dibujar()+"\n";
        }
        return muestraComponentes;
    }

    new public bool Mover(int x,int y) // metodo mover 
    {
        var movimiento = true;
        var xx = 0;
        var yy = 0;
        for (int i = 0; i < componentes.Count; i++) // por cada gráfico que lo componen llamamos al método mover de la clase correpondiente 
        {
            Console.WriteLine("Introduzca las coordenadas donde mover el elemento");// pedimos las nuevas coordenadas de cada objeto 
            xx = int.Parse(Console.ReadLine());
            yy = int.Parse(Console.ReadLine());
            movimiento = componentes[i].Mover(xx, yy); // llamada al método mover de cada clase 
            if (movimiento == false) {
                return movimiento;
                break;
            }
        }
        return movimiento;   
    }
    public void añadirGraficos(IGrafico grafico) // método para añadir gráficos a la clase 
    {
        this.componentes.Add(grafico);
        Console.WriteLine("Gráfico añadido");
    }
}