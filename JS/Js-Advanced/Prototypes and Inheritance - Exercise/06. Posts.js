function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = `Post: ${this.title}\nContent: ${this.content}`;
            return result;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString() + '\n' +
            `Rating: ${this.likes - this.dislikes}`;
            
            if (this.comments.length > 0) {
                let commentsFormated = this.comments.map(x => ' * ' + x).join('\n');
                result += "\nComments:\n" + commentsFormated;
            }

            /*for (const comment of comments) {
                result += ` * ${comment}\n`
            }*/

            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views){
            super(title, content);
            this.views = views;
        }

        view() {
            this.views++; 
            return this
        }

        toString() {
            let result = super.toString() + '\n' + `Views: ${this.views}`;

            return result;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

let classesObj = solve();
let Post = classesObj.Post;
let SocialMediaPost = classesObj.SocialMediaPost;
let BlogPost = classesObj.BlogPost;

let post = new Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
