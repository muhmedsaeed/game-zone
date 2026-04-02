
namespace GameZone.ViewModels;


public record GameViewModel
{

}


public record CreateGameViewModel
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;


    [Display(Name="Category")]
    public int CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();


    [Display(Name = "SupportedDevices")]
    public List<int> SelectedDevices { get; set; } = default!;
    public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();


    [MaxLength(2500)]
    [Display(Name = "Description")]
    public string Desc { get; set; } = string.Empty;


    [AllowedExtentions(FileSettings.AllowedExtentions),
     MaxFileSizeAttribute(FileSettings.MaxFileSizeInByte)]
    public IFormFile Cover { get; set; } = default!;
}



public record UpdateGameViewModel
{
}

