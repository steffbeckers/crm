'use strict';

module.exports = function(server) {
  var Role = server.models.Role;
  var RoleMapping = server.models.RoleMapping;
  var Person = server.models.Person;

  // Role relations
  RoleMapping.belongsTo(Person);
  Person.hasMany(RoleMapping, {foreignKey: 'principalId'});
  Role.hasMany(Person, {through: RoleMapping, foreignKey: 'roleId'});

  // Administrators
  // Role.create({
  //   name: 'admin'
  // }, function(err, role) {
  //   if (err) {
  //     console.log('> ERROR: ' + err);
  //   }
  //   console.log(role);

  //   // Steff
  //   role.principals.create({
  //     principalType: 'USER',
  //     principalId: '5a8823b2582d8d20840b11e8'
  //   }, function(err, principal) {
  //     if (err) {
  //       console.log('> ERROR: ' + err);
  //     }
  //     console.log(principal);
  //   });
  // });

  // Role.registerResolver('matchPlayer', function(role, context, cb) {
  //   // Q: Is the current request accessing a Match?
  //   if (context.modelName !== 'Match') {
  //     // A: No. This role is only for matches: callback with FALSE
  //     return process.nextTick(() => cb(null, false));
  //   }

  //   // Q: Is the user logged in? (there will be an accessToken with an ID if so)
  //   var userId = context.accessToken.userId;
  //   if (!userId) {
  //     // A: No, user is NOT logged in: callback with FALSE
  //     return process.nextTick(() => cb(null, false));
  //   }

  //   if (!context.modelId) {
  //     return process.nextTick(() => cb(null, false));
  //   }

  //   // Q: Is the current logged-in user associated with this Match?
  //   // Step 1: lookup the requested match
  //   app.models.Match.findById(
  //     ObjectId(context.modelId),
  //     {include: 'players'},
  //     function(err, match) {
  //       // A: The datastore produced an error! Pass error to callback
  //       if (err) return cb(err);
  //       // A: There's no match by this ID! Pass error to callback
  //       if (!match) return cb(new Error('Match not found'));

  //       var matchJSON = match.toJSON();

  //       for (var i = 0; i < matchJSON.players.length; i++) {
  //         if (String(matchJSON.players[i].id) === String(userId)) {
  //           return cb(null, true);
  //         }
  //       }

  //       return cb(null, false);
  //     });
  // });
};
