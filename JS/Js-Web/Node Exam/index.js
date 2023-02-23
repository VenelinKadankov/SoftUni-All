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

app.use("/static", express.static("public"));
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(authentication);
app.use(routes);

mongoose.set("strictQuery", true);
mongoose.connect("mongodb://127.0.0.1:27017/petstagram");

app.listen(3000, () => console.log("Server is running on port 3000!"));