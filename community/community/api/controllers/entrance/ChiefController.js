/**
 * ChiefController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    chiefAuto:async function(req,res){

        Chief.find()//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },
  
    chiefCreate:async function(req,res){

        await Chief.create(req.allParams())//创建-添加数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },

    chiefItem:async function(req,res){

        Chief.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].chiefName == req.query.chiefName&&data[i].chiefPosts==req.query.chiefPosts&&
                    data[i].chiefTel==req.query.chiefTel&&data[i].chiefPicture==req.query.chiefPicture){
                   res.send(i.toString());
                //    sails.log(i.toString());
                break;
                }
            }
        });
        
    },

    chiefFindByRow:async function(req,res){

        Chief.find({})//返回所有数据
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

    chiefUpdate:async function(req,res){

        if(req.query.newChiefName!=""){
            Chief.update({chiefName:req.query.oldChiefName})//修改原数据为新数据
            .where({
                chiefPosts:req.query.chiefPosts,
                chiefTel:req.query.chiefTel,
                chiefPicture:req.query.chiefPicture,
            })
            .set({
                chiefName:req.query.newChiefName,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newChiefPosts!=""){
            Chief.update({chiefPosts:req.query.oldChiefPosts})//修改原数据为新数据
            .where({
                chiefName:req.query.chiefName,
                chiefTel:req.query.chiefTel,
                chiefPicture:req.query.chiefPicture,
            })
            .set({
                chiefPosts:req.query.newChiefPosts,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newChiefTel!=""){
            Chief.update({chiefTel:req.query.oldChiefTel})//修改原数据为新数据
            .where({
                chiefName:req.query.chiefName,
                chiefPost:req.query.chiefPost,
                chiefPicture:req.query.chiefPicture,
            })
            .set({
                chiefTel:req.query.newChiefTel,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        
    },

    chiefDelete:async function(req,res){

        Chief.destroy({
            chiefName:req.query.chiefName,
            chiefPosts:req.query.chiefPosts,
            chiefTel:req.query.chiefTel,
            chiefPicture:req.query.chiefPicture
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })    
    },

    chiefShow:async function(req,res){

        Chief.find().limit(4)//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

};

