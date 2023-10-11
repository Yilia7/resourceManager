/**
 * HealthyPunchController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

const { isLocalSailsValid } = require('sails/lib/app');

//  const ATTACHMENT_MAX_BYTES = 1024 * 1024 * 100;
//  const ATTACHMENT_PATH = '../Community/assets/img';
//  const uuid = require('node-uuid');

module.exports = {

    healthyPunchCreate:async function(req,res){

        // sails.log(req.file('healthyFile'));
        // sails.log(req.allParams());
        // sails.log('assets/img');

        // req.file('healthyFile').upload({
        //     dirname: require('path').resolve(sails.config.appPath, 'assets/img')
        //   },function (err, uploadedFiles) {
        //     sails.log(uploadedFiles);
        //     sails.log("上传处理做了吗");
        //     if (err) return res.serverError(err);
        //     return res.json({
        //       message: uploadedFiles.length + ' file(s) uploaded successfully!'
        //     });
        // });
          
        
        await HealthyPunch.create(req.allParams())
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    healthyPunchSearch:async function(req,res){

        HealthyPunch.find({healthyPunchName:req.query.healthyPunchName,tent:req.query.tent,
            unit:req.query.unit,room:req.query.room})
        .limit(7)
        .sort([{ 
            createdAt: 'DESC' 
        }])
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    }

};

