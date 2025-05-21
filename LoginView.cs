using Framework;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LoginView : BaseSubView
    {
        private Button TestBtn;

        private Button loginBtn;
        private Button phoneloginBtn;

        private InputField inputAccount;
		private InputField inputToken;
		private string Account;

        private GameObject LoginPanel;
        private GameObject RegisterPanel;
        private GameObject LoginPhonePanel;
        private GameObject ForgotPanel;


        private Button ToregisterBtn;
        private Button forgotBtn;
        private Button Toregister2Btn;
        private Button forgot2Btn;
        private Button returnBtn;
        private Button returnBtn2;

        private InputField InputPhoneNum;
        private InputField InputUser2; 
        private InputField InputCode;
        private InputField InputCode2;
        private InputField InputPwr;
        private InputField InputComfitPwr;

        private Button registerBtn;
        private Button reqcodeBtn;
        private Button codeBtn;

        private Button phoneBtn;
        private Button acountBtn;

        //----------------------------忘记密码---------------------------//
        private Button pushBtn;//忘记密码提交
        private InputField InputPhoneNum2;
        private InputField InputCode3;
        private InputField InputPwr2;
        private InputField InputComfitPwr2;
        private Button reqcodeBtn2;
        private GameObject dialog;
        private string mobileNumberPattern = @"^1(3[0-9]|4[5-9]|5[0-35-9]|6[2567]|7[0-8]|8[0-9]|9[0-35-9])\d{8}$";
        private InputField InputUser, InputPassword;
        public LoginView(GameObject targetGo, BaseViewController viewController) : base(targetGo, viewController)
        {
            Debug.Log("fafafafafafa");
        }

        public override void BuildSubViews()
        {

            GlobalDispatcher.Instance.AddListener_string(GlobalEvent.OnPubDialog, OnPubDialog);
            loginBtn = TargetGo.transform.Find("LoginPanel/loginBtn").GetComponent<Button>();
			loginBtn.onClick.AddListener(OnClickLogin);
            phoneloginBtn = TargetGo.transform.Find("LoginPhonePanel/phoneloginBtn").GetComponent<Button>();
            phoneloginBtn.onClick.AddListener(OnClickPhoneLogin);

            InputUser = TargetGo.transform.Find("LoginPanel/InputUser").GetComponent<InputField>();
            InputPassword = TargetGo.transform.Find("LoginPanel/InputPassword").GetComponent<InputField>();

            TestBtn = TargetGo.transform.Find("TestBtn").GetComponent<Button>();
            TestBtn.onClick.AddListener(OnClickTestBtn);

            dialog = TargetGo.transform.Find("dialog").gameObject;
            dialog.AddComponent<DialogPub>();
            dialog.GetComponent<CanvasGroup>().alpha = 0;

            LoginPanel = TargetGo.transform.Find("LoginPanel").gameObject;
            RegisterPanel = TargetGo.transform.Find("RegisterPanel").gameObject;
            LoginPhonePanel = TargetGo.transform.Find("LoginPhonePanel").gameObject;
            ForgotPanel = TargetGo.transform.Find("ForgotPanel").gameObject;
            RegisterPanel.SetActive(false);
            LoginPhonePanel.SetActive(false);
            ForgotPanel.SetActive(false);

            ToregisterBtn = TargetGo.transform.Find("LoginPanel/toregisterBtn").GetComponent<Button>();
            ToregisterBtn.onClick.AddListener(OnClickToRegister);
            forgotBtn = TargetGo.transform.Find("LoginPanel/forgotBtn").GetComponent<Button>();
            forgotBtn.onClick.AddListener(OnClickForgot);
            Toregister2Btn = TargetGo.transform.Find("LoginPhonePanel/toregisterBtn").GetComponent<Button>();
            Toregister2Btn.onClick.AddListener(OnClickToRegister2);
            forgot2Btn = TargetGo.transform.Find("LoginPhonePanel/forgetBtn").GetComponent<Button>();
            forgot2Btn.onClick.AddListener(OnClickforgot2);

            phoneBtn = TargetGo.transform.Find("LoginPanel/phoneBtn").GetComponent<Button>();
            phoneBtn.onClick.AddListener(OnClickPhone);
            acountBtn = TargetGo.transform.Find("LoginPhonePanel/acountBtn").GetComponent<Button>();
            acountBtn.onClick.AddListener(OnClickAcountBtn);
            

            returnBtn = TargetGo.transform.Find("RegisterPanel/returnBtn").GetComponent<Button>();
            returnBtn.onClick.AddListener(OnClickReturn);
            returnBtn2 = TargetGo.transform.Find("ForgotPanel/returnBtn").GetComponent<Button>();
            returnBtn2.onClick.AddListener(OnClickReturn2);
            //			inputAccount = TargetGo.transform.Find("InputAccount").GetComponent<InputField>();
            //			inputToken = TargetGo.transform.Find("InputToken").GetComponent<InputField>();
            ////			inputPlatform = TargetGo.transform.Find("InputPlatform").GetComponent<InputField>();

            //            subViews = new List<BaseSubView>();
            //            subViews.Add(new LoginTestSubView(TargetGo.transform.Find("Tests").gameObject, ViewController));
            //            subViews.Add(new LoginPlayerInfoSubView(TargetGo.transform.Find("PlayerInfo").gameObject, ViewController));

            //			Account = PlayerPrefs.GetString ("Account");

            //			if (!Account.Equals ("")) {
            //				inputAccount.text = Account;
            //			}

            registerBtn = TargetGo.transform.Find("RegisterPanel/registerBtn").GetComponent<Button>();
            registerBtn.onClick.AddListener(OnClickRegisterPush);

            reqcodeBtn = TargetGo.transform.Find("RegisterPanel/reqcodeBtn").GetComponent<Button>();
            reqcodeBtn.onClick.AddListener(OnClickReCode);
            codeBtn = TargetGo.transform.Find("LoginPhonePanel/codeBtn").GetComponent<Button>();
            codeBtn.onClick.AddListener(OnClickCodeBtn);


            InputPhoneNum = TargetGo.transform.Find("RegisterPanel/InputPhoneNum").GetComponent<InputField>();
            InputUser2 = TargetGo.transform.Find("LoginPhonePanel/InputUser").GetComponent<InputField>();
            InputCode2 = TargetGo.transform.Find("LoginPhonePanel/InputCode").GetComponent<InputField>();
            InputCode = TargetGo.transform.Find("RegisterPanel/InputCode").GetComponent<InputField>();
            InputPwr = TargetGo.transform.Find("RegisterPanel/InputPwr").GetComponent<InputField>();
            InputComfitPwr = TargetGo.transform.Find("RegisterPanel/InputComfitPwr").GetComponent<InputField>();

            //--------------------------------忘记密码模块-------------------------------------//
            pushBtn = TargetGo.transform.Find("ForgotPanel/pushBtn").GetComponent<Button>(); //忘记密码提交
            pushBtn.onClick.AddListener(OnClickPushBtn);
            InputPhoneNum2 = TargetGo.transform.Find("ForgotPanel/InputPhoneNum").GetComponent<InputField>();
            InputCode3 = TargetGo.transform.Find("ForgotPanel/InputCode").GetComponent<InputField>();
            InputPwr2 = TargetGo.transform.Find("ForgotPanel/InputPwr").GetComponent<InputField>();
            InputComfitPwr2 = TargetGo.transform.Find("ForgotPanel/InputComfitPwr").GetComponent<InputField>();
            reqcodeBtn2 = TargetGo.transform.Find("ForgotPanel/reqcodeBtn").GetComponent<Button>();
            reqcodeBtn2.onClick.AddListener(OnClickReqcode);

            Debug.Log("加载完成");


            base.BuildSubViews();
        }

        private bool OnPubDialog(int eventId, string arg)
        {
            //Debug.Log("长度:" + arg);
            if (arg.Length > 1) //登录状态要有值
            {
                var req_json = JsonUtility.FromJson<MyPhoneArt>(arg);


                if (req_json.msg == "登录成功")
                {
                    loginBtn.GetComponent<CanvasGroup>().interactable = false;

                }
                if (req_json.msg == "登录失败")
                {
                    loginBtn.GetComponent<CanvasGroup>().interactable = true;

                }
                if (req_json.msg == "修改密码成功")
                {

                    LoginPanel.SetActive(true);
                    ForgotPanel.SetActive(false);
                }
                if (req_json.msg == "注册成功")
                {
                    LoginPanel.SetActive(true);
                    RegisterPanel.SetActive(false);
                }
                //else
                //{
                //    loginBtn.GetComponent<CanvasGroup>().interactable = true;
                //}
            }


            return false;
        }

        private void OnClickReqcode()
        {

            if (InputPhoneNum2.text.Length < 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
                return;
            }

            if (!NameJudgeFlage(InputPhoneNum2.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }


            //Debug.Log("点击");

            GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnPhoneMessageTime, reqcodeBtn2);
            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneMessage, InputPhoneNum2.text + "_" + 2);
        }

        /// <summary>
        /// 忘记密码修改
        /// </summary>
        private void OnClickPushBtn()
        {

            if (InputPhoneNum2.text.Length < 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
                return;
            }

            if (!NameJudgeFlage(InputPhoneNum2.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }


            if (string.IsNullOrWhiteSpace(InputCode3.text))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "验证码不能为空");
                return;
            }


            if (!ContainsLetterAndNumber(InputPwr2.text))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码需要包含字母和数字格式");
                return;
            }

            if (InputPwr2.text.Length < 6 && InputPwr2.text.Length > 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码长度不符合");
                return;
            }

            if (InputPwr2.text != InputComfitPwr2.text)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码不一致");
                return;
            }

            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnUpdatePassword, InputPhoneNum2.text + "/" + InputCode3.text + "/" + InputPwr2.text);
            InputPwr2.text = "";
            InputComfitPwr2.text = "";
        }

        /// <summary>
        /// 手机号登陆验证码
        /// </summary>
        private void OnClickCodeBtn()
        {

            //if (string.IsNullOrWhiteSpace(InputUser2.text))
            //{
            //    //Debug.Log("号码不能为空");
            //    GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能为空");
            //    return;
            //}

            if (InputUser2.text.Length < 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
                return;
            }

            if (!NameJudgeFlage(InputUser2.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }

            //Debug.Log("有错误？"+);
            GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnPhoneMessageTime, codeBtn);
            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneMessage, InputUser2.text + "_" + 1);

        }

        /// <summary>
        /// 手机号登录
        /// </summary>
        private void OnClickPhoneLogin()
        {
            if (InputUser2.text.Length < 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
                return;
            }

            if (!NameJudgeFlage(InputUser2.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }


            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneLogin, InputUser2.text + "/" + InputCode2.text);
            //GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneLogin, "18676634202" + "/" + "489241");

        }

        private void OnClickTestBtn()
        {
            //GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnTestUDP);
            //LoginController.Instance.Test("dsjofjweogn");
        }


        /// <summary>
        /// 注册发送验证码
        /// </summary>
        private void OnClickReCode()
        {
            if (string.IsNullOrWhiteSpace(InputPhoneNum.text))
            {
                Debug.Log("号码不能为空");
                return;
            }

            if (InputPhoneNum.text.Length < 11)
            {
                Debug.Log("号码不正确");
                return;
            }

            if (!NameJudgeFlage(InputPhoneNum.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }

            GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnPhoneMessageTime, reqcodeBtn);
            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneMessage, InputPhoneNum.text +"_" +0);

        }

        /// <summary>
        /// 注册
        /// </summary>
        private void OnClickRegisterPush()
        {
            if (InputPhoneNum.text.Length < 11)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
                return;
            }

            if (!NameJudgeFlage(InputPhoneNum.text, mobileNumberPattern))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
                return;
            }

            if (InputCode.text == "")
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "验证码不能为空");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(InputPwr.text.Trim()) && string.IsNullOrWhiteSpace(InputComfitPwr.text.Trim()))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码不能为空");
                return;
            }


            if (!ContainsLetterAndNumber(InputPwr.text))
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码需要包含字母和数字格式");
                return;
            }

            if (InputPwr.text != InputComfitPwr.text)
            {
                GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "密码不一致");
                return;
            }

            //Debug.Log("资料:" + InputPhoneNum.text + InputCode.text + InputPwr.text);
            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPhoneRegister, InputPhoneNum.text + InputCode.text + InputPwr.text);
            InputPwr.text = "";
            InputComfitPwr.text = "";
        }


        /// <summary>
        /// 帐号登录
        /// </summary>
        private void OnClickLogin()
		{

            //if (InputUser.text.Length < 11)
            //{
            //    GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "号码不能少于11位");
            //    return;
            //}

            //if (!NameJudgeFlage(InputUser.text, mobileNumberPattern))
            //{
            //    GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请正确输入手机号");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(InputPassword.text))
            //{
            //    GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog2, "请输入密码");
            //    return;
            //}
            Debug.Log("wwwwwwwwwwwww");
            //GlobalDispatcher.Instance.Dispatch(GlobalEvent.OnInitGameAssets);
            //GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnAccountLogin, "18676634202" + "/" + "cc123");
            GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnPubDialog, "");
            //GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnAccountLogin, "17602937470" + "/" + "123456");
            //GlobalDispatcher.Instance.Dispatch_string(GlobalEvent.OnAccountLogin, InputUser.text + "/" + InputPassword.text);

            InputPassword.text = "";
            //         TargetGo.transform.parent.parent.Find("videoScreen").gameObject.SetActive(false);

            //         ViewMgr.Instance.Close(ViewNames.LoginView);

            //ViewMgr.Instance.Open(ViewNames.ClockInView);
            //         ViewMgr.Instance.Open(ViewNames.TopMenuView);

            //         //GlobalDispatcher.Instance.Dispatch (GlobalEvent.OnMusicEffectChannel,11);
            //ViewMgr.Instance.Open(ViewNames.ActionView);

            //			if (!Account.Equals ("")) {
            //				inputAccount.text = Account;
            //			}
            //			inputAccount.text = "admin";
            //			inputAccount.text = "test8";
            //			inputAccount.text = "test7";
            //			inputAccount.text = "test5";
            //			inputAccount.text = "test10";
            //			inputAccount.text = "test2";
            //			inputToken.text = "123345";
            //			inputToken.text = "123456";
            //			inputToken.text = "111111";
            //			inputToken.text = "888888";
            //			inputPlatform.text = "1";
            //			if (inputAccount.text.Length > 4) {
            ////				inputAccount.text = inputAccount.transform.GetChild (1).GetComponent<Text> ().text;
            ////				Debug.Log ("新值:"+inputAccount.text);
            //				PlayerPrefs.SetString ("Account", inputAccount.text);
            //			}
            ////				LoginController.Instance.Login (inputAccount.text, inputToken.text, 1);
            //			else {
            //				//GlobalDispatcher.Instance.Dispatch (GlobalEvent.OnDialog, "帐号不能空");

            //				return;
            //			}
            
        }

        private void OnClickReturn()
        {
            LoginPanel.SetActive(true);
            RegisterPanel.SetActive(false);
        }

        private void OnClickToRegister()
        {
            LoginPanel.SetActive(false);
            RegisterPanel.SetActive(true);

        }
        private void OnClickforgot2()
        {
            LoginPhonePanel.SetActive(false);
            ForgotPanel.SetActive(true);
        }

        private void OnClickToRegister2()
        {
            LoginPhonePanel.SetActive(false);
            RegisterPanel.SetActive(true);
        }

        private void OnClickReturn2()
        {
            LoginPanel.SetActive(true);
            ForgotPanel.SetActive(false);

        }

        private void OnClickForgot()
        {
            LoginPanel.SetActive(false);
            ForgotPanel.SetActive(true);
        }

        private void OnClickAcountBtn()
        {
            LoginPanel.SetActive(true);
            LoginPhonePanel.SetActive(false);

        }

        private void OnClickPhone()
        {
            LoginPanel.SetActive(false);
            LoginPhonePanel.SetActive(true);

        }
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regularExpression"></param>
        /// <returns></returns>
        public bool NameJudgeFlage(string str, string regularExpression)
        {
            Regex reg = new Regex(regularExpression); // 判断
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regularExpression"></param>
        /// <returns></returns>
        public bool ContainsLetterAndNumber(string input)
        {
            return Regex.IsMatch(input, @"([a-zA-Z])+([0-9])+|([0-9])+([a-zA-Z])+");
        }
    }
}
