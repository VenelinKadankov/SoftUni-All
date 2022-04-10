import * as request from "./httpClient.js";
import * as api from "./api.js";

const userKey = "user";

function saveUser(user) {
  localStorage.setItem(userKey, JSON.stringify(user));
  localStorage.setItem("email", user.email);
  localStorage.setItem("_id", user._id);
  localStorage.setItem("accessToken", user.accessToken);
}

export function getUser(){
  try {
    let user = localStorage.getItem(userKey);

    if (user) {
      return JSON.parse(user);
    }
  } catch (error) {
    console.log("Error in getting user");
    return undefined;
  }
}

export function getData() {
  let email = localStorage.getItem("email");
  let _id = localStorage.getItem("_id");
  let accessToken = getToken();

  return {
    _id,
    email,
    accessToken,
  };
}

export function getToken() {
  return localStorage.getItem("accessToken");
}

export function deleteData() {
  localStorage.removeItem("email");
  localStorage.removeItem("_id");
  localStorage.removeItem("accessToken");
  localStorage.removeItem(userKey);
}

export function login(email, password) {
  return request.post(api.login, { email, password }).then((user) => {
    console.log(user);
    if (user.code && user["code"] == '403') {
      console.log(user);
    } else {
      saveUser(user);
    }

    return user;
  })
  .catch((err) => console.log(err));
}

export function logout() {
  return request.get(api.logout).then((data) => {
    deleteData();
    console.log(data);
  });
}

export function register(email, password) {
  return request
    .post(api.register, { email, password })
    .then((user) => {
      if (user.code && user.code.startsWith("4")) {
      } else {
          saveUser(user);
      }
  
      return user;
    });
}

export function isAuthenticated() {
  return Boolean(localStorage.getItem("accessToken"));
}
