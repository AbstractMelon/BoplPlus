const getVersion = (req, res) => {
    const versionData = {
        version: '1.0.0',
        releaseDate: '2024-04-17'
    };
    res.json(versionData);
};

module.exports = { getVersion };
