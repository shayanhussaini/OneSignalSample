using System.ComponentModel.DataAnnotations;

namespace OneSignalApp.Models
{
    public class AppModel
    {
        [Display(Name = "ID")]
        public string id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Players")]
        public int players { get; set; }
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string created_at { get; set; }
        [Display(Name = "Site Name")]
        public string site_name { get; set; }
        [Display(Name = "Organization")]
        public string organization_id { get; set; }
    }
}