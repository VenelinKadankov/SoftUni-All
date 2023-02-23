const router = require("express").Router();

const authService = require("../services/authService");
const { isAuth } = require("../middlewares/authMiddleware");
const { getErrorMessage } = require("../utils/errorUtils");

const photoService = require("../services/photoService");
const userService = require("../services/userService");

router.get("/login", (req, res) => {
  if (req.user?._id) {
    return res.redirect("/");
  }

  res.render("auth/login");
});

router.post("/login", async (req, res) => {
  if (req.user?._id) {
    return res.redirect("/");
  }
  
  const { username, password } = req.body;

  try {
    const token = await authService.login(username, password);

    res.cookie("auth", token);
    res.redirect("/");
  } catch (error) {
    return res
      .status(404)
      .render("auth/login", { error: getErrorMessage(error) });
  }
});

router.get("/register", (req, res) => {
  if (req.user?._id) {
    return res.redirect("/");
  }

  res.render("auth/register");
});

router.post("/register", async (req, res) => {
  if (req.user?._id) {
    return res.redirect("/");
  }

  const { username, email, password, confirmPassword } = req.body;

  try {
    const token = await authService.register(
      username,
      email,
      password,
      confirmPassword
    );

    res.cookie("auth", token);
    res.redirect("/");
  } catch (error) {
    res.status(400).render("auth/register", { error: getErrorMessage(error) });
  }
});

router.get("/logout", isAuth, (req, res) => {
  res.clearCookie("auth");

  res.redirect("/");
});

router.get("/profile", isAuth, async (req, res) => {
  try {
    const photos = await photoService.getAll();
    const user = await userService.getOne(req.user?._id);

    photosOfUser = photos.filter(
      (p) => p.owner.toString() == user._id.toString()
    );

    res.render("auth/profile", { user, photosOfUser });
  } catch (error) {
    res.status(400).render("home/index", { error: getErrorMessage(error) });
  }
});

module.exports = router;
