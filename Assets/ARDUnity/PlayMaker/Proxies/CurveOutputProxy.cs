using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/CurveOutputProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/bridge/curveoutput/curveoutput-playmaker")]
    public class CurveOutputProxy : ArdunityProxy
    {
        public readonly string builtInOnStart = "CURVE OUTPUT / ON START";
        public readonly string builtInOnStop = "CURVE OUTPUT / ON STOP";

        public string eventOnStart = "CURVE OUTPUT / ON START";
        public string eventOnStop = "CURVE OUTPUT / ON STOP";
  
        private CurveOutput _curveOutput;
        
        protected override void Awake()
        {
            base.Awake();
            
            _curveOutput = GetComponent<CurveOutput>();
            if (_curveOutput != null)
            {
                _curveOutput.OnStart.AddListener(OnStart);
                _curveOutput.OnStop.AddListener(OnStop);
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
        
        private void OnStart()
		{
            CallEvent(eventOnStart);
		}

		private void OnStop()
		{
            CallEvent(eventOnStop);
		}
    }
}

