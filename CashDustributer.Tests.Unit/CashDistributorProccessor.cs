

namespace CashDustributor.Tests.Unit;

internal class CashDistributorProccessor()
{
    public int CashAmount => _bankNotes.Sum(x => x.Value);
    public IReadOnlyCollection<BaseBankNote> BankNotes => _bankNotes.AsReadOnly();
    private List<BaseBankNote> _bankNotes = [];

    public void AddBanknotes(BaseBankNote bankNote, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _bankNotes.Add(bankNote);
        }
    }

    public void RemoveBanknotes(List<BaseBankNote> bankNotesToRemove)
    {
        foreach (var bankNote in bankNotesToRemove)
        {
            _bankNotes.Remove(bankNote);
        }
    }
}