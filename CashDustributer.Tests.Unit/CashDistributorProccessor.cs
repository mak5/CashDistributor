
namespace CashDustributor.Tests.Unit;

internal class CashDistributorProccessor(int cash)
{
    public int Cash { get; internal set; } = cash;

    public void AddCash(int cashToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cashToAdd);

        Cash += cashToAdd;
    }
}