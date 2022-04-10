import * as authService from "../services/authService.js";

export const logoutPage = (ctx) => {
    if(!ctx.user){
        ctx.page.redirect('/home');
    }

    authService.logout().then(() => ctx.page.redirect('/'));
}