using System.Collections.Generic;
using ForWorkOutModels.Entities;

namespace ForWorkOutApplication.ModelsHelper
{
    public class PedidoProduto
    {
        public string Status {get;set;}

        public List<Produtos> Produtos {get;set;}
    }
}