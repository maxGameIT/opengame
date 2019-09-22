using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class forgetpassword:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject title;
		public Vector3 UIOriginalPositiontitle;

		public GameObject phoneNum;
		public Vector3 UIOriginalPositionphoneNum;

		public GameObject yzm;
		public Vector3 UIOriginalPositionyzm;

		public GameObject password;
		public Vector3 UIOriginalPositionpassword;

		public GameObject checkpassword;
		public Vector3 UIOriginalPositioncheckpassword;

		public GameObject btn_ok;
		public Vector3 UIOriginalPositionbtn_ok;

		public GameObject btn_exit;
		public Vector3 UIOriginalPositionbtn_exit;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			title=this.transform.Find("title").gameObject;
			phoneNum=this.transform.Find("phoneNum").gameObject;
			yzm=this.transform.Find("yzm").gameObject;
			password=this.transform.Find("password").gameObject;
			checkpassword=this.transform.Find("checkpassword").gameObject;
			btn_ok=this.transform.Find("btn_ok").gameObject;
			btn_exit=this.transform.Find("btn_exit").gameObject;
		}
	}
}
