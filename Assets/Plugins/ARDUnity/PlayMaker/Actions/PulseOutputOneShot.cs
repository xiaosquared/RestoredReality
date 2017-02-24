using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("PulseOutput.OneShot")]
	public class PulseOutputOneShot : FsmStateAction
	{
		[RequiredField]
		public PulseOutput pulseOutput;
		public FsmInt setTime;
		public FsmInt delayTime;

		public override void Reset()
		{
            pulseOutput = null;
            // default axis to variable dropdown with None selected.
			setTime = new FsmInt { UseVariable = true };
			delayTime = new FsmInt { UseVariable = true };
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			DoAction();

			Finish();
		}

		private void DoAction()
		{
			if(pulseOutput != null)
			{
				if(!setTime.IsNone)
					pulseOutput.setTime = setTime.Value;
				
				if(!delayTime.IsNone)
					pulseOutput.delayTime = delayTime.Value;
				
				pulseOutput.OneShot();
			}
		}
	}
}
