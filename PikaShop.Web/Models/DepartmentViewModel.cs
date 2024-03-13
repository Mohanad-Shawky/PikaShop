namespace PikaShop.Web.Models
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public DepartmentViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
