import { html } from "../../node_modules/lit-html/lit-html.js";
import * as orphService from "../services/orphService.js";

const editTemplate = (post, onSubmit) => html`
 <!-- Edit Page (Only for logged-in users) -->
 <section id="edit-page" class="auth">
            <form id="edit" @submit=${onSubmit}>
                <h1 class="title">Edit Post</h1>

                <article class="input-group">
                    <label for="title">Post Title</label>
                    <input type="title" name="title" id="title" value="${post.title}">
                </article>

                <article class="input-group">
                    <label for="description">Description of the needs </label>
                    <input type="text" name="description" id="description" value="${post.description}">
                </article>

                <article class="input-group">
                    <label for="imageUrl"> Needed materials image </label>
                    <input type="text" name="imageUrl" id="imageUrl" value="${post.imageUrl}">
                </article>

                <article class="input-group">
                    <label for="address">Address of the orphanage</label>
                    <input type="text" name="address" id="address" value="${post.address}">
                </article>

                <article class="input-group">
                    <label for="phone">Phone number of orphanage employee</label>
                    <input type="text" name="phone" id="phone" value="${post.phone}">
                </article>

                <input type="submit" class="btn submit" value="Edit Post">
            </form>
        </section>`;

export const editPage = (ctx) => {
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
      .update(post.title,
        post.description,
        post.imageUrl,
        post.address,
        post.phone,
        ctx.params.postId)
      .then((res) => {
        console.log(res);
        ctx.page.redirect(`/details/${res._id}`);
      });
  };

  orphService.getOne(ctx.params.postId).then((b) => {
    if (ctx.user._id !== b._ownerId) {
      ctx.page.redirect("/");
    }

    ctx.render(editTemplate(b, onSubmit));
  });
};
