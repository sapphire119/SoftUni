function solve() {

  function increment(element){
    let click = 1;
    let tokens = element.nextElementSibling.textContent.split(' ');
    let currentClick = Number(tokens[1]);
    element.nextElementSibling.textContent = `${tokens[0]} ${currentClick + click} ${tokens[2]}`;
    return element;
  }

  document.querySelectorAll('#exercise div a').forEach(element => {
    element.addEventListener('click', () => increment(element))
  })
};