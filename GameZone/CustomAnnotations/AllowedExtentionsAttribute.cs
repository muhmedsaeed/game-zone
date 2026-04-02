namespace GameZone.CustomAnnotations;

public class AllowedExtentionsAttribute : ValidationAttribute
{
    private readonly string allowedExtentions;

    public AllowedExtentionsAttribute(string allowedExtentions)
    {
        this.allowedExtentions = allowedExtentions;
    }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if(file is not null)
        {
            var extention = Path.GetExtension(file.FileName);

            var isAllowed = allowedExtentions.Split(',').Contains(extention, StringComparer.OrdinalIgnoreCase);
            if (!isAllowed)
            {
                return new ValidationResult($"Only {allowedExtentions} are allowed.");
            }
        }
        
        return ValidationResult.Success;

    }


}
