namespace GamerCorner.Settings
{
    public static class FileSetting
    {
        public const string imagePath = "/assets/images/gamesCover";
        public const string allowedExtension = ".png,.jpg,.jpeg";
        public const int maxFileSizeInMB = 2;
        public const int maxFileSizeInBytes = maxFileSizeInMB * 1024 * 1024;
    }
}
