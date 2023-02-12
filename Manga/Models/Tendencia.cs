namespace Manga.Models
{
    public partial class Tendencia
    {
        public List<Serie> seriales { get; set; }
        public List<Capitulo> capitulos { get; set; } = new List<Capitulos>();

        public Tendencia(List<Series> sL, List<Capitulos> cL )
        {
            seriesList = sL.OrderByDescending(x => x.Favoritos)
                .ThenByDescending(x => x.Idserie).ToList().GetRange(0, 3);

            foreach (var item in seriesList)
            {
                capList.Add(cL
                    .Find( x => x.Idserie == item.Idserie 
                    && item.Capitulos.ToString() == x.Titulo));
            }
        }
    }
}
