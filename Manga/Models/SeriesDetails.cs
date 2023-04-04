namespace Manga.Models
{
    public partial class SeriesDetail
    {
        public List<Capitulo> Capitulos { get; set; }
        public string rutaPortada { get; set; }
        public Serie Serie { get; set; }
        public List<Categoria> Categorias { get; set; }
        public SeriesDetail(Serie s, List<Capitulo> capList, List<Categoria> catList)
        {
            rutaPortada = "~/media/serie/" + s.RutaPortada;
            Capitulos = capList;
            Serie = s;
            Serie.CatList = Serie.Categoria.Split("-").ToList();
            Categorias = new List<Categoria>();
            for (int i=0; i<Serie.Categoria.Split("-").Length; i++)
            {
                Categoria cat = catList.Where ( c => c.Idcategoria == Convert.ToInt32(Serie.CatList[i])).FirstOrDefault();
                Categorias.Add(cat);
            }
        }
    }
}
