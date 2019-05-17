function result() {
	let titleInputValue = document.getElementById('createTitle').value;
	let contentInputValue = document.getElementById('createContent').value;

	if(titleInputValue && contentInputValue){
		let articlesList = document.getElementById('articles');

		let articleTag = document.createElement('article');

		let h3tag = document.createElement('h3');

		h3tag.textContent = titleInputValue;
		
		let paragraphTag = document.createElement('p');

		paragraphTag.textContent = contentInputValue;

		articleTag.appendChild(h3tag);
		articleTag.appendChild(paragraphTag);

		articlesList.appendChild(articleTag);
	}

	document.getElementById('createTitle').value = '';
	document.getElementById('createContent').value = '';
}