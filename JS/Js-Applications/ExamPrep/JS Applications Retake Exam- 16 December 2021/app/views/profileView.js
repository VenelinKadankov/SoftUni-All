import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as theaterService from "../services/theatersService.js";

const profileTemplate = (theaters = [], user) => html`
  <!--Profile Page-->
  <section id="profilePage">
    <div class="userInfo">
      <div class="avatar">
        <img src="./images/profilePic.png" />
      </div>
      <h2>${user.email}</h2>
    </div>
    <div class="board">
      <!--If there are event-->
      ${theaters.map((t) => theaterTemplate(t))}

      <!--If there are no event-->
      ${theaters.length == 0
        ? html` <div class="no-events">
            <p>This user has no events yet!</p>
          </div>`
        : nothing}
    </div>
  </section>
`;

const theaterTemplate = (theater) => html` <div class="eventBoard">
  <div class="event-info">
    <img src="${theater.imageUrl}" />
    <h2>${theater.title}</h2>
    <h6>${theater.date}</h6>
    <a href="/details/${theater._id}" class="details-button">Details</a>
  </div>
</div>`;

export const profilePage = (ctx) => {
  theaterService
    .getOwn(ctx.user._id)
    .then((res) => ctx.render(profileTemplate(res, ctx.user)));
};
