namespace GamerCorner.Services
{
    public interface IGameService
    {
        Task Create(CreateGameFormViewModel model);
    }
}
