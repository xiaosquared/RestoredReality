using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("MappingInput.GetValue")]
	public class MappingInputGetValue : FsmStateAction
	{
		[RequiredField]
		public MappingInput mappingInput;
		[UIHint(UIHint.Variable)]
		public FsmFloat value;
		public bool everyFrame;

		public override void Reset()
		{
            mappingInput = null;
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
			if(mappingInput != null)
			{
				if(value != null)
					value.Value = mappingInput.Value;
			}
		}
	}
}
