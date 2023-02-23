const Photo = require("../models/Photo");

exports.getAll = async () => {
    const all = await Photo.find({}).lean();
  
    return all;
  };
  
  exports.create = async (photoData, ownerId) => {
    await Photo.create({ ...photoData, owner: ownerId });
  };
  
  exports.getOne = async (photoId) => {
    return await Photo.findById(photoId).lean();
  };

  exports.updateEnity = async (photoId, photoData, userId) => {
    await Photo.findByIdAndUpdate(photoId, { ...photoData, owner: userId });
  };
  
  exports.deleteOne = async (photoId) => {
    await Photo.findByIdAndDelete(photoId);
  };

  exports.commentPhoto = async (photoId, userId, commentText) => {
    const photo = await Photo.findById(photoId);

    if (photo) {
      if (photo.owner == userId) {
        console.log("error come here")
        return false;
      }

      photo.commentList.push({userId, comment: commentText})
      await photo.save();
      return true;
    }
  
    return false;
  }