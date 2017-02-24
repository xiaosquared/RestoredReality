using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/RTTTLSongProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/bridge/rtttlsong/rtttlsong-playmaker")]
    public class RTTTLSongProxy : ArdunityProxy
    {
        public readonly string builtInOnEnd = "RTTTL SONG / ON END";

        public string eventOnEnd = "RTTTL SONG / ON END";
  
        private RTTTLSong _rtttlSong;
        
        protected override void Awake()
        {
            base.Awake();
            
            _rtttlSong = GetComponent<RTTTLSong>();
            if (_rtttlSong != null)
            {
                _rtttlSong.OnEndSong.AddListener(OnEndSong);
            }
        }

        // Use this for initialization
        void Start ()
        {
        }
        
        // Update is called once per frame
        void Update ()
        {
        }
        
        private void OnEndSong()
		{
            CallEvent(eventOnEnd);
		}
    }
}

