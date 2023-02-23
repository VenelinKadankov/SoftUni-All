const mongoose = require("mongoose");
const { Schema } = mongoose;

const photoSchema = new mongoose.Schema({
  name: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 2;
      },
      message: (props) => `${props.value} should be at least 2 characters!`,
    },
  },
  image: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return /^https?:\/\//.test(v);
      },
      message: (props) => `${props.value} enter a valid url!`,
    },
  },
  age: {
    type: Number,
    required: true,
    min: [0, 'Age can not be negative number'],
    max: [100, 'Age can not be over 100'],
  },
  description: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 5 && v.length <= 50;
      },
      message: (props) => `${props.value} should be at between 5 and 50 characters!`,
    },
  },
  location: {
    type: String,
    required: true,
    validate: {
      validator: function (v) {
        return v.length >= 5 && v.length <= 50;
      },
      message: (props) => `${props.value} should be at between 5 and 50 characters!`,
    },
  },
  commentList: [
    {
      userId: {
        type: Schema.Types.ObjectId,
        ref: "User",
      },
      comment: String,
    },
  ],
  owner: {
    type: Schema.Types.ObjectId,
    ref: "User",
  },
});

const Photo = mongoose.model("Photo", photoSchema);

module.exports = Photo;
