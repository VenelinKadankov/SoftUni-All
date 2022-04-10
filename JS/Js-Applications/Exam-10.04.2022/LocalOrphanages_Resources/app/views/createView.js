import { html } from "../../node_modules/lit-html/lit-html.js";
import * as orphService from "../services/orphService.js";

const createTemplate = (onSubmit) => html`
  <!-- Create Page (Only for logged-in users) -->
  <section id="create-page" class="auth">
            <form id="create" @submit=${onSubmit}>
                <h1 class="title">Create Post</h1>

                <article class="input-group">
                    <label for="title">Post Title</label>
                    <input type="title" name="title" id="title">
                </article>

                <article class="input-group">
                    <label for="description">Description of the needs </label>
                    <input type="text" name="description" id="description">
                </article>

                <article class="input-group">
                    <label for="imageUrl"> Needed materials image </label>
                    <input type="text" name="imageUrl" id="imageUrl">
                </article>

                <article class="input-group">
                    <label for="address">Address of the orphanage</label>
                    <input type="text" name="address" id="address">
                </article>

                <article class="input-group">
                    <label for="phone">Phone number of orphanage employee</label>
                    <input type="text" name="phone" id="phone">
                </article>

                <input type="submit" class="btn submit" value="Create Post">
            </form>
        </section>`;

export const createPage = (ctx) => {
  if (!ctx.user) {
    ctx.page.redirect("/");
  }

  const onSubmit = (e) => {
    e.preventDefault();

    let post = Object.fromEntries(new FormData(e.currentTarget));

    if (Object.values(post).some((x) => !x)) {
      window.alert("You must fill all!!");
      return;
    }

    orphService
      .create(post.title,
        post.description,
        post.imageUrl,
        post.address,
        post.phone)
      .then((res) => {
        console.log(res);
        ctx.page.redirect("/home");
      });
  };

  return ctx.render(createTemplate(onSubmit));
};
