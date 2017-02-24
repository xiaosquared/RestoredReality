using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("RTTTLSong.Stop()")]
	public class RTTTLSongStop : FsmStateAction
	{
		[RequiredField]
		public RTTTLSong rtttlSong;

		public override void Reset()
		{
            rtttlSong = null;
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(rtttlSong != null)
                rtttlSong.Stop();
			
			Finish();
		}
	}
}
