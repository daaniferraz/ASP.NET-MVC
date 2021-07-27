using SiteLanche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteLanche.Repositories
{
   public  interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
