using FluentValidation;

namespace Dto.Request.Episode
{
    public class EpisodeCreateRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string airDate { get; set; } = string.Empty;
        public string episodeCode { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }

    public class EpisodeCreateRequestDtoValidator : AbstractValidator<EpisodeCreateRequestDto>
    {
        public EpisodeCreateRequestDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");

            RuleFor(x => x.airDate)
                .NotEmpty().WithMessage("AirDate cannot be empty");

            RuleFor(x => x.episodeCode)
                .NotEmpty().WithMessage("EpisodeCode cannot be empty")
                .Length(1, 20).WithMessage("EpisodeCode must be between 1 and 20 characters");

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
