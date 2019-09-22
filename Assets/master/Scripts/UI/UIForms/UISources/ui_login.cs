using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_login:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject youke_btn;
		public Vector3 UIOriginalPositionyouke_btn;

		public GameObject wechat_btn;
		public Vector3 UIOriginalPositionwechat_btn;

		public GameObject phone_btn;
		public Vector3 UIOriginalPositionphone_btn;

		public GameObject phonereginster_btn;
		public Vector3 UIOriginalPositionphonereginster_btn;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			youke_btn=this.transform.Find("youke_btn").gameObject;
			wechat_btn=this.transform.Find("wechat_btn").gameObject;
			phone_btn=this.transform.Find("phone_btn").gameObject;
			phonereginster_btn=this.transform.Find("phonereginster_btn").gameObject;
		}
	}
}
