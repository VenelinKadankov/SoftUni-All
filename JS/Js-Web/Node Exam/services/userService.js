const User = require("../models/User");

exports.getAll = async () => {
  const all = await User.find({}).lean();

  return all;
};

exports.getOne = async (userId) => {
  return await User.findById(userId).lean();
};
