/**
 * UserController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    register:async function(req,res){

        // sails.log(req.allParams());

        await User.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    login:async function(req,res){

        // sails.log(req.query.username);//传过来的数据
        User.find({
            userName:req.query.userName,
            userPassword:req.query.userPassword,
        })
        .exec(function(err,data){
            if(err) 
                return next(err);
            console.log(data);
            res.send(data);
        });
        
    },

    userAuto:async function(req,res){

        User.find()//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    userItem:async function(req,res){

        User.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].userName == req.query.userName&&data[i].userGender == req.query.userGender&&
                    data[i].userPassword == req.query.userPassword &&data[i].tent == req.query.tent
                    &&data[i].unit == req.query.unit&&data[i].room == req.query.room&&data[i].userTel == req.query.userTel){
                   res.send(i.toString());
                break;
                }
            }
        });
        
    },

    userFindByRow:async function(req,res){

        User.find({})//返回所有数据
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

    userFindByName:async function(req,res){

        User.find({userName:req.query.userName
        })//返回包含关键字的记录
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },

    userFindByNamePassword:async function(req,res){

        User.find({
            userName:req.query.userName,
            userPassword:req.query.userPassword
        })//返回包含关键字的记录
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data);
            res.send(data);
        });
        
    },


    userUpdate:async function(req,res){

        if(req.query.newUserPassword!=""){
            User.update({userPassword:req.query.oldUserPassword})//修改原数据为新数据
            .where({
                userName:req.query.userName,
                userGender:req.query.userGender,
                tent:req.query.tent,
                unit:req.query.unit,
                room:req.query.room,
                userTel:req.query.userTel,
            })
            .set({
                userPassword:req.query.newUserPassword,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
    
    },

    userDelete:async function(req,res){

        User.destroy({
            userName:req.query.userName,
            userGender:req.query.userGender,
            userPassword:req.query.userPassword,
            tent:req.query.tent,
            unit:req.query.unit,
            room:req.query.room,
            userTel:req.query.userTel,
        })
            .exec(function(err,data){
                if(err) 
                  return next(err);
                res.send(data);
        })
        
    },

    userShow:async function(req,res){

        User.find()//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            // sails.log(data.length);
            for(var i=0;i<data.length;i++){
                if((i+1) == data.length){//返回最新数据
                    // sails.log(data[i]);
                    res.send(data[i]);
                }
            }
        });
        
    },

};

