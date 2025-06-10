namespace DACN.Views.Utilities
{
    public class Function
    {
        public static int _AccountId = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        public static string _address = String.Empty;
        public static string _Phone = String.Empty;
        public static string _pickupDate = String.Empty;
        public static string _returnDate = String.Empty;
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._UserName) || string.IsNullOrEmpty(Function._Email) || (Function._AccountId <= 0))
            {
                return false;
            }
            return true;
        }
    }
}
