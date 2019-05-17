function toggle() {
    let spanElement = document.getElementsByClassName('button')[0];
    let divElement = document.getElementById('extra');

    spanElement.textContent === "More" ?
        spanElement.textContent = "Less" :
        spanElement.textContent = "More";

    divElement.style.display === "block" ?
        divElement.style.display = "none" :
        divElement.style.display = "block";
    // let $span = $("span.button");
    // let $div = $("#extra");
    // $span.text() === "More" ? $span.text("Less") : $span.text("More");
    // $div.toggle();
}