using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("DialSlider.GetAngle")]
	public class DialSliderGetAngle : FsmStateAction
	{
		[RequiredField]
		public DialSlider dialSlider;
		[UIHint(UIHint.Variable)]
		public FsmFloat angle;
		public bool everyFrame;

		public override void Reset()
		{
            dialSlider = null;
            // default axis to variable dropdown with None selected.
			angle = null;
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
			if(dialSlider != null)
			{
				if(angle != null)
					angle.Value = dialSlider.angle;
			}
		}
	}
}

