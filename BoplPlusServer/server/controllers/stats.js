const userService = require('../services/user');

const getStats = (req, res) => {
    const stats = userService.getStats();
    res.json(stats);
};

module.exports = { getStats };
