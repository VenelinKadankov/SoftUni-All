const mongoose = require("mongoose");

const userSchema = new mongoose.Schema({
  username: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 2;
      },
      message: (props) => `${props.value} should be at least 2 characters!`,
    },
  },
  email: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 10;
      },
      message: (props) => `${props.value} should be at least 10 characters!`,
    },
  },
  password: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 4;
      },
      message: (props) => `${props.value} should be at least 4 characters!`,
    },
  },
});

const User = mongoose.model("User", userSchema);

module.exports = User;
