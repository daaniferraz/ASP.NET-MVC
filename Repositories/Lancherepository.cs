using Microsoft.EntityFrameworkCore;
using SiteLanche.Models;
using SiteLanche.Context;
using System.Collections.Generic;
using System.Linq;

namespace SiteLanche.Repositories
{
    public class Lancherepository : ILanchesRepository
    {
        private readonly AppDbContext _context;

        public Lancherepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(p=>p.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
