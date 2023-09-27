namespace CodeProjet;

public record CodeProjet
{
    public string Radical { get; set; }
    public int? Chrono { get; set; }
    /// <summary>
    /// Anything rather the good format
    /// </summary>
    public string ChronoText { get; set; }
    /// <summary>
    /// Saved == true : already saved in data file
    /// Saved == false : must be saved in data file
    /// </summary>
    public bool Saved { get; set; }

    public CodeProjet(string radical, int? chrono, string chronoText, bool saved)
    {
        Radical = radical;
        Chrono = chrono;
        Saved = saved;
        ChronoText = chronoText;
    }

    /// <summary>
    /// A function that is used to print CodeProjet in this format 1234a-0001
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Radical}{Statics.Separateur}{Chrono.Value.ToString("D4")}";
}