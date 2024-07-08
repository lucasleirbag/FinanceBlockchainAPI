namespace FinanceBlockchain.Application.UseCases.MineBlock
{
    public class MineBlockResponse
    {
        public bool Success { get; set; }
        public Guid BlockId { get; set; }
    }
}
