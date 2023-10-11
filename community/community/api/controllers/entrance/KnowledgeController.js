/**
 * KnowledgeController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    knowledgeAuto:async function(req,res){

        Knowledge.find()//返回所有数据
        .sort([{ 
            createdAt: 'DESC' 
        }])
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },
  
    knowledgeCreate:async function(req,res){

        await Knowledge.create(req.allParams())//创建-添加数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },

    knowledgeItem:async function(req,res){

        Knowledge.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].knowledgeTitle == req.query.knowledgeTitle&&data[i].knowledgeContent==req.query.knowledgeContent&&
                    data[i].knowledgePicture==req.query.knowledgePicture){
                   res.send(i.toString());
                break;
                }
            }
        });
        
    },

    knowledgeFindByRow:async function(req,res){

        Knowledge.find({})//返回所有数据
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

    knowledgeFindByTitle:async function(req,res){

        Knowledge.find({
            knowledgeTitle:req.query.knowledgeTitle
        })//返回包含关键字的记录
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    knowledgeUpdate:async function(req,res){

        if(req.query.newKnowledgeTitle!=""){
            // sails.log("old "+req.query.oldNewsTitle);
            // sails.log("new "+req.query.newNewsTitle);
            Knowledge.update({knowledgeTitle:req.query.oldKnowledgeTitle})//修改原数据为新数据
            .where({
                knowledgeContent:req.query.knowledgeContent,
                knowledgePicture:req.query.knowledgePicture,
            })
            .set({
                knowledgeTitle:req.query.newKnowledgeTitle,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newKnowledgeContent!=""){
            // sails.log("old "+req.query.oldNewsContent);
            // sails.log("new "+req.query.newNewsContent);
            Knowledge.update({knowledgeContent:req.query.oldKnowledgeContent})//修改原数据为新数据
            .where({
                knowledgeTitle:req.query.knowledgeTitle,
                knowledgePicture:req.query.knowledgePicture,
            })
            .set({
                knowledgeContent:req.query.newKnowledgeContent,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        
    },

    knowledgeDelete:async function(req,res){

        Knowledge.destroy({
            knowledgeTitle:req.query.knowledgeTitle,
            knowledgeContent:req.query.knowledgeContent,
            knowledgePicture:req.query.knowledgePicture,
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        })    
    },

    knowledgeShow:async function(req,res){

        Knowledge.find().limit(6)//返回所有数据
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

