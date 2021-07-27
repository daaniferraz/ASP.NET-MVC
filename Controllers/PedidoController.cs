using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SiteLanche.Models;
using SiteLanche.Repositories;
using System.Collections.Generic;

namespace SiteLanche.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)

        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CheckOut(Pedido pedido)
        {
            double precoTotalPedido = 0.0;
            int totalItensPedido = 0;

            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();

            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItens = itens;

           if ( _carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("","Seu Carrinho Está Vazio");

            }
            //calcular o total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            //atribuit o total de itens do pedido 
            pedido.TotalItensPedido = totalItensPedido;

            //atribuit o total do pedido ao pedido
            pedido.PedidoTotal = totalItensPedido;


            if (ModelState.IsValid)
            {
                pedido.PedidoTotal = _carrinhoCompra.GetCarrinhoCompraTotal();
                _pedidoRepository.CriarPedido(pedido);
                
                TempData["Cliente"] = pedido.Nome;
                TempData["NumeroDoPedido"] = pedido.PedidoId;
                TempData["DataPedido"] = pedido.PedidoEnviado;
                TempData["TotalPedido"] = _carrinhoCompra.GetCarrinhoCompraTotal();
                _carrinhoCompra.LimparCarrinho();
                return RedirectToAction("CheckoutCompleto");
            }
            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.NumeroPedido = TempData["NumeroDoPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu Pedido";
            return View();
        }
    }
}
