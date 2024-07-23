using System.Numerics;
using System.Runtime.CompilerServices;



Console.WriteLine("Iniciando Simulacion...");
Thread.Sleep(4000);
Zorros zorros = new Zorros();
Conejos conejos = new Conejos();
Zanahorias zanahorias = new Zanahorias();
string valor = "" ;

Console.WriteLine("Digite la Cantidad de Zorros Machos:");
valor = Console.ReadLine();
zorros.TotalMachos = int.Parse(valor);

Console.WriteLine("Digite la Cantidad de Zorros hembras:");
valor = Console.ReadLine();
zorros.TotalHembras = int.Parse(valor);

zorros.Total = zorros.TotalHembras + zorros.TotalMachos;
Console.WriteLine("Digite el Porcentaje de natalidad:");
valor = Console.ReadLine();

zorros.Natalidad = Double.Parse(valor) / 100;
Console.WriteLine("Digite el Porcentaje de mortalidad:");
valor = Console.ReadLine();
zorros.Mortalidad= Double.Parse(valor) / 100;

Console.WriteLine("Digite el Consumo diario Por Zorro");
valor = Console.ReadLine();
zorros.ConsumoDiarioPorZorro = int.Parse(valor);



////////////////////////////////////////////////////////////////////


Console.WriteLine("Digite la Cantidad de conejos Machos:");
valor = Console.ReadLine();
conejos.TotalMachos = int.Parse(valor);

Console.WriteLine("Digite la Cantidad de conejos hembras:");
valor = Console.ReadLine();
conejos.TotalHembras = int.Parse(valor);

conejos.Total = conejos.TotalHembras + conejos.TotalMachos;
Console.WriteLine("Digite el Porcentaje de natalidad:");
valor = Console.ReadLine();

conejos.Natalidad = Double.Parse(valor) / 100;
Console.WriteLine("Digite el Porcentaje de mortalidad:");
valor = Console.ReadLine();
conejos.Mortalidad = Double.Parse(valor) / 100;

Console.WriteLine("Digite el Consumo diario Por Conejo");
valor = Console.ReadLine();
conejos.ConsumoDiarioPorConejo= int.Parse(valor);


///////////////////////////////////////////////////////////////////////
///

Console.WriteLine("Digite la Cantidad Inicial de Zanahorias:");
valor = Console.ReadLine();
zanahorias.Total = int.Parse(valor);


Console.WriteLine("Digite el Porcentaje de Reproduccion:");
valor = Console.ReadLine();
zanahorias.Reproduccion = Double.Parse(valor) / 100;

///////////////////////////////////////////////////////////////////////



Console.WriteLine("Digite la Cantidad de Dias   que va a Durar la Simulacion:");


valor = Console.ReadLine();
int Dias = int.Parse(valor);


Console.WriteLine("Cargando  Simulacion....");
Thread.Sleep(4000);

