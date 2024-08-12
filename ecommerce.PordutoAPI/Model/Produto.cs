using ecommerce.PordutoAPI.Model.Base;

namespace ecommerce.PordutoAPI.Model
{
    public class Produto : BaseEntity
    {
        public string Codigo { get; set; } 
        public string Descricao { get; set; }      
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int DepartamentoId { get; set; }  
    
    }


}
