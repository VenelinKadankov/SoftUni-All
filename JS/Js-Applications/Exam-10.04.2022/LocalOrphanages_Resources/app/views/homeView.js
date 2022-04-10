import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as orphService from "../services/orphService.js";

const homeTemplate = (orphs = []) => html` <!-- Dashboard -->
  <section id="dashboard-page">
    <h1 class="title">All Posts</h1>

    <!-- Display a div with information about every post (if any)-->
    <div class="all-posts">
      ${orphs.map((t) => postTemplateHome(t))};
      ${orphs.length == 0
        ? html`<h1 class="title no-posts-title">No posts yet!</h1>`
        : nothing}
    </div>
  </section>`;

const postTemplateHome = (post) => html` <div class="post">
  <h2 class="post-title">${post.title}</h2>
  <img class="post-image" src="${post.imageUrl}" alt="Material Image" />
  <div class="btn-wrapper">
    <a href="/details/${post._id}" class="details-btn btn">Details</a>
  </div>
</div>`;

export const homePage = (ctx) => {
  orphService.getAll().then((res) => ctx.render(homeTemplate(res)));
};
