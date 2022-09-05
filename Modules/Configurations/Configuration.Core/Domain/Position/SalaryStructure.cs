


using Ardalis.GuardClauses;
using Shared.Abstractions.Types;

namespace Core.Domains.Position
{
    public class SalaryStructure : BaseEntity
    {
        private SalaryStructure()
        {

        }
        public SalaryStructure(string payBand, decimal minimum, decimal midpoint,
        decimal maximum, string? note)
        {

            PayBand = Guard.Against.NullOrEmpty(payBand);
            Minimum = Guard.Against.NegativeOrZero(minimum);
            Midpoint = Guard.Against.NegativeOrZero(midpoint);
            Maximum = Guard.Against.NegativeOrZero(maximum);
            if (minimum > midpoint || midpoint > maximum) throw new InvalidOperationException($"{nameof(minimum)}- {nameof(midpoint)} is not valid range!"); ;
            Range = maximum - midpoint;
            Spread = Math.Round(Range / maximum, 2);
            Note = note;
            CreatedAt = DateTimeOffset.UtcNow;

        }


        public string PayBand { get; private set; }
        public decimal Minimum { get; private set; }
        public decimal Midpoint { get; private set; }
        public decimal Maximum { get; private set; }
        public decimal Spread { get; private set; }
        public decimal Range { get; private set; }
        public string? Note { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdateAt { get; private set; }

        public void UpdateSalaryStructure(string payBand, decimal minimum, decimal midpoint,
        decimal maximum, decimal spread, decimal range, string? note)
        {
            Minimum = Guard.Against.NegativeOrZero(minimum);
            Midpoint = Guard.Against.NegativeOrZero(midpoint);
            Maximum = Guard.Against.NegativeOrZero(maximum);
            PayBand = Guard.Against.NullOrEmpty(payBand);
            if (minimum > midpoint || midpoint > maximum)
                throw new InvalidOperationException($"{nameof(minimum)}- {nameof(midpoint)} is not valid range!"); ;

            Range = maximum - midpoint;

            Spread = Math.Round(Range / maximum, 2);
            Note = note;
            UpdateAt = DateTimeOffset.UtcNow;
        }
    }
}
