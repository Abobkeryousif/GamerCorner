namespace GamerCorner.Controllers
{
    public class gamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IDeviceService _deviceService;
        private readonly IGameService _gameService;

        public gamesController(ApplicationDbContext context, ICategoryService categoryService, IDeviceService deviceService, IGameService gameService)
        {
            _categoryService = categoryService;
            _context = context;
            _deviceService = deviceService;
            _gameService = gameService;
        }


        public IActionResult Index()
        {
            var games = _gameService.GetAllGames();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gameService.GetGameById(id);
            if(game == null)
                return NotFound($"Not Found Game With ID: {id}");

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoryService.GetSelectList(), 

                Devices = _deviceService.GetSelectDeviceLists()
            };
            return View(viewModel);
        }

        [HttpPost]
        //For Secure Our Website
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService.GetSelectList();

                model.Devices = _deviceService.GetSelectDeviceLists();

                return View(model);
            }
            await _gameService.Create(model);
           
            return RedirectToAction(nameof(Index));
        }

    }
}
