using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("ColorOutput.SetColor")]
	public class ColorOutputSetColor : FsmStateAction
	{
		[RequiredField]
		public ColorOutput colorOutput;
		public FsmColor color;
		public bool everyFrame;

		public override void Reset()
		{
            colorOutput = null;
            // default axis to variable dropdown with None selected.
			color = new FsmColor { UseVariable = false };
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
			if(colorOutput != null)
			{
				if(!color.IsNone)
					colorOutput.color = color.Value;
			}
		}
	}
}
