const express = require('express');
const app = express();
const bodyParser = require('body-parser');

// Middleware
const requestLogger = require('./middleware/requestLogger');

// Routes
const versionRoutes = require('./routes/version');
const modRoutes = require('./routes/mods');
const userRoutes = require('./routes/user');
const statsRoutes = require('./routes/stats');

// Middleware
app.use(bodyParser.json());
app.use(requestLogger);

// Routes
app.use('/version', versionRoutes);
app.use('/mods', modRoutes);
app.use('/user', userRoutes);
app.use('/stats', statsRoutes);

module.exports = app;
