const mongoose = require("mongoose");
const Crypto = require("../models/Crypto");

exports.getAll = async () => {
  const all = await Crypto.find({}).lean(); // DON'T FORGET THE LEAN()

  return all;
};

exports.create = async (cryptoData, ownerId) => {
  await Crypto.create({ ...cryptoData, owner: ownerId });
};

exports.getOne = async (cryptoId) => {
  return await Crypto.findById(cryptoId).lean(); // DON'T FORGET THE LEAN()
};

exports.buyOne = async (cryptoId, userId) => {
  const crypto = await Crypto.findById(cryptoId);
  if (crypto) {
    if (crypto.buyers.includes(userId)) {
      return false;
    }

    crypto.buyers.push(userId);
    await crypto.save();
    return true;
  }

  return false;
};

exports.updateEnity = async (cryptoId, cryptoData, userId) => {
  await Crypto.findByIdAndUpdate(cryptoId, { ...cryptoData, owner: userId });
};

exports.deleteOne = async (cryptoId) => {
  await Crypto.findByIdAndDelete(cryptoId);
};
