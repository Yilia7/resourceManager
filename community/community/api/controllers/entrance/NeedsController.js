/**
 * NeedsController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    needsCreate:async function(req,res){

        sails.log(req.allParams());

        await Needs.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    needsUpdate:async function(req,res){

        // sails.log(req.query.oldNeedCheck);
        // sails.log(req.query.newNeedCheck);//传过来的是字符串-传回去再变成boolean
        Needs.update({needCheck:req.query.oldNeedCheck})//修改原数据为新数据
        .where({
            needName:req.query.needName,
            tent:req.query.tent,
            unit:req.query.unit,
            room:req.query.room,
            needs:req.query.needs
        })
        .set({
             needCheck:req.query.newNeedCheck,
            })
        .exec(function(err,data){
             if(err) 
                 return next(err);
                //  sails.log(data);
                res.send(data);
            })

    },

    needsAuto:async function(req,res){

        Needs.find()//返回所有数据
        .sort([{ 
            createdAt: 'DESC' 
        }])
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    needsItem:async function(req,res){

        Needs.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].needName == req.query.needName&&data[i].tent==req.query.tent&&
                    data[i].unit==req.query.unit&&data[i].room==req.query.room&&
                    data[i].needs==req.query.needs){
                   res.send(i.toString());
                break;
                }
            }
        });
        
    },

    needsFindByRow:async function(req,res){

        Needs.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(i == req.query.row){
                    // sails.log(data[i]);
                   res.send(data[i]);
                   break;
                }
            }
        });
        
    },

    needsDelete:async function(req,res){

        Needs.destroy({
            needName:req.query.needName,
            tent:req.query.tent,
            unit:req.query.unit,
            room:req.query.room,
            needs:req.query.needs,
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })

    },

};

