/**
 * Route Mappings
 * (sails.config.routes)
 *
 * Your routes tell Sails what to do each time it receives a request.
 *
 * For more information on configuring custom routes, check out:
 * https://sailsjs.com/anatomy/config/routes-js
 */

module.exports.routes = {

  /***************************************************************************
  *                                                                          *
  * Make the view located at `views/homepage.ejs` your home page.            *
  *                                                                          *
  * (Alternatively, remove this and add an `index.html` file in your         *
  * `assets` directory)                                                      *
  *                                                                          *
  ***************************************************************************/

  '/': { view: 'pages/homepage' },


  /***************************************************************************
  *                                                                          *
  * More custom routes here...                                               *
  * (See https://sailsjs.com/config/routes for examples.)                    *
  *                                                                          *
  * If a request to a URL doesn't match any of the routes in this file, it   *
  * is matched against "shadow routes" (e.g. blueprint routes).  If it does  *
  * not match any of those, it is matched against static assets.             *
  *                                                                          *
  ***************************************************************************/

    //user

    //login
   'GET /api/v1/entrance/login':                       
   {
   controller:'entrance/UserController',
   action: 'login',
   skipAssets:true
   },

   //register
   'GET /api/v1/entrance/register':                       
   {
   controller:'entrance/UserController',
   action: 'register',
   skipAssets:true
   },

   'GET /api/v1/entrance/userAuto':                       
   {
   controller:'entrance/userController',
   action: 'userAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/userCreate':                       
   {
   controller:'entrance/userController',
   action: 'userCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/userItem':                       
   {
   controller:'entrance/userController',
   action: 'userItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/userFindByName':                       
   {
   controller:'entrance/userController',
   action: 'userFindByName',
   skipAssets:true
   },

   'GET /api/v1/entrance/userFindByNamePassword':                       
   {
   controller:'entrance/userController',
   action: 'userFindByNamePassword',
   skipAssets:true
   },

   'GET /api/v1/entrance/userFindByRow':                       
   {
   controller:'entrance/userController',
   action: 'userFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/userUpdate':                       
   {
   controller:'entrance/userController',
   action: 'userUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/userDelete':                       
   {
   controller:'entrance/userController',
   action: 'userDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/userShow':                       
   {
   controller:'entrance/userController',
   action: 'userShow',
   skipAssets:true
   },

   //upload
   'POST /api/v1/fileUpload':                       
   {
   controller:'fileController',
   action: 'fileUpload',
   skipAssets:true
   },

   //healthyPunch
   'POST /api/v1/entrance/healthyPunchCreate':                       
   {
   controller:'entrance/HealthyPunchController',
   action: 'healthyPunchCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/healthyPunchSearch':                       
   {
   controller:'entrance/HealthyPunchController',
   action: 'healthyPunchSearch',
   skipAssets:true
   },

   //needs
   'GET /api/v1/entrance/needsCreate':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/needsAuto':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/needsUpdate':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/needsItem':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/needsFindByRow':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/needsDelete':                       
   {
   controller:'entrance/NeedsController',
   action: 'needsDelete',
   skipAssets:true
   },

   //news

   'GET /api/v1/entrance/newsAuto':                       
   {
   controller:'entrance/NewsController',
   action: 'newsAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsCreate':                       
   {
   controller:'entrance/NewsController',
   action: 'newsCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsItem':                       
   {
   controller:'entrance/NewsController',
   action: 'newsItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsFindByTitle':                       
   {
   controller:'entrance/NewsController',
   action: 'newsFindByTitle',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsFindByRow':                       
   {
   controller:'entrance/NewsController',
   action: 'newsFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsUpdate':                       
   {
   controller:'entrance/NewsController',
   action: 'newsUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsDelete':                       
   {
   controller:'entrance/NewsController',
   action: 'newsDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/newsShow':                       
   {
   controller:'entrance/NewsController',
   action: 'newsShow',
   skipAssets:true
   },

   //realTime

   'GET /api/v1/entrance/realTimeAuto':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeCreate':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeItem':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeFindByRow':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeUpdate':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeDelete':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/realTimeShow':                       
   {
   controller:'entrance/RealTimeController',
   action: 'realTimeShow',
   skipAssets:true
   },

   //communityRealTime

   'GET /api/v1/entrance/communityRealTimeAuto':                       
   {
   controller:'entrance/communityrealTimeController',
   action: 'communityRealTimeAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeCreate':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeItem':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeFindByRow':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeUpdate':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeDelete':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityRealTimeShow':                       
   {
   controller:'entrance/CommunityRealTimeController',
   action: 'communityRealTimeShow',
   skipAssets:true
   },

   //communityNews

   'GET /api/v1/entrance/communityNewsCreate':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsShow':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsShow',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsAuto':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsItem':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsFindByRow':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsFindByTitle':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsFindByTitle',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsUpdate':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/communityNewsDelete':                       
   {
   controller:'entrance/communityNewsController',
   action: 'communityNewsDelete',
   skipAssets:true
   },

   //knowledge

   'GET /api/v1/entrance/knowledgeAuto':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeCreate':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeItem':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeFindByRow':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeFindByTitle':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeFindByTitle',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeUpdate':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeDelete':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/knowledgeShow':                       
   {
   controller:'entrance/KnowledgeController',
   action: 'knowledgeShow',
   skipAssets:true
   },

   //suggest
   'GET /api/v1/entrance/suggestCreate':                       
   {
   controller:'entrance/SuggestController',
   action: 'suggestCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/suggestAuto':                       
   {
   controller:'entrance/SuggestController',
   action: 'suggestAuto',
   skipAssets:true
   },

   //chief

   'GET /api/v1/entrance/chiefAuto':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefAuto',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefCreate':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefCreate',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefItem':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefItem',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefFindByRow':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefFindByRow',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefUpdate':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefUpdate',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefDelete':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefDelete',
   skipAssets:true
   },

   'GET /api/v1/entrance/chiefShow':                       
   {
   controller:'entrance/chiefController',
   action: 'chiefShow',
   skipAssets:true
   },

};
