namespace FinanceBlockchain.Application.UseCases.CreateTransaction
{
    public class CreateTransactionRequest
    {
        public decimal Valor { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string HashTransacao { get; set; }
        public string AssinaturaDigital { get; set; }
    }
}
