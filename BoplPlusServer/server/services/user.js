let userCount = 0;
let requestCount = 0;

const incrementRequestCount = () => {
    requestCount++;
};

const getStats = () => {
    return { userCount, requestCount };
};

module.exports = { incrementRequestCount, getStats };
