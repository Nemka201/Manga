

const Menu = document.querySelector(".MenuSelect");
let btnSelect = Menu.querySelector(".selectBoton");
let btTexto = Menu.querySelector(".sbTexto");
let opciones = Menu.querySelector(".options");
let opcLista = opciones.querySelectorAll(".option");

 let toggleOpciones = () => {opciones.classList.toggle("activoLista")}

btnSelect.addEventListener("click", toggleOpciones);

opcLista.forEach( (item) => {
    item.addEventListener("click", () => { 
        btTexto.innerHTML = item.innerHTML;
        toggleOpciones();
    });
});