namespace Book_Store.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/Images/Books";
        public const string AllowExtenstions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInByte = MaxFileSizeInMB*1024*1024;

    }
}
