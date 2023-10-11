/**
 * FileController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

const sailsHookGrunt = require("sails-hook-grunt");

module.exports = {
  
    fileUpload:async function(req,res){
        req.file('healthyFile').upload({
            dirname: require('path').resolve(sails.config.appPath, '../frontEnd/nginx-1.23.0/www/Community/assets/img'),
        },function (err, files) {
            sails.log(files);
            if (err)
              return res.serverError(err);
              
              return res.json({
              message: files.length + ' file(s) uploaded successfully!',
              files: files,
            });
          });
    }
    

};

