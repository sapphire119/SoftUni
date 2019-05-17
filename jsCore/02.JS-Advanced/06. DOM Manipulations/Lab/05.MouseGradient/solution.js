function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    gradientElement.addEventListener('mousemove', mouseoverEvent);

    function mouseoverEvent(event) {
        let currentTarget = event.target;
        // console.log(currentTarget.offsetHeight);
        // console.log(currentTarget.offsetWidth);
        // console.log(event.offsetX);
        // console.log(event.offsetY);
        let diffX = (event.offsetX / currentTarget.clientWidth) * 100;
        let endResult = Math.floor(diffX);

        let resultElement = document.getElementById('result');
        resultElement.textContent = `${endResult}%`;
        // let diffY = currentTarget.offsetWidth - event.offsetY;

    }
}