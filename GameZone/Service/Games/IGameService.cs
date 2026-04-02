namespace GameZone.Service.Games;

public interface IGameService
{


    // ----------------------------- Create -----------------------
    Task Create(CreateGameViewModel model);
}
