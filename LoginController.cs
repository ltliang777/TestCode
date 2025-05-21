using System;
using Framework;
using UnityEngine;

namespace Game
{
    public class LoginController : BaseController<LoginController>
    {
		//private GameObject WorldObject;
		//public static bool AllFinishInit;

        protected override Type GetEventType()
        {
            return typeof(LoginEvent);
        }

        public override void InitController()
        {

			//WorldObject = GameObject.Find ("WorldObject");
            _Proxy = new NetProxy(NetModules.Account.ModuleId); //这里是初始化本模块的网络组件

            SocketParser.Instance.RegisterParser(NetModules.Account.ModuleId, NetModules.Account.Login, UserEnterServerResponse.ParseFrom); //注册对应消息（在服务器发过来时）的Proto解析器
            _Proxy.AddNetListenner(NetModules.Account.Login, LoginCallback); //注册对应消息（在服务器发过来时）的回调

            //SocketParser.Instance.RegisterParser(NetModules.Account.ModuleId, NetModules.Account.text, TestResponse.ParseFrom); //测试
            //_Proxy.AddNetListenner(NetModules.Account.text, TestCallback); //


            //SocketParser.Instance.RegisterParser(NetModules.Account.ModuleId, NetModules.Account.ReLogin, UserEnterServerResponse.ParseFrom);

            //SocketParser.Instance.RegisterParser(NetModules.Account.ModuleId, NetModules.Account.Logout,
            //                Farm_Game_Exit_Req.ParseFrom); //注册对应消息（在服务器发过来时）的Proto解析器
            //_Proxy.AddNetListenner(NetModules.Account.Logout, LogoutCallback);

            //Debug.Log("实例化");
            // _Proxy.AddNetListenner(NetModules.Account.ReLogin, ReLoginCallback);

            //_Proxy.AddNetListenner(NetModules.Account.ReqCreateName, CreateNameCallback);
        }

        private void CreateNameCallback(MsgRec msg)
        {
            if (msg.succ == 1)
            {
                Debug.Log("创建角色成功");
            }
        }

        private void ReLoginCallback(MsgRec msg)
        {
			Debug.Log("重连:" + msg.bodyLength);
            if (msg.succ == 1)
            {
                Debug.Log(msg._proto.ToString());
            }
        }

        private void LogoutCallback(MsgRec msg)
        {
            if (msg.succ == 1)
            {
                Debug.Log("登出成功");
				//GlobalDispatcher.Instance.Dispatch (GlobalEvent.OnDialog, "登出成功");
            }
        }

		public void LogoutReq(int usergameID)
		{
            //var builder = Farm_Game_Exit_Req.CreateBuilder();
            //builder.UserGameID = usergameID;
            //_Proxy.SendMsg(NetModules.Account.ModuleId, NetModules.Account.Logout, builder);

        }

        private void TestCallback(MsgRec msg)
        {
            //TestResponse p = (TestResponse)msg._proto;

            //Debug.Log("打印命令:" + );

        }
        
        /// <summary>
        /// 注意此方法已经在_Proxy.AddNetListenner
        /// 于是在服务器发来对应消息后，本方法被调用
        /// </summary>
        /// <param name="msg"></param>
        private void LoginCallback(MsgRec msg)
        {
            UserEnterServerResponse p = (UserEnterServerResponse)msg._proto ;
            //ResponeLogin p = (ResponeLogin) msg._proto; //取出Proto对象（在注册了本消息的Proto解析器后，此项才可能存在
            //         LoginModel.Instance.roleName = p.Username; //从Proto对象中取值
            //         LoginModel.Instance.Continuousdays = p.ContinuousDays;
            //LoginModel.Instance.gamecode = p.Gamecode;
            //         LoginModel.Instance.Days = p.Days;
            //LoginModel.Instance.Status = p.Status;

            //         Debug.Log("打印名字:"+p.Username);

            //LoginModel.Instance.userUid = p.PlayerId;
            //LoginModel.Instance.roleName = p.Nickname;

            
            LoginModel.Instance.playerInfo.playerUdpId = p.PlayerInfo.ServerPlayerId;
            Debug.Log("打印登陆玩家:" + LoginModel.Instance.playerInfo.playerUdpId);
            LoginModel.Instance.playerInfo.playerId = p.PlayerInfo.PlayerId;
            LoginModel.Instance.playerInfo.nickname = p.PlayerInfo.Nickname;
            LoginModel.Instance.playerInfo.sex = p.PlayerInfo.Sex;
            LoginModel.Instance.playerInfo.likeNum = p.PlayerInfo.LikeNum;
            LoginModel.Instance.playerInfo.vce3 = new Vector3(p.PlayerInfo.X,p.PlayerInfo.Y,p.PlayerInfo.Z);
            LoginModel.Instance.playerInfo.roaY = p.PlayerInfo.AngleY;
            LoginModel.Instance.playerInfo.status = p.PlayerInfo.Status;
            //Debug.Log("状态值:" + LoginModel.Instance.playerInfo.status);
            //Debug.Log("打印名字:" + p.PlayerInfo.Nickname);

            //byte[] a = new byte[1];
            //a[0] = 0;
            MissionController.Instance.TaskRequest(0); //发送任务列表

            //MissionController.Instance.ElementRequest();//发送元素列表


            GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnInitGameAssets);

