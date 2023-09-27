namespace CodeProjet;

public class CodeProjetHelper
{
    private List<CodeProjet> CodeProjets { get; set; }

    public CodeProjetHelper()
    {
        CodeProjets = new();

        //Create data file in not found
        if (!File.Exists(Statics.DataFile))
        {
            File.Create(Statics.DataFile).Close();
        }
    }

    public async Task LoadAsync()
    {
        var lines = await File.ReadAllLinesAsync(Statics.DataFile);
        foreach (var line in lines)
        {
            var lineSplitted = line.Split('\t');
            var codeProjet = new CodeProjet(lineSplitted[0], Convert.ToInt32(lineSplitted[1]), true);
            CodeProjets.Add(codeProjet);
        }
    }

    /// <summary>
    /// A function that saves all data in this format 1234a-0001
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task SaveAsync()
    {
        var lines = CodeProjets.Where(codeProjet => !codeProjet.Saved)
            .Select(codeProjet => $"{codeProjet.Radical}\t{codeProjet.Chrono}");
        await File.AppendAllLinesAsync(Statics.DataFile, lines);
    }

    private int FindNextChrono(string radical)
    {
        var nextChrono = 1;
        var found = true;

        do
        {
            found = CodeProjets.Any(codeProjet => codeProjet.Radical == radical && codeProjet.Chrono == nextChrono);
            if (found)
            {
                nextChrono++;
            }
        } while (found);

        return nextChrono;
    }

    public CodeProjet AddAsync(string radical)
    {
        var chrono = FindNextChrono(radical);
        var codeProjet = new CodeProjet(radical, chrono, false);
        CodeProjets.Add(codeProjet);
        return codeProjet;
    }
}