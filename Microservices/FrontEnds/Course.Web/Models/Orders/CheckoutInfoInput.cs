using System.ComponentModel.DataAnnotations;

namespace Course.Web.Models.Orders;

public class CheckoutInfoInput
{
    [Display(Name = "Province")]
    public string Province { get; set; }

    [Display(Name = "District")]
    public string District { get; set; }

    [Display(Name = "Street")]
    public string Street { get; set; }

    [Display(Name = "Post Code")]
    public string ZipCode { get; set; }

    [Display(Name = "adress")]
    public string Line { get; set; }

    [Display(Name = "Your name and surname")]
    public string CardName { get; set; }

    [Display(Name = "Card number")]
    public string CardNumber { get; set; }

    [Display(Name = "Last expiration(month/year)")]
    public string Expiration { get; set; }

    [Display(Name = "CVV/CVC2 number")]
    public string CVV { get; set; }
}
