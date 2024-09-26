using System.ComponentModel.DataAnnotations;

namespace Course.Web.Models;

public class SigninInput
{
    [Required]
    [Display(Name = "Email address")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember me!")]
    public bool IsRemember { get; set; }
}
