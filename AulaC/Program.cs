// Screen Sound
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

string mensagemBoasVindas = "Welcome to Screen sound";
//List<string> listaDasBandas = new List<string> { "Linkin Park", "Asking Alexandria", "Spiritbox" };
Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
registeredBands.Add("Bring me the Horizon", new List<int> { 10, 9, 7 });
registeredBands.Add("Spiritbox", new List<int> ());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

░██████╗██╗░░░██╗░██████╗████████╗███████╗███╗░░░███╗░██████╗
██╔════╝╚██╗░██╔╝██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔════╝
╚█████╗░░╚████╔╝░╚█████╗░░░░██║░░░█████╗░░██╔████╔██║╚█████╗░
░╚═══██╗░░╚██╔╝░░░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║░╚═══██╗
██████╔╝░░░██║░░░██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██████╔╝
╚═════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═════╝░
");
    Console.WriteLine(mensagemBoasVindas);
}

void ShowMenuOptions()
{
    ExibirLogo();
    Console.WriteLine("\nType 1 to log a band");
    Console.WriteLine("Type 2 to show logged bands");
    Console.WriteLine("Type 3 to rate a band");
    Console.WriteLine("Type 4 to show the average rate of a band");
    Console.WriteLine("Type -1 to exit");

    Console.Write("\nChoose an option: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNum)
    {
        case 1: RegisterBands();
            break;
        case 2: ShowRegisteredBands();
            break;
        case 3: RateABand();
            break;
        case 4: ShowRatedBands();
            break;
        case -1: Console.WriteLine("You chose " + opcaoEscolhidaNum);
            break;
        default: Console.WriteLine("Invalid option");
            break;
    }
}

void RegisterBands()
{
    Console.Clear();
    OptionsTitle("Logging Bands");
    Console.WriteLine("Write down the band you want to log: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"\nThe band {bandName} has been successfully logged!");
    Thread.Sleep(1000);
    Console.Clear() ;
    ShowMenuOptions();
}

void ShowRegisteredBands()
{
    Console.Clear();
    OptionsTitle("Showing logged bands");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    
    foreach(string band in registeredBands.Keys)
    {
        Console.WriteLine($"Band: {band}");
    }

    Console.WriteLine("\nPress any button to go back to the main menu");
    Console.ReadKey();
    Console.Clear();
    ShowMenuOptions();
}

void OptionsTitle(string title)
{
    int lettersQuantity = title.Length;
    string titleBanner = string.Empty.PadLeft(lettersQuantity, '-');
    Console.WriteLine(titleBanner);
    Console.WriteLine(title);
    Console.WriteLine(titleBanner + "\n");
}

void RateABand()
{
    Console.Clear();
    OptionsTitle("Rate a band");
    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine($"Band: {band}");
    }
    Console.Write("\nType the name of the band you want to rate: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"From 1 to 10 how would you rate the band {bandName}? ");
        int rate = int.Parse(Console.ReadLine()!);
        registeredBands[bandName].Add(rate);
        Console.WriteLine($"\n{rate} was given to {bandName}");
        Thread.Sleep(2000);
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine($"\n The band {bandName} does not exist, please register the band first");
        Console.WriteLine("Press any key to go back to the main menu");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

void ShowRatedBands()
{
    Console.Clear();
    OptionsTitle("Showing the average rate of a band");
    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine($"Band: {band}");
    }
    Console.Write("\nType the name of the band you want to see the average rate: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        double averageRate = registeredBands[bandName].Average();
        Console.WriteLine($"\nThe average rate of {bandName} is: " + averageRate);
        Console.WriteLine("Press any key to go back to the main menu");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine($"\n The band {bandName} does not exist, please register the band first");
        Console.WriteLine("Press any key to go back to the main menu");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

ShowMenuOptions();