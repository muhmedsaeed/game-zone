
namespace GameZone.Controllers;

public class GamesController : Controller
{
    private readonly ICategoryService categoryService;
    private readonly IDeviceService deviceService;
    private readonly IGameService gameService;

    public GamesController(IDeviceService deviceService, ICategoryService categoryService, IGameService gameService)
    {
        this.deviceService = deviceService;
        this.categoryService = categoryService;
        this.gameService = gameService;
    }


    // ------------------ Create ----------------------
    [HttpGet]
    public IActionResult Create()
    {
        CreateGameViewModel createGameViewModel = new()
        {
            Categories = categoryService.GetSelectListItems(),
            Devices = deviceService.GetSelectListItems()
        };
        return View(createGameViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = categoryService.GetSelectListItems();
            model.Devices = deviceService.GetSelectListItems();
            return View(model);
        }

        // Save Game to db
        // Save Image to server
        await gameService.Create(model);
        return View(nameof(Index));
    }



    // ------------------ Read ----------------------
    public IActionResult Index()
    {
        return View();
    }



}
