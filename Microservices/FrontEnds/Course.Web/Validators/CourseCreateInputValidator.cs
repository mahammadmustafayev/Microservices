using Course.Web.Models.Catalogs;
using FluentValidation;

namespace Course.Web.Validators;

public class CourseCreateInputValidator : AbstractValidator<CourseCreateInput>
{
    public CourseCreateInputValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name bos ola bilmez");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description boş ola bilmez");
        RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("süre alanı boş olamaz");

        RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat alanı boş olamaz").ScalePrecision(2, 6).WithMessage("hatalı para formatı");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("kategori alanı seçiniz");
    }
}
