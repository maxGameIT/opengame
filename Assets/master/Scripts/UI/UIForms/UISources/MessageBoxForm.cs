using UnityEngine;
using System.Collections;

namespace Master
{
	public partial class MessageBoxForm:UGuiForm{

		public GameObject Background;
		public Vector3 UIOriginalPositionBackground;

#if UNITY_2017_3_OR_NEWER
		protected override void OnInit(object userData)
#else
		protected internal override void OnInit(object userData)
#endif
		{
			base.OnInit(userData);
			Background=this.transform.Find("Background").gameObject;
		}
	}
}
