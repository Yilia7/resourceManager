/**
 * CommunityRealTimeController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    communityRealTimeCreate:async function(req,res){

        // sails.log(req.allParams());

        await CommunityRealTime.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    communityRealTimeAuto:async function(req,res){

        CommunityRealTime.find()//返回所有数据
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

    communityRealTimeItem:async function(req,res){

        CommunityRealTime.find({})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if(data[i].diagnose == req.query.diagnose&&data[i].increase == req.query.increase&&
                    data[i].summary == req.query.summary&&data[i].asymptomatic == req.query.asymptomatic){
                   res.send(i.toString());
                break;
                }
            }
        });
        
    },

    communityRealTimeFindByTitle:async function(req,res){

        CommunityRealTime.find({diagnose:req.query.diagnose})//返回所有数据
        .exec(function(err,data){
            if(err) 
                return next(err);
            res.send(data);
        });
        
    },

    communityRealTimeFindByRow:async function(req,res){

        CommunityRealTime.find({})//返回所有数据
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

    communityRealTimeUpdate:async function(req,res){

        if(req.query.newDiagnose!=""){
            // sails.log("old ",req.query.oldDiagnose);
            // sails.log("new ",req.query.newDiagnose);
            CommunityRealTime.update({diagnose:req.query.oldDiagnose})//修改原数据为新数据
            .where({
                increase:req.query.increase,
                summary:req.query.summary,
                asymptomatic:req.query.asymptomatic,
            })
            .set({
                diagnose:req.query.newDiagnose,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newIncrease!=""){
            CommunityRealTime.update({increase:req.query.oldIncrease})//修改原数据为新数据
            .where({
                diagnose:req.query.diagnose,
                summary:req.query.summary,
                asymptomatic:req.query.asymptomatic,
            })
            .set({
                increase:req.query.newIncrease,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newSummary!=""){
            CommunityRealTime.update({summary:req.query.oldSummary})//修改原数据为新数据
            .where({
                diagnose:req.query.diagnose,
                increase:req.query.increase,
                asymptomatic:req.query.asymptomatic,
            })
            .set({
                summary:req.query.newSummary,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        if(req.query.newAsymptomatic!=""){
            CommunityRealTime.update({asymptomatic:req.query.oldAsymptomatic})//修改原数据为新数据
            .where({
                diagnose:req.query.diagnose,
                increase:req.query.increase,
                summary:req.query.summary,
            })
            .set({
                asymptomatic:req.query.newAsymptomatic,
            })
            .exec(function(err,data){
                if(err) 
                    return next(err);
                res.send(data);
            })
        }
        
    },

    communityRealTimeDelete:async function(req,res){

        CommunityRealTime.destroy({
            diagnose:req.query.diagnose,
            increase:req.query.increase,
            summary:req.query.summary,
            asymptomatic:req.query.asymptomatic
        })
            .exec(function(err,data){
                if(err) 
                  return next(err);
                res.send(data);
        })
        
    },

    communityRealTimeShow:async function(req,res){

        CommunityRealTime.find()//返回所有数据
        .sort([{ 
            createdAt: 'DESC' 
        }])
        .exec(function(err,data){
            if(err) 
                return next(err);
            for(var i=0;i<data.length;i++){
                if((i+1) == data.length){
                    // sails.log(data[i]);
                    res.send(data[i]);
                }
            }
        });
        
    },

};

