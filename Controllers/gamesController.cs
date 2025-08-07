using GamerCorner.Models;

namespace GamerCorner.Controllers
{
    public class gamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public gamesController(ApplicationDbContext context)=>
        _context = context;
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _context.Categories.Select(c => new SelectListItem 
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).OrderBy(c=>c.Text).ToList(),

                Devices = _context.Devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).OrderBy(d => d.Text).ToList() 
            };
            return View(viewModel);
        }

        [HttpPost]
        //For Secure Our Website
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).OrderBy(c => c.Text).ToList();

                model.Devices = _context.Devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).OrderBy(d => d.Text).ToList();

                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
