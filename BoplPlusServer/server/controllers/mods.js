const getMods = (req, res) => {
    const availableMods = ['Mod1', 'Mod2', 'Mod3'];
    res.json(availableMods);
};

module.exports = { getMods };
