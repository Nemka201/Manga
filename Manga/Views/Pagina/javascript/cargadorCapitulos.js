const list_capitulos = [
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",

    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",

    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",
    "Vol.1: To Suffer",

    "Vol.2: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",

    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",
    "Vol.: To Suffer",

    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",

    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",
    "Vol.2: To Suffer",

]



let listaCap = document.getElementById('listaCap');
let listaCapBotones = document.querySelector('.PaginationCapitulos');
const cantidad = 15;


function CargadorDeCaps (indiceStart, cantidad) {
    listaCap.innerHTML = "";
    let indiceEnd = indiceStart * cantidad + cantidad;
    let newList = list_capitulos.slice(indiceStart * cantidad, indiceEnd)

    for (let index = 0; index < newList.length; index++) {
        listaCap.innerHTML += `
        <a class="w-100 h-100" href="./Chapter.html">
        <div class="d-flex">
            <p>Cap. ${index + 1 + (indiceStart * cantidad) } - ${newList[index]}</p>
            <p>567 day ago</p>
        </div>
        </a>`;
    }
}

CargadorDeCaps( 0, cantidad);


function CargadorDeBotonesCaps (cantidad) {
    let botonesEnd = Math.ceil(list_capitulos.length / cantidad);

    for (let index = 0; index < botonesEnd; index++) {
        listaCapBotones.innerHTML += `
        <button id="${index}-botonCap" class="botonCap" >
            ${index*cantidad} - ${(index+1)*cantidad}
        </button>`;
    }
}

CargadorDeBotonesCaps (cantidad);

let BotonesCaps = document.querySelectorAll('.botonCap');

BotonesCaps.forEach((item) => {
    item.addEventListener("click", () => {
        CargadorDeCaps( parseInt(item.id[0]), cantidad);
    });
});