for (int i = 0; i < Dias; i++)
{

    Console.WriteLine($"DIA {i + 1}");

    Random random = new Random();
    int randomNumber = 0;
    int ConsumoDiarioPorZorro = zorros.Total * zorros.ConsumoDiarioPorZorro;



    if (ConsumoDiarioPorZorro < conejos.Total)
    {
        Console.WriteLine("La Cantidad de Conejos es abundante para los Zorros...");
        Thread.Sleep(1000);
        Console.WriteLine("Bajando Mortalidad Zorros...");
        Thread.Sleep(1000);
        zorros.Mortalidad = zorros.Mortalidad - 0.01;

        Console.WriteLine("Aumentando Natalidad Zorros...");
        Thread.Sleep(1000);
        zorros.Natalidad = zorros.Natalidad + 0.01;
        Console.WriteLine("Aumentando Consumo Diario Zorros...");
        zorros.ConsumoDiarioPorZorro++;

        Thread.Sleep(1000);
    }
    else
    {
        while (ConsumoDiarioPorZorro > conejos.Total)
        {
            Console.WriteLine("La cantidad de Conejos insuficientes para Zorros. ");
            Thread.Sleep(1000);
            Console.WriteLine("Disminuyendo Consumo Diario Zorros...");
            zorros.ConsumoDiarioPorZorro--;
            ConsumoDiarioPorZorro = zorros.Total * zorros.ConsumoDiarioPorZorro;

            Thread.Sleep(1000);
            Console.WriteLine("Aumentando Mortalidad Zorros...");
            zorros.Mortalidad = zorros.Mortalidad + 0.01;

            Console.WriteLine("Bajando Natalidad Zorros...");
            zorros.Natalidad = zorros.Natalidad - 0.01;
        }
    }
    double ConejosConsumidos = conejos.Mortalidad * conejos.TotalHembras;

    randomNumber = random.Next(1, 10);

    int HembrasConejosConsumidos = (int)Math.Round(ConejosConsumidos) * (randomNumber / 100);
    int MachosConejosConsumidos = (int)Math.Round(ConejosConsumidos) - HembrasConejosConsumidos;

    conejos.TotalMachos = conejos.TotalMachos - MachosConejosConsumidos;
    conejos.TotalHembras = conejos.TotalHembras - HembrasConejosConsumidos;

    Console.WriteLine();


    ///////////////////////////////////////////////////////////////////////////
    ///

    int ConsumoDiarioPorConejos = conejos.Total * conejos.ConsumoDiarioPorConejo;



    if (ConsumoDiarioPorConejos < zanahorias.Total)
    {
        Console.WriteLine("La Cantidad de Zanahorias es abundante...");
        Thread.Sleep(1000);
        Console.WriteLine("Bajando Mortalidad Conejos...");
        Thread.Sleep(1000);
        conejos.Mortalidad = conejos.Mortalidad - 0.01;

        Console.WriteLine("Aumentando Natalidad Conejos...");
        Thread.Sleep(1000);
        conejos.Natalidad = conejos.Natalidad + 0.01;
        Console.WriteLine("Aumentando Consumo Diario Conejos...");
        conejos.ConsumoDiarioPorConejo++;
        Thread.Sleep(1000);
    }
    else
    {
        while (ConsumoDiarioPorConejos > zanahorias.Total)
        {
            Console.WriteLine("La cantidad de zanahorias insuficientes para los Conejos. ");
            Thread.Sleep(1000);
            Console.WriteLine("Disminuyendo Consumo Diario Conejos...");
            conejos.ConsumoDiarioPorConejo--;
            ConsumoDiarioPorConejos = conejos.Total * conejos.ConsumoDiarioPorConejo;

            Thread.Sleep(1000);
            Console.WriteLine("Aumentando Mortalidad Conejos...");
            conejos.Mortalidad = conejos.Mortalidad + 0.01;

            Console.WriteLine("Bajando Natalidad Conejos...");
            conejos.Natalidad = conejos.Natalidad - 0.01;

           
        }
    }
    Console.WriteLine();

    zanahorias.Total = zanahorias.Total - ConsumoDiarioPorConejos;
    ///////////////////////////////////////////////////////////////////////////
    ///

    double ZorrosNacidos = zorros.Natalidad * zorros.TotalHembras;

    randomNumber = random.Next(1, 10);

    int HembrasZorrosNacidos = (int)Math.Round(ZorrosNacidos) * (randomNumber / 100);
    int MachosZorrosNacidos = (int)Math.Round(ZorrosNacidos) - HembrasZorrosNacidos;

    zorros.TotalMachos = zorros.TotalMachos + MachosZorrosNacidos;
    zorros.TotalHembras = zorros.TotalHembras + HembrasZorrosNacidos;


    ///////////////////////////////////////////////////////////////////////////
    ///

    double ConejosNacidos = zorros.Natalidad * zorros.TotalHembras;

    randomNumber = random.Next(1, 10);
    int HembrasConejosNacidos = (int)Math.Round(ConejosNacidos) * (randomNumber / 100);
    int MachosConejosNacidos = (int)Math.Round(ConejosNacidos) - HembrasConejosNacidos; 


    conejos.TotalMachos = conejos.TotalMachos + HembrasConejosNacidos;
    conejos.TotalHembras = conejos.TotalHembras + MachosConejosNacidos;


    ///////////////////////////////////////////////////////////////////////////
    ///

    double consecha = zanahorias.Total * zanahorias.Reproduccion;

    zanahorias.Total= (int)Math.Round(consecha);

    ///////////////////////////////////////////////////////////////////////////
    ///

    double ZorrosMuertos = zorros.Mortalidad * zorros.TotalHembras;

    randomNumber = random.Next(1, 10);

    int HembrasZorrosMuertos = (int)Math.Round(ZorrosMuertos) * (randomNumber / 100);
    int MachosZorrosMuertos = (int)Math.Round(ZorrosMuertos) - HembrasZorrosMuertos;

    zorros.TotalMachos = zorros.TotalMachos - MachosZorrosMuertos;
    zorros.TotalHembras = zorros.TotalHembras - HembrasZorrosMuertos;
    ///////////////////////////////////////////////////////////////////////////
    ///

    double ConejosMuertos = conejos.Mortalidad * conejos.TotalHembras;

    randomNumber = random.Next(1, 10);

    int HembrasConejosMuertos = (int)Math.Round(ConejosMuertos) * (randomNumber / 100);
    int MachosConejosMuertos = (int)Math.Round(ConejosMuertos) - HembrasConejosMuertos;

    conejos.TotalMachos = conejos.TotalMachos - MachosZorrosMuertos;
    conejos.TotalHembras = conejos.TotalHembras - HembrasZorrosMuertos;


    ///////////////////////////////////////////////////////////////////////////
    ///

    conejos.Total = conejos.TotalMachos + conejos.TotalHembras;
    conejos.Total = conejos.TotalMachos + conejos.TotalHembras;




    zorros.Imprimir();
    conejos.Imprimir();
    zanahorias.Imprimir();
    Thread.Sleep(3000);

}

    





