const router = require("express").Router();

const { isAuth } = require("../middlewares/authMiddleware");
const { getErrorMessage } = require("../utils/errorUtils");
const photoService = require("../services/photoService");
const userService = require("../services/userService");

router.get("/photo/catalog", async (req, res) => {
  const photos = await photoService.getAll();
  const users = await userService.getAll();

  let usersWithPets = [];

  for (let i = 0; i < photos.length; i++) {
    const photo = photos[i];
    let owner = users.find((u) => u._id.toString() == photo.owner.toString());
    usersWithPets.push({ photo, owner });
  }

  res.render("photo/catalog", { usersWithPets });
});

router.get("/photo/create", isAuth, (req, res) => {
  res.render("photo/create");
});

router.post("/photo/create", isAuth, async (req, res) => {
  const photoData = req.body;

  try {
    const ownerId = req.user?._id;
    await photoService.create(photoData, ownerId);
    res.redirect("/photo/catalog");
  } catch (error) {
    res.status(400).render("photo/create", { error: getErrorMessage(error) });
  }
});

router.get("/photo/:photoId/details", async (req, res) => {
  let hasUser = false;
  const userId = req.user?._id;

  if (userId) {
    hasUser = true;
  }

  try {
    const photoId = req.params.photoId;
    let photo = await photoService.getOne(photoId);
    const isOwner = userId == photo.owner;
    const canComment = !isOwner && hasUser;
    let comments = [];
    let ownerName = "no name";

    if (req.query.userComment) {
      let commentData = req.query;
      let commentText = commentData.userComment;

      await photoService.commentPhoto(photoId, userId, commentText);
      photo = await photoService.getOne(photoId);
    }
    const allUsers = await userService.getAll();
    ownerName = allUsers.find(
      (u) => u._id.toString() == photo.owner.toString()
    );

    for (let i = 0; i < photo.commentList.length; i++) {
      const com = photo.commentList[i];

      comments.push({
        commentInfo: com.comment,
        user: allUsers.find((u) => u._id.toString() == com.userId.toString()),
      });
    }

    res.render("photo/details", {
      photo,
      hasUser,
      isOwner,
      canComment,
      comments,
      ownerName: ownerName.username,
    });
  } catch (error) {
    res.status(400).render("photo/catalog", { error: getErrorMessage(error) });
  }
});

router.get("/photo/:photoId/edit", isAuth, async (req, res) => {
  const photo = await photoService.getOne(req.params.photoId);
  res.render("photo/edit", { photo });
});

router.post("/photo/:photoId/edit", isAuth, async (req, res) => {
  const photoId = req.params.photoId;
  const photoData = req.body;
  const ownerId = req.user?._id;

  try {
    await photoService.updateEnity(photoId, photoData, ownerId);

    res.redirect(`/photo/${photoId}/details`);
  } catch (error) {
    res.status(400).render("photo/catalog", { error: getErrorMessage(error) });
  }
});

router.get("/photo/:photoId/delete", isAuth, async (req, res) => {
  await photoService.deleteOne(req.params.photoId);
  res.redirect("/photo/catalog");
});

module.exports = router;
