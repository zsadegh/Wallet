namespace Api.ViewModel
{
    public class TransferWalletRequest:BaseWalletRequest
    {
        public Guid TargetWalletId { get; set; }
    }
}
