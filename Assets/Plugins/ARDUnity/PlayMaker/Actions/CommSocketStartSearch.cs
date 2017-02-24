using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("CommSocket.StartSearch()")]
	public class CommSocketStartSearch : FsmStateAction
	{
		[RequiredField]
		public CommSocket commSocket;

		public override void Reset()
		{
            commSocket = null;
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(commSocket != null)
                commSocket.StartSearch();
			
			Finish();
		}
	}
}
