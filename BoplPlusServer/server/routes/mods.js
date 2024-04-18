const express = require('express');
const router = express.Router();
const modController = require('../controllers/mods');

router.get('/', modController.getMods);

module.exports = router;
