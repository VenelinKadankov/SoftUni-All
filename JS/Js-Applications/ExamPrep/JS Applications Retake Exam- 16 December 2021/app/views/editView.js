import { html } from "../../node_modules/lit-html/lit-html.js";
import * as theaterService from "../services/theatersService.js";

const editTemplate = (theater, onSubmit) => html` <!--Edit Page-->
  <section id="editPage">
    <form class="theater-form" @submit=${onSubmit}>
      <h1>Edit Theater</h1>
      <div>
        <label for="title">Title:</label>
        <input
          id="title"
          name="title"
          type="text"
          placeholder="Theater name"
          value="${theater.title}"
        />
      </div>
      <div>
        <label for="date">Date:</label>
        <input
          id="date"
          name="date"
          type="text"
          placeholder="Month Day, Year"
          value="${theater.date}"
        />
      </div>
      <div>
        <label for="author">Author:</label>
        <input
          id="author"
          name="author"
          type="text"
          placeholder="Author"
          value="${theater.author}"
        />
      </div>
      <div>
        <label for="description">Theater Description:</label>
        <textarea id="description" name="description" placeholder="Description">
        ${theater.description}</textarea
        >
      </div>
      <div>
        <label for="imageUrl">Image url:</label>
        <input
          id="imageUrl"
          name="imageUrl"
          type="text"
          placeholder="Image Url"
          value="${theater.imageUrl}"
        />
      </div>
      <button class="btn" type="submit">Submit</button>
    </form>
  </section>`;

export const editPage = (ctx) => {
  if (!ctx.user) {
    ctx.page.redirect("/");
  }

  const onSubmit = (e) => {
    e.preventDefault();

    let theater = Object.fromEntries(new FormData(e.currentTarget));

    if (Object.values(theater).some((x) => !x)) {
      window.alert("You must fill all!!");
      return;
    }

    theaterService
      .update(
        theater.title,
        theater.date,
        theater.author,
        theater.imageUrl,
        theater.description,
        ctx.params.theaterId
      )
      .then((res) => {
        console.log(res);
        ctx.page.redirect(`/details/${res._id}`);
      });
  };

  theaterService.getOne(ctx.params.theaterId).then((b) => {
    if (ctx.user._id !== b._ownerId) {
      ctx.page.redirect("/");
    }

    ctx.render(editTemplate(b, onSubmit));
  });
};
