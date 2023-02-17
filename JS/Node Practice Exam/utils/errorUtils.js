const mongoose = require("mongoose");
//console.log("Mongoose error");

function getFirstMongooseError(error) {
  const errors = Object.keys(error.errors).map(
    (key) => error.errors[key].message
  );

  return errors[0]; // If I want all errors "return errors;"
}

exports.getErrorMessage = (error) => {
  switch(error.name){
      case "Error":
          return error.message;
      case "ValidationError":
          return getFirstMongooseError(error);
      default:
          return error.message;
  }

//   if (
//     error instanceof mongoose.MongooseError ||
//     error.stack instanceof mongoose.MongooseError ||
//     error.message instanceof mongoose.MongooseError
//   ) {
//     return getFirstMongooseError(error);
//   } else {
//     return error.message;
//   }
};
