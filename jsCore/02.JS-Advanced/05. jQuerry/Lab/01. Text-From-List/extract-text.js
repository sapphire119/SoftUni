function extractText() {
    let elements = $('li')
        .toArray()
        .map(e => e.textContent)
        .join(", ");
    $("#result").append(elements);
}