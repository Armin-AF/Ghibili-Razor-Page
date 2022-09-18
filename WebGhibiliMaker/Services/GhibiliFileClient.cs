using System.Reflection;

namespace WebGhibiliMaker.Services;

public class GhibiliFileClient : IGhibiliFileClient
{
    readonly string _imageFilePath = string.Empty;
    private string? GetGetAssemblyDirectory()
    {
        string codeBase = Assembly.GetExecutingAssembly().Location;
        return Path.GetDirectoryName(codeBase);
    }

    public GhibiliFileClient()
    {
        //_imageFilePath = Path.Join(GetGetAssemblyDirectory(), "/Data/Images.csv");
        _imageFilePath = "/Users/rminafa/Projects/GhibliWebApp/WebGhibiliMaker/Data/Images.csv";
    }
    
    private string[] GetGetLineData(string line) => line.Split(',');
    
    
    private string GetGetHeroId(string line) => GetGetLineData(line)[0];
    
    private string GetGetHeroImage(string line) => GetGetLineData(line)[1];
    
    private bool GetIsHeroLine(string line, string heroId) => GetGetHeroId(line) == heroId;
    
    
    private async Task<string[]> GetGetFileContent() => await File.ReadAllLinesAsync(_imageFilePath);
    public async Task<string> GetImageForHero(string heroId){
        string[] lines = await GetGetFileContent();

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line) && GetIsHeroLine(line, heroId))
            {
                return GetGetHeroImage(line);
            }
        }
        return "https://www.pngkey.com/png/full/147-1473883_404-error-404-not-found-png.png";
    }
}