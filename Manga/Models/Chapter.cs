namespace Manga.Models
{
    public partial class Chapter
    {
        public Capitulo Capitulo { get; set; }
        public string rutaFolder { get; set; }
        public string rutaPortada { get; set; }
        public Serie Serie { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Chapter(Capitulo c, Serie s, List<Categoria> catList)
        {
            rutaFolder = $"~/media/capitulos/{s.Nombre}/{c.NumeroCapitulo}";
            rutaPortada = "~/media/serie/" + s.RutaPortada;
            Capitulo = c;
            Serie = s;
            Serie.CatList = Serie.Categoria.Split("-").ToList();
            for (int i=0; i<Serie.Categoria.Split("-").Length; i++)
            {
                Categorias.Add(catList.Where( e => e.Idcategoria == Convert.ToInt32(Serie.CatList[i])).First());
            }
        }
    }
}
