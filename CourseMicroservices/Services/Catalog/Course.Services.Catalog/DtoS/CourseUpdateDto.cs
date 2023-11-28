namespace Course.Services.Catalog.DtoS;

public class CourseUpdateDto
{
    public string Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
    public string Picture { get; set; }
    public string UserId { get; set; }

    public FeatureDto Feature { get; set; }

    public string CategoryId { get; set; }
}
