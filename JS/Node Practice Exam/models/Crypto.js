const mongoose = require("mongoose");
const { Schema } = mongoose;

const cryptoSchema = new mongoose.Schema({
  name: {
    type: String,
    validate: {
      validator: function(v) {
        return v.length >= 2;
      },
      message: props => `${props.value} should be at least 2 characters!`
    },
    required: true,
  },
  image: {
    type: String,
    validate: {
      validator: function(v) {
        return /^https?:\/\//.test(v);
      },
      message: props => `${props.value} enter a valid url!`
    },
    required: true,
  },
  price: {
    type: Number,
    min: [0, 'Price must be a possitive number'],
    required: true,
  },
  description: {
    type: String,
    validate: {
      validator: function(v) {
        return v.length >= 10;
      },
      message: props => `${props.value} should be at least 10 characters!`
    },
    required: true,
  },
  payment: {
    type: String,
    enum: {
      values: ["crypto-wallet", "credit-card", "debit-card", "paypal"],
      message: "{VALUE} is not supported",
    },
  },
  buyers: [
    {
      type: Schema.Types.ObjectId,
      ref: "User",
    },
  ],
  owner: {
    type: Schema.Types.ObjectId,
    ref: "User",
  },
});

const Crypto = mongoose.model("Crypto", cryptoSchema);

module.exports = Crypto;
