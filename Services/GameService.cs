namespace GamerCorner.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imagesPath;

        public GameService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _imagesPath = $"{_environment.WebRootPath}{FileSetting.imagePath}";
        }

        public async Task Create(CreateGameFormViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

            var path = Path.Combine(_imagesPath,coverName);
            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);

            Game games = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Device = model.SelectedDevices.Select(d=> new GameDevice { DeviceId = d}).ToList()
            };

            _context.Add(games);
            _context.SaveChanges();
        }
    }
}
