import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as orphService from "../services/orphService.js";

const ownPostsTemplate = (posts = []) => html`
  <!-- My Posts -->
  <section id="my-posts-page">
    <h1 class="title">My Posts</h1>

    <!-- Display a div with information about every post (if any)-->
    <div class="my-posts">
      ${posts.map((p) => postTemplate(p))}

      ${posts.length == 0
        ? html` <div class="no-events">
            <h1 class="title no-posts-title">You have no posts yet!</h1>
          </div>`
        : nothing}
    </div>
  </section>
`;

const postTemplate = (post) => html` <div class="post">
  <h2 class="post-title">${post.title}</h2>
  <img class="post-image" src="${post.imageUrl}" alt="Material Image" />
  <div class="btn-wrapper">
    <a href="/details/${post._id}" class="details-btn btn">Details</a>
  </div>
</div>`;

export const ownPostsPage = (ctx) => {
  orphService
    .getOwn(ctx.user._id)
    .then((res) => ctx.render(ownPostsTemplate(res)));
};
