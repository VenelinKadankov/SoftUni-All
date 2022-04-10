import { html } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const registerTemplate = (onSubmit) => html`
        <!--Register Page-->
        <section id="registerPage">
            <form class="registerForm" @submit=${onSubmit}>
                <h2>Register</h2>
                <div class="on-dark">
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>

                <div class="on-dark">
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <div class="on-dark">
                    <label for="repeatPassword">Repeat Password:</label>
                    <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit">Register</button>

                <p class="field">
                    <span>If you have profile click <a href="#">here</a></span>
                </p>
            </form>
        </section>
`;

export const registerPage = (ctx) => {
    if(ctx.user){
        ctx.page.redirect('/home');
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
