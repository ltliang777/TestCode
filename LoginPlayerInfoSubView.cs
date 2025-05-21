using Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Game
{
    public class LoginPlayerInfoSubView : BaseSubView
    {
        private Text playername;
        private Text NetStatus;
        public LoginPlayerInfoSubView(GameObject targetGo, BaseViewController viewController) : base(targetGo, viewController)
        {

        }

        public override void BuildUIContent()
        {
            base.BuildUIContent();
            playername = TargetGo.transform.Find("playername").GetComponent<Text>();
            NetStatus = TargetGo.transform.Find("NetStatus").GetComponent<Text>();
        }

        public override void OnOpen()
        {
            base.OnOpen();
            LoginController.Instance.GetDispatcher().AddListener(LoginEvent.LoginViewRefresh,Refresh);
            //GlobalDispatcher.Instance.AddListener(GlobalEvent.OnConnect,Refresh);
            GlobalDispatcher.Instance.AddListener(GlobalEvent.OnDisconnect,Refresh);
        }

        private bool Refresh(int eventId, object arg)
        {
            NetStatus.text = SocketMgr.Instance.Status.ToString();
            playername.text = LoginModel.Instance.roleName;
            return false;
        }

        public override void OnClose()
        {
            base.OnClose();
            LoginController.Instance.GetDispatcher().RemoveListener(LoginEvent.LoginViewRefresh, Refresh);
        }
    }

}
