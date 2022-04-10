import { html } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const registerTemplate = (onSubmit) => html`
  <!-- Register Page (Only for Guest users) -->
  <section id="register-page" class="auth">
    <form id="register" @submit=${onSubmit}>
      <h1 class="title">Register</h1>

      <article class="input-group">
        <label for="register-email">Email: </label>
        <input type="email" id="register-email" name="email" />
      </article>

      <article class="input-group">
        <label for="register-password">Password: </label>
        <input type="password" id="register-password" name="password" />
      </article>

      <article class="input-group">
        <label for="repeat-password">Repeat Password: </label>
        <input type="password" id="repeat-password" name="repeatPassword" />
      </article>

      <input type="submit" class="btn submit-btn" value="Register" />
    </form>
  </section>
`;

export const registerPage = (ctx) => {
  if (ctx.user) {
    ctx.page.redirect("/home");
  }

  const onSubmit = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get("email");
    let password = formData.get("password");
    let confirmPass = formData.get("repeatPassword");

    if (!password || !confirmPass || !email || password !== confirmPass) {
      return;
    }

    authService
      .register(email, password)
      .then((response) => {
        if (response && response.code && response.code.startsWith("4")) {
          window.alert("Register failed!!!");
          return;
        }
        ctx.page.redirect("/login");
      })
      .catch(() => window.alert("Register failed!!!"));
  };

  return ctx.render(registerTemplate(onSubmit));
};
