using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("CurveOutput.Play() with Option")]
	public class CurveOutputPlay : FsmStateAction
	{
		[RequiredField]
		public CurveOutput curveOutput;
		public FsmFloat multiplier;
		public FsmFloat speed;
		public FsmBool loop;

		public override void Reset()
		{
            curveOutput = null;
            // default axis to variable dropdown with None selected.
			multiplier = new FsmFloat { UseVariable = true };
			speed = new FsmFloat { UseVariable = true };
			loop = new FsmBool { UseVariable = true };
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(curveOutput != null)
			{
				if(!multiplier.IsNone)
					curveOutput.multiplier = multiplier.Value;

				if(!speed.IsNone)
					curveOutput.speed = speed.Value;

				if(!loop.IsNone)
					curveOutput.loop = loop.Value;

				curveOutput.Play();
			}
			
			Finish();
		}
	}
}
