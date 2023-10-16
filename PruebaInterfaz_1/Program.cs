// See https://aka.ms/new-console-template for more information

int x;
int y;
int radio;
int alto;
int ancho;
Console.WriteLine("Bienvenido al editor gráfico: a continuación se le pedirá que introduzca los datos de los gráficos que desee crear ");
Console.WriteLine("A continuación se creará un grafico compuesto con un punto, un círculo y un rectángulo");
try
{
    //creamos el punto
    ConsoleHelper.ShowMessage("punto");
    ConsoleHelper.ShowMessage("x");
    x = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("y");
    y = ConsoleHelper.ReadInput();
    Punto punto;
    punto = new Punto(x, y); // prueba de la clase Punto con los valores tomados por consola

    //creamos el círculo
    ConsoleHelper.ShowMessage("círculo");
    ConsoleHelper.ShowMessage("x");
    x = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("y");
    y = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("radio");
    radio = ConsoleHelper.ReadInput();
    Circulo circulo;
    circulo = new Circulo(x, y, radio); // prueba de la clase círculo con los datos tomados por consola

    //creamos el rectángulo
    ConsoleHelper.ShowMessage("rectángulo");
    ConsoleHelper.ShowMessage("x");
    x = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("y");
    y = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("ancho");
    ancho = ConsoleHelper.ReadInput();
    ConsoleHelper.ShowMessage("alto");
    alto = ConsoleHelper.ReadInput();
    Rectangulo rectangulo;
    rectangulo = new Rectangulo(x, y, ancho, alto); // prueba de la clase rectángulo con los datos tomados por consola

    // añadimos los gráficos creados a la clase GraficoCompuesto
    GraficoCompuesto compuesto;
    compuesto = new GraficoCompuesto();
    compuesto.añadirGraficos(rectangulo);
    compuesto.añadirGraficos(circulo);
    compuesto.añadirGraficos(punto);

    // añadimos el grafico compuesto al editor y lo dibujamos
    EditorGrafico miEditor;
    miEditor = new EditorGrafico(); // prueba de la clase EditorGrafico
    miEditor.graficosEditor(compuesto);
    Console.WriteLine(compuesto.Dibujar());

    int opcion;
    Console.WriteLine("Elija que desea hacer: ");
    Console.WriteLine("1-> Mover el gráfico. \n" + "2-> Salir. \n");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine(compuesto.Mover(0,0));
            Console.WriteLine(compuesto.Dibujar());
            break;
        case 2:
            Console.WriteLine("Ha elegido salir.");
            break;
    }
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("El valor indicado está fuera del editor gráfico, el programa se cerrará automáticamente");
}


