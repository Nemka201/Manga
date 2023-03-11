/* Funcion del script: 
1- carga filtros, 2- Evento para desplegar la lista de filtros,
3- Evento para hacer un div parecer un input checbox,
4- Evento para seleccionar no mas de 3 filtros en categorias,
5- Evento formulario donde filtra las series segun los filtros selecionados
*/

// lista de mangas con categorias para cargar al html
let lMangas = 
[{nombre: "Naruto", Categorias: ["Action","Adventure","Fantasy"]},
{nombre: "Soul Eater", Categorias: ["Action","Fantasy"]},
{nombre: "Bleach", Categorias: ["Action","Fantasy"]},
{nombre: "Dragon Ball", Categorias: ["Action","Adventure","Fantasy"]},
{nombre: "Kimi no Todoke", Categorias: ["Romance","Slice of Life"]},
{nombre: "Neon Genesis Evangelion", Categorias: ["Action","Mecha","Philosophical","Drama"]},
{nombre: "Beelzebub", Categorias: ["Action","Fantasy","Comedy"]},
{nombre: "Steins Gate", Categorias: ["Philosophical","Drama","Tragedy","Sci-Fi"]},
{nombre: "Gantz", Categorias: ["Mystery","Ecchi","Action","Adventure","Philosophical","Tragedy","Sci-Fi","Survival"]},
{nombre: "Kokou No Hito", Categorias: ["Adventure","Drama","Psychological","Sports","Tragedy"]},
{nombre: "Sora No Otoshimono", Categorias: ["Ecchi","Comedy","Drama","Fantasy","Psychological","Tragedy","Harem"]},
{nombre: "KINGDOM", Categorias: ["Action","Historical","Drama","Military"]},
{nombre: "Full Metal Panic!", Categorias: ["Action","Comedy","Drama","Fantasy","Mecha","Romance"]},
{nombre: "Vagabond", Categorias: ["Action","Historical","Slice of Life","Philosophical"]},
{nombre: "The World God Only Knows", Categorias: ["Comedy","Drama","Fantasy","Harem"]},
{nombre: "Berserk", Categorias: ["Action","Adventure","Fantasy","Tragedy","Military","Philosophical"]},
{nombre: "Rosario To Vampire", Categorias: ["Action","Ecchi","Drama","Fantasy","Harem"]},
{nombre: "", Categorias: []},
{nombre: "", Categorias: []},
];

// lista de Categorias
let lCategorias = 
["Action","Adventure","Comedy","Drama",
"Fantasy","Historical","Loli","Mecha",
"Mystery","Harem","Military","Magic",
"Ecchi","Music","Philosophical","Romance"
,"Sports","Sci-Fi","Slice of Life",
"Survival","Tragedy"];

// menu con los distintos tipos de filtro
const Menu = document.querySelector(".TiposDeFiltrado");
// boton que despliega los filtros de categoría
let btnCategory = Menu.querySelector(".boton-category");
// contenedor de las categorias
let lContCategory = Menu.querySelector(".category-cont");
// contenedor de las series mostradas en la pagina filtro
let cSerieFiltro = document.querySelector(".lSerieFiltro");
//let primerUsoFiltro = false;

// cargo las categorias
for (let index = 0; index < lCategorias.length; index++) {
   lContCategory.innerHTML += `
   <div class="group-checkbox d-flex">
      <p>${lCategorias[index]}</p>
      <div>${lCategorias[index]}</div>
   </div>`;
}

// lista de los div que son como radio
let lRadioButton = Menu.querySelectorAll(".group-checkbox div");
// lista de los div seleccionados
let lSelectedRadio;
// formulario categoria
const formCategory = Menu.querySelector(".form-category");

// Evento que cuando tocas el boton aparece/desaparece el formulario de filtro
btnCategory.addEventListener("click", () => {
   formCategory.classList.toggle("displayNone");
   btnCategory.classList.toggle("cbtnFiltrar");
});

// Pone el evento de click al radio y la clase selectedRadio al seleccionado
lRadioButton.forEach( (item) => {
    item.addEventListener("click", () => {
      lSelectedRadio = Menu.querySelectorAll(".selectedRadio");

      // no se puede seleccionar mas de 3 categorias a la vez y también se fija por si quieres deselectionar un boton
      if (lSelectedRadio.length < 3 || item.classList.contains("selectedRadio")) {
         item.classList.toggle("selectedRadio");
      } 
   });
 });

// cargo los mangas con su categorias ocultas
 lMangas.forEach((item)=> {
    cSerieFiltro.innerHTML += 
    `
<div class="serieAgregada d-flex col-4">

    <div class="serieAgregadaImg d-flex">
        <a class="w-100 h-100" href="../template/DetailManga.html">
            <img src="../media/svg/Star.png" alt="">
        </a>
    </div>

    <div class="serieAgregadaDatos d-flex flex-column">
        <a href="../template/DetailManga.html"><h3>${item.nombre}</h3></a>
    
    
        <div class="serieAgregadaDescpricion">
            <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Laborum tenetur
                nesciunt modi hic eveniet? Nam, quis atque. Quas iste nam, unde quo
                minus laborum possimus beatae et aperiam, laboriosam placeat!
            </p> <span>...</span>

        </div>

        <d class="serieAgregadaCapitulo">Ch. XXX</d>
        <d class="categoriaSerie displayNone">${item.Categorias}</d>

        <p class="serieAgregadaNota"><img src="../media/svg/Star.png" alt=""> 4.8</p>

    </div>

</div>`;
});

// lista de cada Manga cargado en el html
let lMangasViewSave = cSerieFiltro.querySelectorAll(".serieAgregada");

// Evento del form
formCategory.addEventListener("submit", (e) => {
    // Detiene que cargue la pagina
    e.preventDefault();

    // lista de los filtros seleccionados
   let lFiltros = formCategory.querySelectorAll(".selectedRadio");

   // si no seleccionaste ningun filtro, muestra todos los mangas
   if (lFiltros.length > 0) {

      // limpia la lista de la clase "displayNone"
      lMangasViewSave.forEach((itemM) => itemM.classList.remove("displayNone"));


      /* Por cada categoria seleccionada se fija si existe en 
         cada manga , sino cumple lo oculta al manga  */
      lFiltros.forEach((item)=> {

        lMangasViewSave.forEach((itemManga) => {
    
            if (!itemManga.querySelector(".categoriaSerie").innerHTML
            .includes(item.innerHTML)) {
                if (!itemManga.classList.contains("displayNone")) {
                    itemManga.classList +=  " displayNone";
                }
            }
        });

      });
   } 

   else {
    lMangasViewSave.forEach((itemM) => itemM.classList.remove("displayNone"));
   }
});


