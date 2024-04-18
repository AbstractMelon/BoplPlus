const express = require('express');
const router = express.Router();
const userService = require('../services/user');

router.post('/request', (req, res) => {
    res.sendStatus(200);
});

module.exports = router;
