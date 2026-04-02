namespace GameZone.Service.Categories;

public interface ICategoryService
{
    IEnumerable<SelectListItem> GetSelectListItems();
}
