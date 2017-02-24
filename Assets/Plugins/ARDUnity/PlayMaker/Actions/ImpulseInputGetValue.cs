using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("ImpulseInput.GetValue")]
	public class ImpulseInputGetValue : FsmStateAction
	{
		[RequiredField]
		public ImpulseInput impulseInput;
		[UIHint(UIHint.Variable)]
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            impulseInput = null;
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
			if(impulseInput != null)
			{
				if(value != null)
					value.Value = impulseInput.Value;
			}
		}
	}
}
