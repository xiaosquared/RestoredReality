using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("InputFilter.GetValue")]
	public class InputFilterGetValue : FsmStateAction
	{
		[RequiredField]
		public InputFilter inputFilter;
		[UIHint(UIHint.Variable)]
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            inputFilter = null;
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
			if(inputFilter != null)
			{
				if(value != null)
					value.Value = inputFilter.Value;
			}
		}
	}
}
