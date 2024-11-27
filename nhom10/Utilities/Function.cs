namespace nhom10.Utilities
{
    public class Function
    {
        public static string TitleSluGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
    }
}
