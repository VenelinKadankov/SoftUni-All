const router = require("express").Router();
const { getAll } = require("../services/cryptoService");

router.get("/", async (req, res) => {
  // console.log(req.user);
  const crypto = await getAll();
  res.render("home/index", { crypto }); // Can be just home because by default it will look for index
});

router.get("/404", (req, res) => {
    console.log("reaching home 404");
  res.render("home/404");
});

module.exports = router;
