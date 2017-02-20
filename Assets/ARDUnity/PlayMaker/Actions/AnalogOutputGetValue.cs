using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("AnalogOutput.GetValue")]
	public class AnalogOutputGetValue : FsmStateAction
	{
		[RequiredField]
		public AnalogOutput analogOutput;
		[UIHint(UIHint.Variable)]
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            analogOutput = null;
            // default axis to variable dropdown with None selected.
			value = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			DoAction();
			
			if(!everyFrame)
			    Finish();
		}

		public override void OnUpdate()
		{			
			DoAction();
		}
		
		private void DoAction()
		{
			if(analogOutput != null)
			{
				if(value != null)
					value.Value = analogOutput.Value;
			}
		}
	}
}
