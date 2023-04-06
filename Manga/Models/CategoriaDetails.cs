namespace Manga.Models
{
    public partial class CategoriaDetail
    {
        public List<Serie> Series { get; set; }
        public Categoria Categoria { get; set; }
        public CategoriaDetail(Categoria c) {
            Series = new List<Serie>();
            Categoria = c;
        }
        public CategoriaDetail(List<Serie> s, Categoria c) {
            Series = s;
            Categoria = c;
        }
    }
}
