using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("ArdunityApp.Connect()")]
	public class ArdunityAppConnect : FsmStateAction
	{
		[RequiredField]
		public ArdunityApp ardunityApp;

		public override void Reset()
		{
            ardunityApp = null;
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(ardunityApp != null)
                ardunityApp.Connect();
			
			Finish();
		}
	}
}
