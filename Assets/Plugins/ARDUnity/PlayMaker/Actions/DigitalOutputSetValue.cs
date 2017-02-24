using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("DigitalOutput.SetValue")]
	public class DigitalOutputSetValue : FsmStateAction
	{
		[RequiredField]
		public DigitalOutput digitalOutput;
		public FsmBool value;
		public bool everyFrame;

		public override void Reset()
		{
            digitalOutput = null;
            // default axis to variable dropdown with None selected.
			value = new FsmBool { UseVariable = false };
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
				if(!value.IsNone)
					digitalOutput.Value = value.Value;
			}
		}
	}
}
