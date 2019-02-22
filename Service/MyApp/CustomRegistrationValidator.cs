//Provide extra validation for the registration process
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.FluentValidation;

public class CustomRegistrationValidator : RegistrationValidator
{
    public CustomRegistrationValidator()
    {
        RuleSet(ApplyTo.Post, () => {
            RuleFor(x => x.DisplayName).NotEmpty();
        });
    }
}