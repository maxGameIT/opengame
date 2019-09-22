using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_main:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject Gold;
		public Vector3 UIOriginalPositionGold;

		public GameObject btn_friend ;
		public Vector3 UIOriginalPositionbtn_friend ;

		public GameObject btn_email;
		public Vector3 UIOriginalPositionbtn_email;

		public GameObject btn_setting;
		public Vector3 UIOriginalPositionbtn_setting;

		public GameObject touxiang;
		public Vector3 UIOriginalPositiontouxiang;

		public GameObject name;
		public Vector3 UIOriginalPositionname;

		public GameObject btn_singe;
		public Vector3 UIOriginalPositionbtn_singe;

		public GameObject btn_double;
		public Vector3 UIOriginalPositionbtn_double;

		public GameObject btn_Rune;
		public Vector3 UIOriginalPositionbtn_Rune;

		public GameObject btn_handbook;
		public Vector3 UIOriginalPositionbtn_handbook;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			BG=this.transform.Find("BG").gameObject;
			Gold=this.transform.Find("Gold").gameObject;
			btn_friend =this.transform.Find("btn_friend ").gameObject;
			btn_email=this.transform.Find("btn_email").gameObject;
			btn_setting=this.transform.Find("btn_setting").gameObject;
			touxiang=this.transform.Find("touxiang").gameObject;
			name=this.transform.Find("name").gameObject;
			btn_singe=this.transform.Find("btn_singe").gameObject;
			btn_double=this.transform.Find("btn_double").gameObject;
			btn_Rune=this.transform.Find("btn_Rune").gameObject;
			btn_handbook=this.transform.Find("btn_handbook").gameObject;
		}
	}
}
