using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_singe:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject btn_exit;
		public Vector3 UIOriginalPositionbtn_exit;

		public GameObject btn_singe;
		public Vector3 UIOriginalPositionbtn_singe;

		public GameObject btn_double;
		public Vector3 UIOriginalPositionbtn_double;

		public GameObject btn_rank;
		public Vector3 UIOriginalPositionbtn_rank;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			btn_exit=this.transform.Find("btn_exit").gameObject;
			btn_singe=this.transform.Find("btn_singe").gameObject;
			btn_double=this.transform.Find("btn_double").gameObject;
			btn_rank=this.transform.Find("btn_rank").gameObject;
		}
	}
}
