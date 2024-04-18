const express = require('express');
const router = express.Router();
const versionController = require('../controllers/version');

router.get('/', versionController.getVersion);

module.exports = router;