class Zorros
{
    public int Total { get; set; }
    public double Natalidad { get; set; }

    public double Mortalidad { get; set; }
    public int TotalMachos { get; set; }

    public int TotalHembras { get; set; }

    public int ConsumoDiarioPorZorro { get; set; }



    public void Imprimir()
    {
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"Total Zorros: {Total}");
        Console.WriteLine($"Total Zorros Hembras: {TotalHembras}");
        Console.WriteLine($"Total Zorros Machos: {TotalHembras}");
        Console.WriteLine($"Natalidad Zorros: {Natalidad*100}%");
        Console.WriteLine($"Mortalidad Zorros: {Mortalidad * 100}%");
        Console.WriteLine($"Consumo Diario por Zorro: {ConsumoDiarioPorZorro}");
        Console.WriteLine($"---------------------------");



    }

    
}

class Conejos
{
    public int Total { get; set; }
    public double Natalidad { get; set; }

    public double Mortalidad { get; set; }
    public int TotalMachos { get; set; }

    public int TotalHembras { get; set; }

    public int ConsumoDiarioPorConejo { get; set; }

    public void Imprimir()
    {
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"Total Conejos: {Total}");
        Console.WriteLine($"Total Conejos Hembras: {TotalHembras}");
        Console.WriteLine($"Total Conejos Machos: {TotalHembras}");
        Console.WriteLine($"Natalidad Conejos: {Natalidad * 100}%");
        Console.WriteLine($"Mortalidad Conejos: {Mortalidad * 100}%");
        Console.WriteLine($"Consumo Diario por Conejo: {ConsumoDiarioPorConejo}");
        Console.WriteLine($"---------------------------");



    }
}

class Zanahorias
{ 
    public int  Total  { get; set; }
    public double Reproduccion { get; set; }

    public void Imprimir()
    {
        Console.WriteLine($"Total Zanahoras {Total}");
        Console.WriteLine($"Tasa de Reproduccion Zanahoras: {Reproduccion} %");
    }
}











