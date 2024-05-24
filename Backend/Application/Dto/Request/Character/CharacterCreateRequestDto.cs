using FluentValidation;

namespace Dto.Request.Character
{
    public class CharacterCreateRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public int locationId { get; set; }
        public string image { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

    public class CharacterCreateRequestDtoValidator : AbstractValidator<CharacterCreateRequestDto>
    {
        public CharacterCreateRequestDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");

            RuleFor(x => x.status)
                .NotEmpty().WithMessage("Status cannot be empty")
                .Length(1, 50).WithMessage("Status must be between 1 and 50 characters");

            RuleFor(x => x.species)
                .NotEmpty().WithMessage("Species cannot be empty")
                .Length(1, 50).WithMessage("Species must be between 1 and 50 characters");

            RuleFor(x => x.type)
                .Length(0, 50).WithMessage("Type must be up to 50 characters");

            RuleFor(x => x.gender)
                .NotEmpty().WithMessage("Gender cannot be empty");

            RuleFor(x => x.locationId)
                .GreaterThan(0).WithMessage("LocationId must be greater than 0");

            RuleFor(x => x.image)
                .NotEmpty().WithMessage("Image URL cannot be empty")
                .Must(IsValidUrl).WithMessage("Image must be a valid URL");

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
