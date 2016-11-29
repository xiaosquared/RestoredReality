using UnityEngine;
using System.Collections;
using System;
using Ardunity;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ARDUnity")]
	[Tooltip("RTTTLSong.Play()")]
	public class RTTTLSongPlay : FsmStateAction
	{
		[RequiredField]
		public RTTTLSong rtttlSong;
		public FsmInt index;
		public FsmString name;

		public override void Reset()
		{
            rtttlSong = null;
            // default axis to variable dropdown with None selected.
			index = new FsmInt { UseVariable = true };
			name = new FsmString { UseVariable = true };
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(rtttlSong != null)
			{
				if(!index.IsNone)
					rtttlSong.SelectSong(index.Value);
                else if(!name.IsNone)
					rtttlSong.SelectSong(name.Value);

				rtttlSong.Play();
			}
			
			Finish();
		}
	}
}
