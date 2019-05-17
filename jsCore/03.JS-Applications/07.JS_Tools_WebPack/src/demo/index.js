import RootComponent from "./scripts/root-component";

window.onload = () => {
    let root = document.getElementById("#root");
    let rootComponent = new RootComponent(root);
    rootComponent.render();
};