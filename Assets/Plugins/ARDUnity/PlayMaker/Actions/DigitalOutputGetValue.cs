using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("DigitalOutput.GetValue")]
	public class DigitalOutputGetValue : FsmStateAction
	{
		[RequiredField]
		public DigitalOutput digitalOutput;
		[UIHint(UIHint.Variable)]
		public FsmBool value;
		public bool everyFrame;

		public override void Reset()
		{
            digitalOutput = null;
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
			if(digitalOutput != null)
			{
				if(value != null)
					value.Value = digitalOutput.Value;
			}
		}
	}
}
