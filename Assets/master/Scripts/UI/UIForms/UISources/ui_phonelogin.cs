using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_phonelogin:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject btn_exit;
		public Vector3 UIOriginalPositionbtn_exit;

		public GameObject tog_pwd_login;
		public Vector3 UIOriginalPositiontog_pwd_login;

		public GameObject tog_yzm_login;
		public Vector3 UIOriginalPositiontog_yzm_login;

		public GameObject pwd_login;
		public Vector3 UIOriginalPositionpwd_login;

		public GameObject yzm_login;
		public Vector3 UIOriginalPositionyzm_login;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			btn_exit=this.transform.Find("btn_exit").gameObject;
			tog_pwd_login=this.transform.Find("tog_pwd_login").gameObject;
			tog_yzm_login=this.transform.Find("tog_yzm_login").gameObject;
			pwd_login=this.transform.Find("pwd_login").gameObject;
			yzm_login=this.transform.Find("yzm_login").gameObject;
		}
	}
}
