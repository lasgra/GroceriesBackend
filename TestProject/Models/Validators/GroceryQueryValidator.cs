using FluentValidation;

namespace TestProject.Models.Validators
{
    public class GroceryQueryValidator : AbstractValidator<GroceryQuery>
    {
        private string[] allowedSortByColumnNames = { nameof(GroceryListEntryDTO.Name), nameof(GroceryListEntryDTO.Id), nameof(GroceryListEntryDTO.Price) };
        public GroceryQueryValidator()
        {
            RuleFor(r => r.SortBy)
                .Must(v => string.IsNullOrEmpty(v) || allowedSortByColumnNames
                .Contains(v))
                .WithMessage($"Sort by is optional or must by in [{string.Join(',', allowedSortByColumnNames)}]");
        }
    }
}
