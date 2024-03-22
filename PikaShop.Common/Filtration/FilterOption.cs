namespace PikaShop.Common.Filtration
{
    public class FilterOption
    {
        public string Key { get; set; }

        public List<FilterOption> Options { get; set; }

        public FilterOption()
        {
            Key = string.Empty;
            Options = new List<FilterOption>();
        }
    }
}
