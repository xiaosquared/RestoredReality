using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("CurveOutput.Stop()")]
	public class CurveOutputStop : FsmStateAction
	{
		[RequiredField]
		public CurveOutput curveOutput;

		public override void Reset()
		{
            curveOutput = null;
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(curveOutput != null)
                curveOutput.Stop();
			
			Finish();
		}
	}
}
