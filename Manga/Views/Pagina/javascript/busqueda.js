
const contListaSeries = document.querySelector(".listaAgregados");
let lSeries = contListaSeries.querySelectorAll(".serieAgregada");
let inpBusqueda = document.querySelector(".contBuscador input");

inpBusqueda.addEventListener("input", () => {

    if (inpBusqueda.value.length > 1) {
        lSeries.forEach((item) => {

            if (!item.querySelector("h3").innerHTML
            .toLocaleLowerCase().includes(inpBusqueda.value)) {
                item.classList +=  " displayNone";
            }
            else {
                item.classList.remove("displayNone")
            }
        });
    }
    else {
        lSeries.forEach((i)=>i.classList.remove("displayNone"));
    }

});