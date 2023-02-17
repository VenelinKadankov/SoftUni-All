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

  // TODO: Check if user exists, also check if email exists if required
  // const existingUser = await this.findByUsername(username);
  const existingUser = await User.findOne({ $or: [{ email }, { username }] }); // If this does not work use the upper one

  if (existingUser) {
    throw new Error("User exists!");
  }

  // TODO: validate password according to project requirements (this is because I give the model the hashed pass so I can't use mongoose validators)

  const hashedPass = await bcrypt.hash(password, 10); // salt or rounds(this is rounds)

  await User.create({ username, email, password: hashedPass });

  return this.login(email, password);
};

exports.login = async (email, password) => {
  // User exists
  const user = await this.findByEmail(email);

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
    email,
    username: user.username,
  };

  const token = await jwt.sign(payload, SECRET);

  return token;
};

