using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("AnalogInput.GetValue")]
	public class AnalogInputGetValue : FsmStateAction
	{
		[RequiredField]
		public AnalogInput analogInput;
		[UIHint(UIHint.Variable)]
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            analogInput = null;
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
			if(analogInput != null)
			{
				if(value != null)
					value.Value = analogInput.Value;
			}
		}
	}
}
