using FluentValidation;

namespace Dto.Request.Location
{
    public class LocationCreateRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string dimension { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

    public class LocationCreateRequestDtoValidator : AbstractValidator<LocationCreateRequestDto>
    {
        public LocationCreateRequestDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");

            RuleFor(x => x.type)
                .Length(0, 50).WithMessage("Type must be up to 50 characters");

            RuleFor(x => x.dimension)
                .Length(0, 50).WithMessage("Dimension must be up to 50 characters");

            RuleFor(x => x.url)
                .NotEmpty().WithMessage("URL cannot be empty")
                .Must(IsValidUrl).WithMessage("URL must be a valid URL");
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
