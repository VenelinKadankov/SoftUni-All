import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as theaterService from "../services/theatersService.js";

const detailsTemplate = (
  theater,
  user,
  isOwner,
  onClick,
  allLikes,
  likeBtnVisibe,
  myLikes
) => html`
  <!--Details Page-->
  <section id="detailsPage">
    <div id="detailsBox">
      <div class="detailsInfo">
        <h1>Title: ${theater.title}</h1>
        <div>
          <img src="${theater.imageUrl}" />
        </div>
      </div>

      <div class="details">
        <h3>Theater Description</h3>
        <p>${theater.description}</p>
        <h4>Date: ${theater.date}</h4>
        <h4>Author: ${theater.author}</h4>
        <div class="buttons">
          ${isOwner
            ? ownerBtns(theater)
            : nothing}

            ${(user && myLikes == 0 && !isOwner)
            ? likeBtn(theater, onClick)
            : nothing}
        </div>
        <p class="likes">Likes: ${allLikes}</p>
      </div>
    </div>
  </section>
`;

const likeBtn = (theater, onClick) => html` <a
  class="btn-like"
  href="/details/${theater._id}"
  @click=${onClick}
  >Like</a
>`;

const ownerBtns = (theater) => html` <a
    class="btn-delete"
    href="/delete/${theater._id}"
    >Delete</a
  >
  <a class="btn-edit" href="/edit/${theater._id}">Edit</a>`;

export const detailsPage = (ctx) => {
  // if (!ctx.user) {
  //   ctx.page.redirect("/");
  // }

  let id = ctx.params.theaterId;
  let isOwner = false;
  let likeBtnVisibe = true;
  let allLikes = 0;
  let myLikes = 0;
  let likesCounter = 0;

  const renderDetails = () => {
    theaterService
    .getOne(id)
    .then((res) => {
      if (ctx.user && res._ownerId === ctx.user._id) {
        isOwner = true;
      }

      return res;
    })
    .then((t) =>
      ctx.render(
        detailsTemplate(t, ctx.user, isOwner, onClick, allLikes, likeBtnVisibe, myLikes)
      )
    );
  }

  const onClick = (e) => {
    e.preventDefault();

    if (!ctx.user || isOwner) {
      return;
    }

    likesCounter = likesCounter + 1;
    likeBtnVisibe = false;

    theaterService.like(id);

    ctx.page.redirect(`/details/${id}`);
   // renderDetails();
  };


  theaterService.getAllLikes(id).then((res) => (allLikes = res));

  if(ctx.user){
    theaterService
      .getLikesFromUser(id, ctx.user._id)
      .then((res) => (myLikes = res));
  }

  if (myLikes > 0) {
    likeBtnVisibe = false;
  }

  renderDetails();

};


