using SiteLanche.Models;
using System.Collections.Generic;

namespace SiteLanche.Repositories
{
   public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
