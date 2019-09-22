using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour 
{
	private Animation anim = null;

	private void Start () 
	{
		anim = GetComponent<Animation>();
	}

	private void OnGUI()
	{
		float btnSize = Screen.height / 8;

		if(GUI.Button(new Rect(0, btnSize * 0, btnSize, btnSize), "idle"))
		{
			anim.Play("idle");
		}
		if(GUI.Button(new Rect(0, btnSize * 1, btnSize, btnSize), "run"))
		{
			anim.Play("run");
		}
		if(GUI.Button(new Rect(0, btnSize * 2, btnSize, btnSize), "attack"))
		{
			anim.Play("attack");
		}
		if(GUI.Button(new Rect(0, btnSize * 3, btnSize, btnSize), "hit"))
		{
			anim.Play("hit");
		}
		if(GUI.Button(new Rect(0, btnSize * 4, btnSize, btnSize), "die"))
		{
			anim.Play("die");
		}
	}
}
