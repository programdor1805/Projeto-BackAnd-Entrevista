namespace ecommerce.PordutoAPI.Data.ValueObjects
{
    public class ProdutoVO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int DepartamentoId { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }     
       
    }
}
