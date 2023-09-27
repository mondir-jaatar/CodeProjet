namespace CodeProjet;

public record CodeProjet
{
    public string Radical { get; set; }
    public int Chrono { get; set; }
    public bool Saved { get; set; }

    public CodeProjet(string radical, int chrono, bool saved)
    {
        Radical = radical;
        Chrono = chrono;
        Saved = saved;
    }

    /// <summary>
    /// A function that is used to print CodeProjet in this format 1234a-0001
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Radical}{Statics.Separateur}{Chrono.ToString("D4")}";
}