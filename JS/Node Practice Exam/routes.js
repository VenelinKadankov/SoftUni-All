const router = require("express").Router();

const homeController = require("./controllers/homeController");
const authController = require("./controllers/authController");
const cryptoController = require("./controllers/cryptoController");

router.use(homeController);
router.use(authController); // without 'auth' because I have not created prefix for the route
router.use(cryptoController);
router.all("*", (req, res) => {
    res.render("home/404");
})

module.exports = router;
