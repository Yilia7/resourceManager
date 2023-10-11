/**
 * SuggestController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    suggestCreate:async function(req,res){

        // sails.log(req.allParams());

        await Suggest.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    suggestAuto:async function(req,res){

        Suggest.find()
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

