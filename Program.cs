// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using TheOmenDen.CrowsAgainstHumility.Importer.contexts;
using TheOmenDen.CrowsAgainstHumility.Importer.Models;

var filePath = $"../../../cah-cards-full.json";

await using var cardFile = File.OpenRead(filePath);

var packRoot = await JsonSerializer.DeserializeAsync<Packs[]>(cardFile, new JsonSerializerOptions
{
 AllowTrailingCommas = true,
  DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
  PropertyNameCaseInsensitive = true
});

await using var dbContext = new TheOmenDenCrowsAgainstHumilityDbContext();

if(!await dbContext.Database.EnsureCreatedAsync())
{
    Console.WriteLine("Creating Database on Azure");
}

var dbPackData = packRoot.Select(p => new Pack
{
    Name = p.name,
    Description = $"{p.name}-{(p.official ? "Official" : "Fanmade")}",
    IsOfficialPack = p.official,
    BlackCards = p.black.Select(bc => new BlackCard
    {
        Message = bc.text,
        PickAnswersCount = bc.pick
    }).ToArray(),
    WhiteCards = p.white.Select(wc => new WhiteCard
    {
        CardText = wc.text
    }).ToArray()
})
    .ToArray();

dbContext.Packs.UpdateRange(dbPackData);

dbContext.SaveChanges();


public class Packs
{
    public string name { get; set; }
    public White[] white { get; set; }
    public Black[] black { get; set; }
    public bool official { get; set; }
}

public class White
{
    public string text { get; set; }
    public int pack { get; set; }
}

public class Black
{
    public string text { get; set; }
    public int pick { get; set; }
    public int pack { get; set; }
}
