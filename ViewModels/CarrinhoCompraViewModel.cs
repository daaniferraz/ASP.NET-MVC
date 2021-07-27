using SiteLanche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteLanche.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public double CarrinhoCompraTotal { get; set; }
        public ICollection<Categoria> Categoria { get; set; }
    }
}