internal class EditorGrafico  //clase EditorGrafico 
{
    protected List<IGrafico> listaGraficos = new List<IGrafico>();
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
    bool Mover(int x, int y);
   string Dibujar();
}
internal class Punto : IGrafico  // clase  Punto
{
    private int _x, _y;
    protected int X
    {
        get { return _x; }
        set
        {
            if (value >= 0 && value <= 800)
            {
                _x = value;  // si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor lanzamos una excepción que gestionaremos en nuestro main
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    protected int Y
    {
        get { return _y; }
        set
        {
            if (value >= 0 && value <= 600)
            {
                _y = value; // si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor lanzamos una excepción que gestionaremos en nuestro main
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    public Punto (int x, int y) // constructor de la clase
    {
        this.X = x;
        this.Y = y;
    }
    public virtual string Dibujar() // método dibujar 
    {
       return "punto-> "+this._x + " : " + this._y;
    }
    public virtual bool Mover(int x, int y) // método mover 
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
            this._x = x;
            this._y = y;
            return true;
        }
    }
}
internal class Circulo : Punto // clase círculo
{
    private int _Radio;
    protected int Radio
    {
        get { return _Radio; }
        set
        {
            if (value-this.X >= 0 && value+this.X <= 800)
            {
                _Radio = value;// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            }
            else
            {// si al crear o modificar el atributo está fuera de los límites del editor lanzamos una excepción que controlaremos en el main
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    public Circulo(int x, int y, int radio) : base(x, y) //contructor de la clase 
    {
        this.X = x;
        this.Y = y;
        this._Radio = radio;
    }
    
    override public bool  Mover(int x, int y) // método mover 
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
            this.X = x;
            this.Y = y;
            return true;
        }
              
    }
    override public string Dibujar() // método dibujar de la clase
    {       
        return "circulo-> "+ this.X + " : " + this.Y +" : " + this.Radio;
    }
}
internal class Rectangulo : Punto // clase Rectángulo 
{
    private int _Ancho, _Alto;
    protected int Ancho
    {
        get { return _Ancho; }
        set
        {
            if (value + this.X <= 800) { _Ancho = value; }// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            else
            { // si al crear o modificar el atributo está fuera de los límites del editor lanzamos una excepción que controlaremos en nuestro main
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    protected int  Alto
    {
        get { return _Alto; }
        set
        {
            if (this.Y - value >= 0) { _Alto = value; }// si al crear o modificar el atributo está en los límites del editor lo damos por válido
            else
            {// si al crear o modificar el atributo está fuera de los límites del editor lanzamos una excepción que controlaremos en nuestro main
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    public Rectangulo(int x, int y, int ancho, int alto) : base(x, y) // constructor de la clase 
    {
        this.X = x;
        this.Y = y;
        this.Ancho = ancho;
        this.Alto = alto;
    }
    override public bool Mover(int x, int y) // método mover
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
            this.X = x;
            this.Y = y;
            return true;
        }
    }
    override public string Dibujar() // método dibujar 
    {  
       return "rectangulo-> " + this.X + " : " + this.Y + " : " + this.Alto + " : " + this.Ancho;
    }
}

internal class GraficoCompuesto : IGrafico // clase GraficoCompuesto
{
    protected List<IGrafico> componentes = new List<IGrafico>();
    public string Dibujar() // metodo dibujar 
    {
        var  muestraComponentes = "Compuesto: \n";
        for(int i = 0; i < componentes.Count; i++)
        {
            muestraComponentes += componentes[i].Dibujar()+"\n";
        }
        return muestraComponentes;
    }

    public bool Mover(int x,int y) // metodo mover 
    {
        var movimiento = true;
        int xx;
        int yy;
        for (int i = 0; i < componentes.Count; i++) // por cada gráfico que lo componen llamamos al método mover de la clase correpondiente 
        {
            Console.WriteLine(componentes[i].Dibujar());
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

public class ConsoleHelper
{
    public static void ShowMessage(string message) // método para mostrar los string que más se repetiran en el main
    {
        switch (message)
        {
            case "punto":
                Console.WriteLine("Introduzca los datos del punto, recuerde que el tamaño del editor es de 800 x 600");
                break;
            case "círculo":
                Console.WriteLine("Introduzca los datos del círculo, recuerde que el tamaño del editor es de 800 x 600");
                break;
            case "rectángulo":
                Console.WriteLine("Introduzca los datos del rectángulo, recuerde que el tamaño del editor es de 800 x 600");
                break;
            case "x":
                Console.WriteLine("Introduzca el valor de x: ");
                break;
            case "y":
                Console.WriteLine("Introduzca el valor de y: ");
                break;
            case "radio":
                Console.WriteLine("Introduzca el radio del círculo: ");
                break;
            case "ancho":
                Console.WriteLine("Introduzca el ancho del rectángulo: ");
                break;
            case "alto":
                Console.WriteLine("Introduzca el alto del rectángulo: ");
                break;
        }
    }
    public static int ReadInput()
    {
        Console.WriteLine("ingrese un valor numérico");
        string input = Console.ReadLine();
        while(true)
        {
            if(int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Debe introducir un valor numérico. Inténtelo de nuevo ");
                input = Console.ReadLine();
            }
        }
    }
}