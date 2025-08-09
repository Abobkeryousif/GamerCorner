namespace GamerCorner.Services
{
    public interface ICategoryService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
