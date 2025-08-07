namespace GamerCorner.ViewModel
{
    public class CreateGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

 
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Platform")]
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2550)]
        public string Description { get; set; } = string.Empty;
        public IFormFile Cover { get; set; } = default!;
        
    }
}
