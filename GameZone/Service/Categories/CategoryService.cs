namespace GameZone.Service.Categories;

public class CategoryService : ICategoryService
{
    private readonly GameZoneDbContext db;

    public CategoryService(GameZoneDbContext db)
    {
        this.db = db;
    }


    // ------------------------ Read ---------------------
    public IEnumerable<SelectListItem> GetSelectListItems()
    {
        return db.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
    }
}
