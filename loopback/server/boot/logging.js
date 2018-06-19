'use strict';

module.exports = function enableLogging(server) {
  server.middleware('initial', function logResponse(req, res, next) {
    var start = new Date();

    if (res._responseTime) {
      return next();
    }
    res._responseTime = true;

    // Listen on when response is finished
    res.on('finish', function() {
      // Request is handled => log

      // Duration of request
      var duration = new Date() - start;

      // Log
      console.log(
        res.statusCode < 400 ? 'LOG:' : 'ERROR:',
        start.toISOString(),
        req.accessToken ? req.accessToken.userId : 'Unknown',
        req.method,
        req.originalUrl,
        res.statusCode,
        duration + 'ms'
      );

      // If something goes wrong log input and output
      if (res.statusCode >= 400) {
        // Request
        // Params
        if (req) {
          console.log('REQUEST: ', req);
        }

        // Response
        if (req && req.remotingContext && req.remotingContext.result) {
          console.log('RESPONSE: ', req.remotingContext.result);
        }
      }
    });

    next();
  });
};
