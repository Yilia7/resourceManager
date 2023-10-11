/**
 * RealTimeController
 *
 * @description :: Server-side actions for handling incoming requests.
 * @help        :: See https://sailsjs.com/docs/concepts/actions
 */

module.exports = {
  
    realTimeCreate:async function(req,res){

        // sails.log(req.allParams());

        await RealTime.create(req.allParams())//创建-添加数据
        return res.ok();
        
    },

    realTimeAuto:async function(req,res){

        RealTime.find()//返回所有数据
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

    realTimeItem:async function(req,res){

        RealTime.find({})//返回所有数据
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

    realTimeFindByRow:async function(req,res){

        RealTime.find({})//返回所有数据
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

    realTimeUpdate:async function(req,res){

        if(req.query.newDiagnose!=""){
            // sails.log("old ",req.query.oldDiagnose);
            // sails.log("new ",req.query.newDiagnose);
            RealTime.update({diagnose:req.query.oldDiagnose})//修改原数据为新数据
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
            RealTime.update({increase:req.query.oldIncrease})//修改原数据为新数据
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
            RealTime.update({summary:req.query.oldSummary})//修改原数据为新数据
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
            RealTime.update({asymptomatic:req.query.oldAsymptomatic})//修改原数据为新数据
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

    realTimeDelete:async function(req,res){

        RealTime.destroy({
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

    realTimeShow:async function(req,res){

        RealTime.find()//返回所有数据
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

