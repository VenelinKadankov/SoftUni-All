const express = require("express");
const handlebars = require("express-handlebars");
const cookieParser = require("cookie-parser");
const mongoose = require("mongoose");

const { authentication, isAuth } = require("./middlewares/authMiddleware");

const routes = require("./routes");
const app = express();

app.engine(
  "hbs",
  handlebars.engine({
    extname: "hbs",
  })
);

app.set("view engine", "hbs");

app.use("/static", express.static("public")); // Means if the link starts with 'static' use instead 'public'
app.use(express.urlencoded({ extended: false })); // true if I need to use deep nested objects(up to 6 levels)
app.use(cookieParser());
app.use(authentication);
app.use(routes);

mongoose.set("strictQuery", true); // To avoid the deprecation warning in terminal.
mongoose.connect("mongodb://127.0.0.1:27017/crypto"); // Instrad of 'crypto' use name according the problem

app.listen(4000, () => console.log("Server is running on port 4000!"));
