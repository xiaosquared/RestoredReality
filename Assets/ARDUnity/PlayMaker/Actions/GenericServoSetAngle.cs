using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("GenericServo.SetAngle")]
	public class GenericServoSetAngle : FsmStateAction
	{
		[RequiredField]
		public GenericServo genericServo;
		public FsmFloat angle;
		public bool everyFrame;

		public override void Reset()
		{
            genericServo = null;
            // default axis to variable dropdown with None selected.
			angle = new FsmFloat { UseVariable = false };
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
			if(genericServo != null)
			{
				if(!angle.IsNone)
				{
					float v = angle.Value;
					if(v > 180f)
						v -= 360f;
					else if(v < -180f)
						v += 360f;
					
					genericServo.angle = (int)v;
				}
			}
		}
	}
}