            if (LoginModel.Instance.Status == -1) {
			
				//GlobalDispatcher.Instance.Dispatch (GlobalEvent.OnDialog, "没有此帐号");
			}
			if (LoginModel.Instance.Status == -2) {

				//GlobalDispatcher.Instance.Dispatch (GlobalEvent.OnDialog, "密码错误");
			}

			if (LoginModel.Instance.Status == 1) {

				//ViewMgr.Instance.Close(ViewNames.LoginView);
				//ViewMgr.Instance.Open(ViewNames.HallUIView);
				//ViewMgr.Instance.Open(ViewNames.PlantToolsView);
//			CommonController.Instance.InitController();
				//CommonController.Instance.ReqUserInfoSendAction ();
				//HeartBeatController.Instance.InitController ();
//			ChatController.Instance.InitController ();
//			PersonInfoController.Instance.InitController();
//			ShopController.Instance.InitController();
//			StoreController.Instance.InitController();
//			PayController.Instance.InitController ();
//			PkController.Instance.InitController ();
//			MoneyShopController.Instance.InitController ();
//			ServerMsgController.Instance.InitController ();

//			FarmLandView.Instance.Init ();
//			FarmLandController.Instance.InitController();
//			PlantToolsController.Instance.InitController();
//			MarketController.Instance.InitController ();
//			MessageController.Instance.InitController ();
//			FriendController.Instance.InitController ();


				//WorldObject.transform.Find ("BG/OCEAN").gameObject.SetActive (false);
				//FarmLandView.Instance.Farmland.SetActive (true);
//			GetDispatcher().Dispatch(LoginEvent.OnLoginSucc);
//			GetDispatcher().Dispatch(LoginEvent.LoginViewRefresh);
				//PkController.Instance.FirstTime = 0;
				//PkController.Instance.FirstTime1 = 0;
				//PkController.Instance.FirstTime2 = 0;
				//AllFinishInit = true;
			}
        }


        public void Login(string token)
        //public void Login(string account, string token, int platform)
        {
            UserEnterServerRequest.Builder builder = UserEnterServerRequest.CreateBuilder();
            //ReqLogin.Builder builder = ReqLogin.CreateBuilder();
            //builder.Account = account;
            //builder.Token = token;
            builder.Token = token;
            //builder.Platform = platform;

            _Proxy.SendMsg(NetModules.Account.ModuleId, NetModules.Account.Login, builder);

        }

        //public void Test(string token)
        //{

        //    TestRequest.Builder builder = TestRequest.CreateBuilder();
        //    //ReqLogin.Builder builder = ReqLogin.CreateBuilder();
        //    //builder.Account = account;
        //    //builder.Token = token;
        //    builder.Token = token;
        //    //builder.Platform = platform;

        //    _Proxy.SendMsg(NetModules.Account.ModuleId, NetModules.Account.text, builder);

        //}

        public void ReqRelogin(string account, string token, string gamecode)
        {
   //         ReqReLogin.Builder builder = ReqReLogin.CreateBuilder();
   //         builder.Account = account;
			//builder.Gamecode = gamecode;
   //         builder.Token = token;
			//_Proxy.SendMsg(NetModules.Account.ModuleId, NetModules.Account.ReLogin, builder);

        }

    }

    public class LoginEvent : EventDispatcher.BaseEvent
    {
        public static readonly int OnLoginSucc = ++id;
        public static readonly int LoginViewRefresh = ++id;
    }

}
