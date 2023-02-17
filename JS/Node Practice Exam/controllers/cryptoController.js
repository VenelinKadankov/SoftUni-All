const router = require("express").Router();

const { isAuth } = require("../middlewares/authMiddleware");
const { getErrorMessage } = require("../utils/errorUtils");

const {
  getAll,
  create,
  getOne,
  buyOne,
  updateEnity,
  deleteOne,
} = require("../services/cryptoService");
const { paymentMethodsMap } = require("../constants");

router.get("/crypto/catalog", async (req, res) => {
  const crypto = await getAll();

  res.render("crypto/catalog", { crypto });
});

router.get("/crypto/create", isAuth, (req, res) => {
  res.render("crypto/create");
});

router.post("/crypto/create", isAuth, async (req, res) => {
  const cryptoData = req.body;

  try {
    const ownerId = req.user._id;
    await create(cryptoData, ownerId);
    res.redirect("/crypto/catalog");
  } catch (error) {
    res.status(400).render("crypto/create", { error: getErrorMessage(error) });
  }
});

router.get("/crypto/:cryptoId/details", async (req, res) => {
  const cryptoId = req.params?.cryptoId;
  const userId = req.user?._id;

  if (cryptoId) {
    try {
      const hasUser = userId != undefined;
      const crypto = await getOne(cryptoId);
      const isOwner = crypto.owner.toString() === userId;
      const hasBoughtIt = crypto.buyers
        .map((b) => b.toString())
        .includes(userId);

      res.render("crypto/details", { crypto, isOwner, hasBoughtIt, hasUser });
    } catch (error) {}
  } else {
    res.redirect("/404"); // Status might be a problem
  }
});

router.get("/crypto/:cryptoId/buy", isAuth, async (req, res) => {
  const cryptoId = req.params.cryptoId;

  try {
    const buySuccess = await buyOne(cryptoId, req.user._id);

    if (buySuccess) {
      res.redirect(`/crypto/${cryptoId}/details`);
    }
  } catch (error) {
    res.status(400).render("crypto/catalog", { error: getErrorMessage(error) });
  }
});

router.get("/crypto/:cryptoId/edit", isAuth, async (req, res) => {
  const crypto = await getOne(req.params.cryptoId);

  const paymentMethod = Object.keys(paymentMethodsMap).map((key) => ({
    key,
    label: paymentMethodsMap[key],
    isSelected: crypto.payment == key,
  }));

  const isPaypal = crypto.payment == "paypal";
  const isDebit = crypto.payment == "debit-card";
  const isCredit = crypto.payment == "credit-card";
  const isCryptoWallet = crypto.payment == "crypto-wallet";

  res.render("crypto/edit", {
    crypto,
    isPaypal,
    isDebit,
    isCredit,
    isCryptoWallet,
  });
});

router.post("/crypto/:cryptoId/edit", isAuth, async (req, res) => {
  const changedData = req.body;
  const cryptoId = req.params.cryptoId;
  const userId = req.user?._id;
  //   const paymentMethod = req.body.payment;
  console.log(req.body);

  if (!changedData || !cryptoId || !userId) {
    res.redirect("/404");
  }

  try {
    //console.log(changedData);
    await updateEnity(cryptoId, changedData, userId);
    res.redirect(`/crypto/${cryptoId}/details`);
  } catch (error) {
    res
      .status(400)
      .redirect(`/crypto/${cryptoId}/edit`, { error: getErrorMessage(error) });
  }
});

router.get("/crypto/:cryptoId/delete", isAuth, async (req, res) => {
  try {
    await deleteOne(req.params.cryptoId);

    const crypto = await getAll();
    res.render("crypto/catalog", { crypto });
  } catch (error) {
    const crypto = await getAll();
    res.status(400).render(`crypto/catalog`, { crypto });
  }
});

router.get("/crypto/search", async (req, res) => {
  const { searchOption, payment } = req.query;

  let crypto = await getAll();

  if (searchOption) {
    crypto = crypto.filter((cr) =>
      cr.name.toLowerCase().includes(searchOption.toLowerCase())
    );
  }

  if (payment) {
    crypto = crypto.filter((cr) => cr.payment == payment);
  }
  res.render("crypto/search", { crypto });
});

module.exports = router;
