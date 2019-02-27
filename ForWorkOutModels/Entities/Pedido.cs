using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForWorkOutModels.Entities
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        public long Id {get;set;}

        public decimal Valor {get;set;}

        public DateTime Data {get;set;}

        public string Status {get;set;}

        public virtual List<Produtos> Produtos {get;set;}
    }
}