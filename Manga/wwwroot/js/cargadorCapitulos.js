// Funcion del script: enumera, pone los capitulos y crea los botones de paginacion


const contArrayCapitulos = document.querySelector('.ListaDeCapitulo');
let arrayCapitulos = contArrayCapitulos.querySelectorAll('.caps');
let listaCap = document.getElementById('listaCap');
let listaCapBotones = document.querySelector('.PaginationCapitulos');
const cantidad = 15;


// Funcion que carga los de un numero de inicio a un final
function CargadorDeCaps (indiceStart, cantidad) {
    // primero vaciamos la lista
    listaCap.innerHTML = "";
    // calculamos el final para cortar la lista con un principio y fin
    let indiceEnd = contArrayCapitulos.length < 15? contArrayCapitulos.length : indiceStart * cantidad + cantidad;

    // En el bucle metemos uno por uno los capitulos al html con los datos de la lista
    for (let index = indiceStart * cantidad; index < indiceEnd; index++) {
        listaCap.innerHTML += `${arrayCapitulos[index].outerHTML}`;
    }
}

// Lo inicialisamos para que no este vacia la lista de cap de la pagina al cargar 
CargadorDeCaps( 0, cantidad);


// Funcion que atraves del numero de capitulos calcula y crea los botones de paginacion
function CargadorDeBotonesCaps (cantidad) {
    // calcula los botones a crear tirando para arriba
    let botonesEnd = Math.ceil(arrayCapitulos.length / cantidad);

    // agrega al html los botontes con su id propio para hacer funcionar la paginacion
    for (let index = 0; index < botonesEnd; index++) {
        listaCapBotones.innerHTML += `
        <button id="${index}-botonCap" class="botonCap" >
            ${index*cantidad} - ${(index+1)*cantidad}
        </button>`;
    }
}

// Pone los botones en el html
CargadorDeBotonesCaps (cantidad);

// Hace una lista con los botones creados
let BotonesCaps = document.querySelectorAll('.botonCap');

// Les pone el evento a cada uno para que cuando se haga click cargue los capiyulos
BotonesCaps.forEach((item) => {
    item.addEventListener("click", () => {
        // carga los capitulos con la funcion y le pasa como parametro el el id del boton 
        CargadorDeCaps( parseInt(item.id[0]), cantidad);
    });
});

