namespace GameZone.Service.Devices;

public class DeviceService : IDeviceService
{
    private readonly GameZoneDbContext db;

    public DeviceService(GameZoneDbContext db)
    {
        this.db = db;
    }


    // ------------------------ Read ---------------------
    public IEnumerable<SelectListItem> GetSelectListItems()
    {
        return db.Devices
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .AsNoTracking()
                .ToList();
    }
}
