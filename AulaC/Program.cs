// Screen Sound

string mensagemBoasVindas = "Welcome to Screen sound";
List<string> listaDasBandas = new List<string> { "Linkin Park", "Asking Alexandria", "Spiritbox" };

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

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nType 1 to log a band");
    Console.WriteLine("Type 2 to show logged bands");
    Console.WriteLine("Type 3 to rate a band");
    Console.WriteLine("Type 4 to show all rates of a band");
    Console.WriteLine("Type -1 to exit");

    Console.Write("\nYou chose: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNum)
    {
        case 1: RegisterBands();
            break;
        case 2: ShowRegisteredBands();
            break;
        case 3: Console.WriteLine("You chose " + opcaoEscolhidaNum);
            break;
        case 4: Console.WriteLine("You chose " + opcaoEscolhidaNum);
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
    string nomeDaBanda = Console.ReadLine()!;
    listaDasBandas.Add(nomeDaBanda);
    Console.WriteLine($"\nThe band {nomeDaBanda} has been successfully logged!");
    Thread.Sleep(2000);
    Console.Clear() ;
    ExibirOpcoesMenu();
}

void ShowRegisteredBands()
{
    Console.Clear();
    OptionsTitle("Showing logged bands");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    
    foreach(string band in listaDasBandas)
    {
        Console.WriteLine($"Band: {band}");
    }

    Console.WriteLine("\nPress any button to go back to the main menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void OptionsTitle(string title)
{
    int lettersQuantity = title.Length;
    string titleBanner = string.Empty.PadLeft(lettersQuantity, '-');
    Console.WriteLine(titleBanner);
    Console.WriteLine(title);
    Console.WriteLine(titleBanner + "\n");
}

ExibirOpcoesMenu();