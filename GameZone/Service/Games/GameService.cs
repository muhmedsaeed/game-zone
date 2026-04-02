
namespace GameZone.Service.Games;

public class GameService : IGameService
{
    private readonly GameZoneDbContext db;
    private readonly IWebHostEnvironment webHostEnvironment;
    private string imagesPath; // saving images path

    public GameService(GameZoneDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        this.db = db;
        this.webHostEnvironment = webHostEnvironment;
        // svaing images path
        imagesPath = $"{webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
    }



    // --------------------------- Create ----------------------------
    public async Task Create(CreateGameViewModel model)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        var path = $"{imagesPath}/{coverName}";

        
        using var stream = File.Create(path);
        await model.Cover.CopyToAsync(stream);
        // stream.Dispose(); // No need to it because of keyword 'using'

        Game game = new()
        {
            Name = model.Name,
            Desc = model.Desc,
            Cover = coverName,
            CategoryId = model.CategoryId,
            Devices = model.SelectedDevices
                        .Select(d => new GameDevice() { DeviceId = d })
                        .ToList()
        };

        await db.Games.AddAsync(game);
        await db.SaveChangesAsync();
    }
}
