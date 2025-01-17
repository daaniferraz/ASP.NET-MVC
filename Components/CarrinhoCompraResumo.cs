﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteLanche.Models;
using SiteLanche.ViewModels;

namespace SiteLanche.Components
{
    
        public class CarrinhoCompraResumo : ViewComponent
        {
            private readonly CarrinhoCompra _carrinhoCompra;

            public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
            {
                _carrinhoCompra = carrinhoCompra;
            }

            public IViewComponentResult Invoke()
            {
                var items = _carrinhoCompra.GetCarrinhoCompraItens();
                //para testar 
                //var items = new List<CarrinhoCompraItem>() { new CarrinhoCompraItem(), new CarrinhoCompraItem() };
                _carrinhoCompra.CarrinhoCompraItens = items;

                var carrinhoCompraVM = new CarrinhoCompraViewModel
                {
                    CarrinhoCompra = _carrinhoCompra,
                    CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
                };
                return View(carrinhoCompraVM);
            }
        }
    }
