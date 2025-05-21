using System.Collections;
using System.Collections.Generic;
using Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LoginTestSubView : BaseSubView
    {
        private InputField inputAccount;
        private InputField inputToken;
        private InputField inputPlatform;
        private Button BtnLogin;
        private Button BtnREmulateLogin;
        private Button BtnBeat;

        private InputField inputIP;
        private Button BtnConnect;
        public LoginTestSubView(GameObject targetGo, BaseViewController viewController) : base(targetGo, viewController)
        {

        }

        public override void BuildUIContent()
        {
            base.BuildUIContent();
            inputAccount = TargetGo.transform.Find("InputAccount").GetComponent<InputField>();
            inputToken = TargetGo.transform.Find("InputToken").GetComponent<InputField>();
            inputPlatform = TargetGo.transform.Find("InputPlatform").GetComponent<InputField>();
            BtnLogin = TargetGo.transform.Find("BtnLogin").GetComponent<Button>();
            BtnLogin.onClick.AddListener(OnClickLogin);
            inputIP = TargetGo.transform.Find("InputIP").GetComponent<InputField>();
            BtnConnect = TargetGo.transform.Find("BtnConnect").GetComponent<Button>();
            BtnConnect.onClick.AddListener(OnClickConnect);
            BtnBeat = TargetGo.transform.Find("Beat").GetComponent<Button>();
            BtnBeat.onClick.AddListener(OnBeat);

			if (SocketMgr.Instance.Status != SocketMgr.status.Connected)
			{
				string[] temp = inputIP.text.Split(':');
				LoginModel.Instance.inputIP = temp;
				Debug.Log ("显示IP" + temp[0]);
				SocketMgr.Instance.ConnectIPv4(temp[0],int.Parse(temp[1]));
			}
            var mover =BtnLogin.gameObject.AddComponent<LoginViewMover>();
            mover.speed = 10;
            mover.max = 10;
            mover.min = -10;
        }
        
        private void OnClickConnect()
        {
            if (SocketMgr.Instance.Status != SocketMgr.status.Connected)
            {
                string[] temp = inputIP.text.Split(':');

                SocketMgr.Instance.ConnectIPv4(temp[0],int.Parse(temp[1]));
            }
        }

        private void OnClickLogin()
        {
            //LoginController.Instance.Login(inputAccount.text,inputToken.text,int.Parse(inputPlatform.text));
        }

        private void OnBeat()
        {
//            HeartBeatController.Instance.OnBeat();
//            Debug.LogError("------OnClick------");

            //CommonController.Instance.ReqSendAction();
//            Farm_Game_MapInfoModel.Instance.InitModel();
//            CommonController.Instance.SendMapInfoReq();
//            CommonController.Instance.SendUserInfoReq();
            
        }
    }


}
