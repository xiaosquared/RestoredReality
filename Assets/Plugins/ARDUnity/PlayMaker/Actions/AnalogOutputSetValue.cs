using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("AnalogOutput.SetValue")]
	public class AnalogOutputSetValue : FsmStateAction
	{
		[RequiredField]
		public AnalogOutput analogOutput;
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            analogOutput = null;
            // default axis to variable dropdown with None selected.
			value = new FsmFloat { UseVariable = false };
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
				if(!value.IsNone)
					analogOutput.Value = value.Value;
			}
		}
	}
}
