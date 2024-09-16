namespace CourseMicroservices.Basket.DTOs;

public class BasketDTO
{
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int? DiscountRate { get; set; }
    public List<BasketItemDto> basketItems { get; set; }
    public decimal TotalPrice
    {
        get => basketItems.Sum(b => b.Price * b.Quantity);
    }
}
