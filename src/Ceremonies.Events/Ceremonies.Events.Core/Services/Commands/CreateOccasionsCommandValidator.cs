namespace Ceremonies.Events.Core.Services.Commands
{
    public class CreateOccasionsCommandValidator:AbstractValidator<CreateOccasionsCommand>
    {
        public CreateOccasionsCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty(); 
            RuleFor(x=>x.StartDate).NotEmpty();
            RuleFor(x=>x.EndDate).NotEmpty();

        }
    }
}
