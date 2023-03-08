
{/* <select asp-for="Categoria">
<option value="">--Seleccione una opción--</option>
@foreach (var categoria in categorias){

<option value="@categoria.Idcategoria">@categoria.Nombre</option>
} */}

let divACategorias = document.querySelector(".aCategorias");
let contSelectCategorias = divACategorias.querySelector(".contSelectCategorias");
let entradas = 1;
let botonEntCategoria = divACategorias.querySelector(".botonEntCategoria");
let select = contSelectCategorias.querySelector("select");


botonEntCategoria.addEventListener("click", () => {
    entradas++;
    contSelectCategorias.innerHTML = "";
    for (let index = 1; index <= entradas; index++) {
        contSelectCategorias.innerHTML += `${select.outerHTML}`;
    }
});
