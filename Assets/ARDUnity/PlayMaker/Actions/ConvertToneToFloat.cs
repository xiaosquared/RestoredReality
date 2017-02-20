using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("Convert ToneFrequency to Float")]
	public class ConvertToneToFloat : FsmStateAction
	{
		public ToneFrequency toneFrequency;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat floatVariable;


		public override void Reset()
		{
			floatVariable = null;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			
			if(floatVariable != null)
			{
				floatVariable.Value = (float)toneFrequency;
			}
			
			Finish();
		}
	}
}