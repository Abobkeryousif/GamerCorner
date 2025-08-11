namespace GamerCorner.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        Task Create(CreateGameFormViewModel model);
    }
}
