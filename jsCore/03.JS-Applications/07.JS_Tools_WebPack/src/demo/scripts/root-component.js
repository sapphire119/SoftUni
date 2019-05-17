class RootComponent {
    constructor(element) {
        this.element = element;
    }

    render() {
        let headingElement = document.createElement("h2");
        headingElement.textContent = "Steps to complete:";

        this.element.appendChild(headingElement);
    }
}

export default RootComponent;