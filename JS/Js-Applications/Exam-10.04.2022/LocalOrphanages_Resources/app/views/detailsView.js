import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as orphService from "../services/orphService.js";

const detailsTemplate = (
  post,
  user,
  isOwner,
  onClick,
  allDonations,
  donateBtnVisibe,
  myDonations
) => html`
  <!-- Details Page -->
  <section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
      <div id="details">
        <div class="image-wrapper">
          <img
            src="${post.imageUrl}"
            alt="Material Image"
            class="post-image"
          />
        </div>
        <div class="info">
          <h2 class="title post-title">${post.title}</h2>
          <p class="post-description">Description: ${post.description}</p>
          <p class="post-address">Address: ${post.address}</p>
          <p class="post-number">Phone number: ${post.phone}</p>
          <p class="donate-Item">Donate Materials: ${allDonations}</p>

          <div class="btns">
            ${isOwner
            ? ownerBtns(post)
            : nothing}

            ${(post && !isOwner && user && myDonations == 0)
            ? donateBtn(post, onClick)
            : nothing}
          </div>
        </div>
      </div>
    </div>
  </section>
`;

const donateBtn = (post, onClick) => html`
  <a href="/details/${post._id}" class="donate-btn btn" @click=${onClick}>Donate</a>`;

const ownerBtns = (post) => html` <a
    href="/edit/${post._id}"
    class="edit-btn btn"
    >Edit</a
  >
  <a href="/delete/${post._id}" class="delete-btn btn">Delete</a>`;

export const detailsPage = (ctx) => {
  // if (!ctx.user) {
  //   ctx.page.redirect("/");
  // }

  let id = ctx.params.postId;
  let isOwner = false;
  let donateBtnVisibe = true;
  let allDonations = 0;
  let myDonations = 0;
  let donationsCounter = 0;

  const renderDetails = () => {
    orphService
      .getOne(id)
      .then((res) => {
        if (ctx.user && res._ownerId === ctx.user._id) {
          isOwner = true;
        }

        return res;
      })
      .then((t) =>
        ctx.render(
          detailsTemplate(
            t,
            ctx.user,
            isOwner,
            onClick,
            allDonations,
            donateBtnVisibe,
            myDonations
          )
        )
      );
  };

  const onClick = (e) => {
    e.preventDefault();

    if (!ctx.user || isOwner) {
      return;
    }

    donationsCounter = donationsCounter + 1;
    donateBtnVisibe = false;

    orphService.donate(id);

    ctx.page.redirect(`/details/${id}`);
    // renderDetails();
  };

  orphService.getAllDonations(id).then((res) => (allDonations = res));

  if (ctx.user) {
    orphService
      .getDonationsFromUser(id, ctx.user._id)
      .then((res) => (myDonations = res));
  }

  if (myDonations > 0) {
    donateBtnVisibe = false;
  }

  renderDetails();
};
