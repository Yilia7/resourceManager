/**
 * CommunityNewsController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    communityNewsCreate:async function(req,res){

        // sails.log(req.allParams());

        await CommunityNews.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    communityNewsAuto:async function(req,res){

        // sails.log(req.allParams());

        CommunityNews.find()
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

    communityNewsShow:async function(req,res){

        CommunityNews.find().limit(3)
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

    communityNewsItem:async function(req,res){

        CommunityNews.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].communityNewsTitle == req.query.communityNewsTitle&&
                    data[i].communityNewsContent == req.query.communityNewsContent){
                   res.send(i.toString());
                break;
                }
            }
        });
    },

    
    communityNewsFindByRow:async function(req,res){

        CommunityNews.find({})//返回所有数据
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

    communityNewsFindByTitle:async function(req,res){

        CommunityNews.find({
            communityNewsTitle:req.query.communityNewsTitle
        })//返回包含关键字的记录
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    communityNewsUpdate:async function(req,res){

        if(req.query.newCommunityNewsTitle!=""){
            sails.log("old ",req.query.old);
            sails.log("new ",req.query.newDiagnose);
            CommunityNews.update({communityNewsTitle:req.query.oldCommunityNewsTitle})//修改原数据为新数据
            .where({
                communityNewsContent:req.query.communityNewsContent,
            })
            .set({
                communityNewsTitle:req.query.newCommunityNewsTitle,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newCommunityNewsContent!=""){
            CommunityNews.update({communityNewsContent:req.query.oldCommunityNewsContent})//修改原数据为新数据
            .where({
                communityNewsTitle:req.query.communityNewsTitle,
            })
            .set({
                communityNewsContent:req.query.newCommunityNewsContent,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        
    },

    communityNewsDelete:async function(req,res){

        CommunityNews.destroy({
            communityNewsTitle:req.query.communityNewsTitle,
            communityNewsContent:req.query.communityNewsContent,
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })

    },

};

