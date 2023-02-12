namespace Manga.Models
{
    public partial class Tendencia
    {
        public List<Serie> seriesList { get; set; }
        public Serie PrimerItemS { get; set; }

        public Tendencia(List<Series> sL, List<Capitulos> cL )
        {
            seriesList = sL.OrderByDescending(x => x.Favoritos)
                .ThenByDescending(x => x.Idserie).ToList().GetRange(0, 3);

            PrimerItemS = seriesList.First();
            seriesList.RemoveAt(0);

        }
    }

        public partial class UltimosAgregados
    {
        public List<Serie> seriesList { get; set; }
        public List<Capitulo> capList { get; set; } = new List<Capitulos>();

        public UltimosAgregados(List<Series> sL, List<Capitulos> cL )
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
