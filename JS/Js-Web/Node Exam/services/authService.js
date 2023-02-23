const User = require("../models/User");
const bcrypt = require("bcrypt");

const jwt = require("../lib/jsonwebtoken");

const { SECRET } = require("../constants");

exports.findByUsername = (username) => User.findOne({ username });
exports.findByEmail = (email) => User.findOne({ email });

exports.register = async (username, email, password, confirmPassword) => {
  if (password !== confirmPassword) {
    throw new Error("Password missmatch!");
  }

  if (!password || !confirmPassword) {
    throw new Error("Password information required");
  }

  const existingUser = await User.findOne({ $or: [{ email }, { username }] });

  if (existingUser) {
    throw new Error("User exists!");
  }

  if(password.length < 4 || confirmPassword.length < 4){
    throw new Error("Password must be at least 4 characters!");
  }
  const hashedPass = await bcrypt.hash(password, 10);

  await User.create({ username, email, password: hashedPass });

  return this.login(username, password);
};

exports.login = async (username, password) => {
  // User exists
  const user = await this.findByUsername(username);

  if (!user) {
    throw new Error("Invalid credentials!");
  }

  // Password is valid
  const isValid = await bcrypt.compare(password, user.password);

  if (!isValid) {
    throw new Error("Invalid credentials!");
  }

  // Generate token
  const payload = {
    _id: user._id,
    email: user.email,
    username: user.username,
  };

  const token = await jwt.sign(payload, SECRET);

  return token;
};

