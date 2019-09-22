using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_fight:UGuiForm{

		public GameObject bg;
		public Vector3 UIOriginalPositionbg;

		public GameObject hero_info_1;
		public Vector3 UIOriginalPositionhero_info_1;

		public GameObject hero_info_2;
		public Vector3 UIOriginalPositionhero_info_2;

		public GameObject hero_info_3;
		public Vector3 UIOriginalPositionhero_info_3;

		public GameObject hero_info_4;
		public Vector3 UIOriginalPositionhero_info_4;

		public GameObject hero_info_5;
		public Vector3 UIOriginalPositionhero_info_5;

		public GameObject chuansongmen;
		public Vector3 UIOriginalPositionchuansongmen;

		public GameObject player_info;
		public Vector3 UIOriginalPositionplayer_info;

		public GameObject view_items;
		public Vector3 UIOriginalPositionview_items;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			bg=this.transform.Find("bg").gameObject;
			hero_info_1=this.transform.Find("hero_info_1").gameObject;
			hero_info_2=this.transform.Find("hero_info_2").gameObject;
			hero_info_3=this.transform.Find("hero_info_3").gameObject;
			hero_info_4=this.transform.Find("hero_info_4").gameObject;
			hero_info_5=this.transform.Find("hero_info_5").gameObject;
			chuansongmen=this.transform.Find("chuansongmen").gameObject;
			player_info=this.transform.Find("player_info").gameObject;
			view_items=this.transform.Find("view_items").gameObject;
		}
	}
}
