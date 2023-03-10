/* Funcion del script: 
1- carga filtros, 2- Evento para desplegar la lista de filtros,
3- Evento para hacer un div parecer un input checbox,
4- Evento para seleccionar no mas de 3 filtros en categorias,
5- Evento formulario donde filtra las series a ver
*/
const Menu = document.querySelector(".TiposDeFiltrado");
let btnCategory = Menu.querySelector(".boton-category");
let formCategory = Menu.querySelector(".form-category");
let lContCategory = Menu.querySelector(".category-cont");
let primerUsoFiltro = false;

for (let index = 0; index < 53; index++) {
   lContCategory.innerHTML += `
   <div class="group-checkbox d-flex">
      <p>Lolis</p>
      <div></div>
   </div>`;
}

let lRadioButton = Menu.querySelectorAll(".group-checkbox div");
let lSelectedRadio = Menu.querySelectorAll(".group-checkbox selectedRadio");

btnCategory.addEventListener("click", () => {
   formCategory.classList.toggle("displayNone");
   btnCategory.classList.toggle("cbtnFiltrar");
});

// Pone el evento de click al radio y la clase selectedRadio al seleccionado
lRadioButton.forEach( (item) => {
    item.addEventListener("click", () => {
      lSelectedRadio = Menu.querySelectorAll(".group-checkbox selectedRadio");
      
      if (lSelectedRadio.length > 3) {
         item.classList.toggle("selectedRadio");
      } else {

      }

      
   });
 });




