
namespace CashDustributor.Tests.Unit;

internal class CashDistributorProccessor
{
    public CashDistributorProccessor(int cash)
    {
        if (cash % 5 != 0)
        {
            throw new ArgumentException("cash should be multiple of five", nameof(cash));
        }

        Cash = cash;
    }

    public int Cash { get; internal set; }

    public void AddCash(int cashToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cashToAdd);

        if (cashToAdd % 5 != 0)
        {
            throw new ArgumentException("cash should be multiple of five", nameof(cashToAdd));
        }

        Cash += cashToAdd;
    }
}