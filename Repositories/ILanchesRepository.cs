using SiteLanche.Models;
using System.Collections.Generic;

namespace SiteLanche.Repositories
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);       
       
    }
}
