using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class ui_paiwei:UGuiForm{

		public GameObject BG;
		public Vector3 UIOriginalPositionBG;

		public GameObject btn_exit;
		public Vector3 UIOriginalPositionbtn_exit;

		public GameObject btn_singe;
		public Vector3 UIOriginalPositionbtn_singe;

		public GameObject btn_double;
		public Vector3 UIOriginalPositionbtn_double;

		public GameObject Rank_img;
		public Vector3 UIOriginalPositionRank_img;

		public GameObject duanwei;
		public Vector3 UIOriginalPositionduanwei;

		public GameObject Score;
		public Vector3 UIOriginalPositionScore;

		public GameObject rank;
		public Vector3 UIOriginalPositionrank;

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
			Rank_img=this.transform.Find("Rank_img").gameObject;
			duanwei=this.transform.Find("duanwei").gameObject;
			Score=this.transform.Find("Score").gameObject;
			rank=this.transform.Find("rank").gameObject;
		}
	}
}
