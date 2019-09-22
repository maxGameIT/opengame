using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_phoneregister:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject btn_exit;
		public Vector3 UIOriginalPositionbtn_exit;

		public GameObject title;
		public Vector3 UIOriginalPositiontitle;

		public GameObject phoneNum;
		public Vector3 UIOriginalPositionphoneNum;

		public GameObject password;
		public Vector3 UIOriginalPositionpassword;

		public GameObject checkpassword;
		public Vector3 UIOriginalPositioncheckpassword;

		public GameObject yzm;
		public Vector3 UIOriginalPositionyzm;

		public GameObject btn_ok;
		public Vector3 UIOriginalPositionbtn_ok;

		public GameObject playerName;
		public Vector3 UIOriginalPositionplayerName;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			btn_exit=this.transform.Find("btn_exit").gameObject;
			title=this.transform.Find("title").gameObject;
			phoneNum=this.transform.Find("phoneNum").gameObject;
			password=this.transform.Find("password").gameObject;
			checkpassword=this.transform.Find("checkpassword").gameObject;
			yzm=this.transform.Find("yzm").gameObject;
			btn_ok=this.transform.Find("btn_ok").gameObject;
			playerName=this.transform.Find("playerName").gameObject;
		}
	}
}
