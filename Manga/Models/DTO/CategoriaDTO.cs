using Manga.Models.Entities;

namespace Manga.Models.DTO
{
    public partial class CategoriaDTO
    {
        public List<Serie> Series { get; set; }
        public Categoria Categoria { get; set; }
        public CategoriaDTO(Categoria c)
        {
            Series = new List<Serie>();
            Categoria = c;
        }
        public CategoriaDTO(List<Serie> s, Categoria c)
        {
            Series = s;
            Categoria = c;
        }
    }
}
