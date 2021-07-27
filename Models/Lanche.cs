using System.ComponentModel.DataAnnotations;

namespace SiteLanche.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string DescricaoCurta { get; set; }
        [StringLength(200)]
        public string DescricaoDetalhada { get; set; }
        public double Preco { get; set; }
        [StringLength(300)]
        public string ImagemUrl { get; set; }
        [StringLength(300)]
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
