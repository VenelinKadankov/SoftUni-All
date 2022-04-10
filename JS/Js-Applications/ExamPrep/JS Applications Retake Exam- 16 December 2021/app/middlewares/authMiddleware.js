import * as authService from "../services/authService.js";

export const authMiddleware = (ctx, next) => {
  let userData = authService.getData();

  let user = authService.getUser();

  if(user){
      ctx.user = user;
  }

  if(userData.accessToken) {
    ctx.isAuthenticated = true;
    ctx.userId = userData._id;
    ctx.email = userData.email;
    ctx.token = userData.accessToken;
  }

  next();
};
