
namespace CashDustributor.Tests.Unit;

internal class CashDistributorProccessor()
{
    public int Cash => _bankNotes.Sum(x => x.Value);

    private readonly List<BaseBankNote> _bankNotes = new();

    public IReadOnlyCollection<BaseBankNote> BankNotes => _bankNotes.AsReadOnly();

    internal void AddBanknotes(BaseBankNote bankNoteToAdd, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _bankNotes.Add(bankNoteToAdd);
        }
    }

    internal void RemoveBanknotes(List<BaseBankNote> bankNotesToRemove)
    {
        foreach (var item in bankNotesToRemove)
        {
            _bankNotes.Remove(item);
        }
    }
}