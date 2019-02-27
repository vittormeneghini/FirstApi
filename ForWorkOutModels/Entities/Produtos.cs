using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForWorkOutModels.Entities
{
    [Table("produtos")]
    public class Produtos
    {
        [Key]
        public long Id {get;set;}    

        public long IdPedido {get;set;}

        public decimal PrecoProduto {get;set;}

        public long Quantidade {get;set;} 

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido {get;set;}    
    }
}