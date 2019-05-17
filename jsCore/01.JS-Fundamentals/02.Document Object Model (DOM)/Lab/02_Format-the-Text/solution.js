function solve() {
    let input = document.getElementById('input');

    let output = document.getElementById('output');
    let paragTag = document.createElement('p');
    

    let sentences = input.innerHTML.split('.').filter(n => n);

    for(let i = 0; i < sentences.length; i++){
      let currentSentence = sentences[i].trim().concat('. ');

      if(currentSentence.length <= 0) {
        continue;
      }
      
      if((i % 3 === 0 && i > 0)){
        let tempParag = document.createElement('p');
        tempParag.textContent = paragTag.textContent;
        output.appendChild(tempParag);
        paragTag.textContent = '';
      }

      paragTag.textContent += currentSentence;

      if(i == sentences.length - 1){
        debugger;
        output.appendChild(paragTag);
      }
    }
}