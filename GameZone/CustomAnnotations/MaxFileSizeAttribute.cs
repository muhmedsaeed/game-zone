namespace GameZone.CustomAnnotations;

public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int maxFileSizeInByte;

    public MaxFileSizeAttribute(int maxFileSizeInByte)
    {
        this.maxFileSizeInByte = maxFileSizeInByte;
    }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
        {
            if (file.Length > maxFileSizeInByte)
            {
                return new ValidationResult($"Maximum allowed size is {maxFileSizeInByte} Bytes.");
            }
        }
        return ValidationResult.Success;
    }


}
