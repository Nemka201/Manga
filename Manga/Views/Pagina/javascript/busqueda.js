
const contListaSeries = document.querySelector(".listaAgregados");
let lSeries = contListaSeries.querySelectorAll(".serieAgregada");
let tSeries = [];
let inpBusqueda = document.querySelector(".contBuscador input");

inpBusqueda.addEventListener("input", () => {

    if (inpBusqueda.value.length > 1) {
        lSeries.forEach((item) => {

            if (!item.querySelector("h3").innerHTML.includes(inpBusqueda.value)) {
                item.classList +=  " activoLista";
            }
            else {
                item.classList.remove("activoLista")
            }
        });
    }
    else {
        lSeries.forEach((i)=>i.classList.remove("activoLista"));
    }

});