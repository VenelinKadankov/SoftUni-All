import { render } from "../../node_modules/lit-html/lit-html.js";
import { renderNavigation } from "../views/navView.js";

const navEement = document.getElementById('site-header');

export function navigationMiddleware (ctx, next) {
    render(renderNavigation(ctx), navEement);

    next();
}