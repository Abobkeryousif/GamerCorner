namespace GamerCorner.Services
{
    public interface IGameService
    {
        Task Create(CreateGameFormViewModel model);
        IEnumerable<Game> GetAllGames();
        Game? GetGameById(int id);
    }
}
