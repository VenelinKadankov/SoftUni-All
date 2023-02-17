const mongoose = require('mongoose');

const userSchema = new mongoose.Schema(
  {
    username: {
      type: String,
      validate: {
        validator: function(v) {
          return v.length >= 5;
        },
        message: props => `${props.value} should be at least 5 characters!`
      },
      required: true,
    },
    email: {
      type: String,
      validate: {
        validator: function(v) {
          return v.length >= 10;
        },
        message: props => `${props.value} should be at least 10 characters!`
      },
      required: true,
    },
    password: {
      type: String,
      validate: {
        validator: function(v) {
          return v.length >= 4;
        },
        message: props => `${props.value} should be at least 4 characters!`
      },
      required: true,
    },
  },
  {
    // virtuals: {
    //   // Virtual confirmPassword because I don't want to keep it in the database
    //   confirmPassword: {
    //     set(v) {
    //       if (this.password !== v) {
    //         throw new mongoose.Error("Password missmatch");
    //       }
    //     },
    //   },
    // },
  }
);

const User = mongoose.model('User', userSchema);

module.exports = User;