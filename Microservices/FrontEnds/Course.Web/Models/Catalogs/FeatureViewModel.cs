using System.ComponentModel.DataAnnotations;

namespace Course.Web.Models.Catalogs;

public class FeatureViewModel
{
    [Display(Name = "Course Time")]
    public int Duration { get; set; }
}
