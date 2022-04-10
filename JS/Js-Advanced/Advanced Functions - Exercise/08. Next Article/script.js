function getArticleGenerator(articles) {
    const div = document.getElementById('content');

    let articlesToShow = articles.slice(0);

    function showNext() {
        if (articlesToShow.length > 0) {
            let text = articlesToShow.shift();
            let article = document.createElement('ARTICLE');
            let currentParagraph = document.createElement('P');
            currentParagraph.textContent = text;

            article.appendChild(currentParagraph);
            div.appendChild(article);
        }
    }

    return showNext;
}