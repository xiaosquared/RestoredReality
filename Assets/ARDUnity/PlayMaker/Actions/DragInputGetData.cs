using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("Get DragData from DragInput")]
	public class DragInputGetData : FsmStateAction
	{
		[RequiredField]
		public DragInput dragInput;
		[UIHint(UIHint.Variable)]
		public FsmBool isDrag;
		[UIHint(UIHint.Variable)]
		public FsmFloat dragDelta;
		[UIHint(UIHint.Variable)]
		public FsmFloat dragForce;	
		public bool everyFrame;	

		public override void Reset()
		{
            dragInput = null;
            isDrag = null;
			dragDelta = null;
			dragForce = null;
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
			if(dragInput != null)
			{
				DragData data = dragInput.dragData;
				
				if(isDrag != null)
					isDrag.Value = data.isDrag;

				if(dragDelta != null)
					dragDelta.Value = data.delta;

				if(dragForce != null)
					dragForce.Value = data.force;
			}
		}
	}
}
