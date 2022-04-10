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
import { ownPostsPage } from "./views/ownView.js";

page(authMiddleware);
page(navigationMiddleware);
page(renderMiddleware);

page("", homePage);
page("/", homePage);
page("/dashboard", homePage);
page("/home", homePage);
page("/login", loginPage);
page("/logout", logoutPage);
page("/register", registerPage);
page("/create", createPage);
page("/edit/:postId", editPage);
page("/details/:postId", detailsPage);
page("/delete/:postId", deletePage);
page("/posts", ownPostsPage);
page("/myPosts", ownPostsPage);


page.start();
