import { html } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const loginTemplate = (onSubmit) => html`
 <!--Login Page-->
 <section id="loginaPage">
            <form class="loginForm" @submit=${onSubmit}>
                <h2>Login</h2>
                <div>
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>
                <div>
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit">Login</button>

                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </form>
        </section>
`;

export const loginPage = (ctx) => {
    if(ctx.user){
        ctx.page.redirect('/home');
    }

    const onSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');

        if(!email || !password){
            window.alert('Fill all data!!!');
            return;
        }
        
        authService.login(email, password).then((response) => {
            if(response && response.code && response.code == '403'){
                window.alert('Login failed!!!');
                return;
            } 

            ctx.page.redirect('/home');
        })
        .catch(() => window.alert('Login failed!!!'));
    }

    return ctx.render(loginTemplate(onSubmit));
}