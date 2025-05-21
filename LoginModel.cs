using Framework;
using UnityEngine;
namespace Game
{
    public class PlayerInfo
    {
        public long playerId;

        public int playerUdpId;

        public string nickname;

        public Vector3 vce3;

        public float roaY;

        public int status;

        public int sex;

        public int likeNum;
    }

    public class LoginModel : BaseModel<LoginModel>
    {

        public string roleName = "defaultname";
        public long userUid;
        public string gamecode;
        public int Days;
        public int Continuousdays;
	    public int Status;
	    public string Account;
	    public string Token;

	    public string[] inputIP;

        public bool success;
        public string msg;
        public PlayerInfo playerInfo;

        public override void InitModel()
        {
            playerInfo = new PlayerInfo();
        }

        //public  void SetData(Farm_Game_UserInfo_Anw GenerateAnw)
        //{
        
        //}
    }


}
