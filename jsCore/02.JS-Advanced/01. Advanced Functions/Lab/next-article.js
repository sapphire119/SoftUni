function getArticleGenerator(articles) {
    let test = (function () {
        let index = 0;
        debugger;

        return () => {
            debugger;
            if (index <= articles.length - 1){
                let contentDiv = document.getElementById("content");
                let articleEle = document.createElement("article");

                articleEle.textContent = articles[index++];

                contentDiv.appendChild(articleEle);
            }
        }
    })();

    return test;
}

const test1 = getArticleGenerator()