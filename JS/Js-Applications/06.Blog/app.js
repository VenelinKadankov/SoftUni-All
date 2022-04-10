async function attachEvents() { 
    const postsLoadBtn = document.getElementById('btnLoadPosts');
    const viewPostsBtn = document.getElementById('btnViewPost');
    const postsSection = document.getElementById('posts');
    const bodyContainer = document.getElementById('post-title');
    const ulContainerPosts = document.getElementById('post-body');
    const ulContainerComments = document.getElementById('post-comments');

    let promise = await fetch('http://localhost:3030/jsonstore/blog/posts');
    let postsData = await promise.json();

    postsLoadBtn.addEventListener('click', (event) => {
        postsSection.innerHTML = '';

        Object.entries(postsData).forEach(key => {
            let postElement = e('option', { id: `${key[1].id}`, value: `${key}` }, `${key[1].title}`);

            postsSection.appendChild(postElement);
        });
    });

    viewPostsBtn.addEventListener('click', async function (event) {
        bodyContainer.textContent = '';
        ulContainerPosts.innerHTML = '';
        ulContainerComments.innerHTML = '';

        let currentPostId = postsSection.value.split(',')[0];

        let promiseAllPost = await fetch(`http://localhost:3030/jsonstore/blog/comments`);
        let dataSinglePost = await promiseAllPost.json();

        let values = Object.values(dataSinglePost);

        let relevantPosts = values.filter(p => p.postId === currentPostId);

        bodyContainer.textContent = Object.values(postsData).find(p => p.id === currentPostId).title;
        ulContainerPosts.appendChild(e('p', {}, Object.values(postsData).find(p => p.id === currentPostId).body));

        relevantPosts.forEach(p => {
            ulContainerComments.appendChild(e('li', {id: `${p.postId}`}, `${p.text}`));
        });
    });


    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}

attachEvents();