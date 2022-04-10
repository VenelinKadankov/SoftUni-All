import page from "../node_modules/page/page.mjs";

import { renderMiddleware } from "./middlewares/renderMiddleware.js";
import { authMiddleware } from "./middlewares/authMiddleware.js";
import { navigationMiddleware } from "./middlewares/navigationMiddleware.js";

import { homePage } from "./views/homeView.js";
import { loginPage } from "./views/loginView.js";
import { registerPage } from "./views/registerView.js";
import { logoutPage } from "./views/logoutView.js";
import { createPage } from "./views/createView.js";
import { editPage } from "./views/editView.js";
import { detailsPage } from "./views/detailsView.js";
import { deletePage } from "./views/deleteView.js";
import { profilePage } from "./views/profileView.js";

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page("", homePage);
page("/", homePage);
page("/theater", homePage);
page("/home", homePage);
page("/login", loginPage);
page("/logout", logoutPage);
page("/register", registerPage);
page("/create", createPage);
page("/edit/:theaterId", editPage);
page("/details/:theaterId", detailsPage);
page("/delete/:theaterId", deletePage);
page("/profile", profilePage);


page.start();
