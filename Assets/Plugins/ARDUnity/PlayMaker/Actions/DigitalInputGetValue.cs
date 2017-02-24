using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("DigitalInput.GetValue")]
	public class DigitalInputGetValue : FsmStateAction
	{
		[RequiredField]
		public DigitalInput digitalInput;
		[UIHint(UIHint.Variable)]
		public FsmBool value;
		[Tooltip("Event sent when value is true.")]
		public FsmEvent trueEvent;
		[Tooltip("Event sent when value is false.")]
		public FsmEvent falseEvent;
		public bool everyFrame;

		public override void Reset()
		{
            digitalInput = null;
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
			if(digitalInput != null)
			{
				if(value != null)
					value.Value = digitalInput.Value;
				
				if(digitalInput.Value)
				{
					if(trueEvent != null)
						Fsm.Event(trueEvent);
				}
				else
				{
					if(falseEvent != null)
						Fsm.Event(falseEvent);
				}
			}
		}
	}
}
