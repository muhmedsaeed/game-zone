
namespace GameZone.Settings;

public static class FileSettings
{
    public const string ImagesPath = "/assets/images/games";

    public const string AllowedExtentions = ".jpg,.jpeg,.png";
    public const int MaxFileSizeInMB =1;
    public const int MaxFileSizeInByte =1024*1024;

    // can use IOptions pattern for allowed extentions


}
