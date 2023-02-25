

const Menu = document.querySelector(".TiposDeFiltrado");
let btnCategory = Menu.querySelector(".boton-category");
let formCategory = Menu.querySelector(".form-category");
let lContCategory = Menu.querySelector(".category-cont");


for (let index = 0; index < 53; index++) {
   lContCategory.innerHTML += `
   <div class="group-checkbox d-flex">
      <p>Lolis</p>
      <div></div>
   </div>`;
}

let lRadioButton = Menu.querySelectorAll(".group-checkbox div");

btnCategory.addEventListener("click", () => {
   formCategory.classList.toggle("activoLista");
   btnCategory.classList.toggle("cbtnFiltrar");
});

lRadioButton.forEach( (item) => {
    item.addEventListener("click", () => item.classList.toggle("selectedRadio"));
    console.log(lRadioButton);
 });




