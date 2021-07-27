using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SiteLanche.Models;
using SiteLanche.Repositories;
using SiteLanche.ViewModels;

namespace SiteLanche.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;

        internal ICategoriaRepository _categoriaRepository { get; }

        public LancheController(ILanchesRepository lancheRepository,ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public  IActionResult List(string categoria)
        {
            //string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                ///////////////////////////////////////////////////////////////////////////////////
                //if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                //    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Normal")).OrderBy(p => p.Nome);
                //else
                //    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Natural")).OrderBy(p => p.Nome);
                ////////////////////////////////////////////////////////////////////////////////////

                lanches = _lancheRepository.Lanches
                           .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                           .OrderBy(p => p.Nome);

                categoriaAtual = categoria;
            }
            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lanchesListViewModel);


            var lancheListViewsModel = new LancheListViewModel();
            lancheListViewsModel.Lanches = _lancheRepository.Lanches;
            lancheListViewsModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewsModel);
        }
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            if (lanche == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(lanche);
        }
        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanche;
            string _categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanche = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            }
            else
            {
                lanche = _lancheRepository.Lanches.Where(l => l.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lanche/List.cshtml",new LancheListViewModel {Lanches=lanche,CategoriaAtual="Todos Os Lanches" });
        }
    }
}
