using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_name:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject account;
		public Vector3 UIOriginalPositionaccount;

		public GameObject accountInput;
		public Vector3 UIOriginalPositionaccountInput;

		public GameObject password;
		public Vector3 UIOriginalPositionpassword;

		public GameObject passwordInput;
		public Vector3 UIOriginalPositionpasswordInput;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			account=this.transform.Find("account").gameObject;
			accountInput=this.transform.Find("accountInput").gameObject;
			password=this.transform.Find("password").gameObject;
			passwordInput=this.transform.Find("passwordInput").gameObject;
		}
	}
}
