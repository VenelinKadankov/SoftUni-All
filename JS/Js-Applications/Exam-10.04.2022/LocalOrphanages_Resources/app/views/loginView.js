import { html } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const loginTemplate = (onSubmit) => html`
  <!-- Login Page (Only for Guest users) -->
  <section id="login-page" class="auth">
    <form id="login" @submit=${onSubmit}>
      <h1 class="title">Login</h1>

      <article class="input-group">
        <label for="login-email">Email: </label>
        <input type="email" id="login-email" name="email" />
      </article>

      <article class="input-group">
        <label for="password">Password: </label>
        <input type="password" id="password" name="password" />
      </article>

      <input type="submit" class="btn submit-btn" value="Log In" />
    </form>
  </section>
`;

export const loginPage = (ctx) => {
  if (ctx.user) {
    ctx.page.redirect("/home");
  }

  const onSubmit = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get("email");
    let password = formData.get("password");

    if (!email || !password) {
      window.alert("Fill all data!!!");
      return;
    }

    authService
      .login(email, password)
      .then((response) => {
        if (response && response.code && response.code == "403") {
          window.alert("Login failed!!!");
          return;
        }

        ctx.page.redirect("/home");
      })
      .catch(() => window.alert("Login failed!!!"));
  };

  return ctx.render(loginTemplate(onSubmit));
};
