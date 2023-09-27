using CodeProjet;

var helper = new CodeProjetHelper();

Console.WriteLine("=== Chargement de données");
await helper.LoadAsync();

while (true)
{
    Console.WriteLine("=== Menu principal : ");
    Console.WriteLine("=== 1 : Ajouter un code projet.");
    Console.WriteLine("=== 2 : Sauvegarder et quitter.");

    var read = Console.ReadLine();
    switch (read)
    {
        case "1":
            AskToAdd();
            break;
        case "2":
            helper.SaveAsync();
            Environment.Exit(0);
            break;
        default:
            continue;
    }
}

void AskToAdd()
{
    var radical = "";

    do
    {
        Console.WriteLine("=== Entrez le radical du projet ou tapez QUIT pour revenir au menu principal.");
        radical = Console.ReadLine();

        //Done
        if (radical == "QUIT")
        {
            break;
        }

        //Validation
        if (string.IsNullOrEmpty(radical) || radical.Length > 10)
        {
            Console.WriteLine("=== Radical non valide.");
            radical = "";
        }

        //Ok
        if (string.IsNullOrEmpty(radical)) continue;

        var codeProjet = helper.AddAsync(radical);
        Console.WriteLine($"=== Code projet ajouté : {codeProjet}");

    } while (string.IsNullOrEmpty(radical));
}