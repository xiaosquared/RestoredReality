using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("GenericTone.SetFrequency")]
	public class GenericToneSetFrequency : FsmStateAction
	{
		[RequiredField]
		public GenericTone genericTone;
		public ToneFrequency toneFrequency;
		public FsmFloat frequency;
		public bool everyFrame;

		public override void Reset()
		{
            genericTone = null;
            toneFrequency = ToneFrequency.MUTE;
			frequency = new FsmFloat { UseVariable = true };
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
			if(genericTone != null)
			{
				if(!frequency.IsNone)
					genericTone.frequency = frequency.Value;
				else
					genericTone.toneFrequency = toneFrequency;
			}
		}
	}
}
