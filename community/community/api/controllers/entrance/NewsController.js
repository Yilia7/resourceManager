/**
 * NewsController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */


module.exports = {

    newsAuto:async function(req,res){

        News.find()//返回所有数据
        .sort([{ 
            createdAt: 'DESC' 
        }])
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },
  
    newsCreate:async function(req,res){

        await News.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    newsItem:async function(req,res){

        News.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].newsTitle == req.query.newsTitle&&data[i].newsContent==req.query.newsContent&&
                    data[i].newsPicture==req.query.newsPicture){
                   res.send(i.toString());
                break;
                }
            }
        });
        
    },

    newsFindByTitle:async function(req,res){

        News.find({newsTitle:{
            'contains':req.query.newsTitle
            }
        })//返回包含关键字的记录
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    newsFindByRow:async function(req,res){

        News.find({})//返回所有数据
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

    newsUpdate:async function(req,res){

        News.update({
            newsTitle:req.query.oldNewsTitle,
            newsContent:req.query.oldNewsContent
        })//修改原数据为新数据
        .where({
            newsTitle:req.query.oldNewsTitle,
            newsContent:req.query.oldNewsContent
        })
        .set({
            newsTitle:req.query.newNewsTitle,
            newsContent:req.query.newNewsContent
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })
        
    },

    newsDelete:async function(req,res){

        News.destroy({
            newsTitle:req.query.newsTitle,
            newsContent:req.query.newsContent,
            newsPicture:req.query.newsPicture,
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })    
    },

    newsShow:async function(req,res){

        News.find().limit(6)//返回所有数据
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

};

