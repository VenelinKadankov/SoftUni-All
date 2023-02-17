const jwt = require("jsonwebtoken");
const util = require("util");

// Convert to promises
exports.sign = util.promisify(jwt.sign);
exports.verify = util.promisify(jwt.verify);