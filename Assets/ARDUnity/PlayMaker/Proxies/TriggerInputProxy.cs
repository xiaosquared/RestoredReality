using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/TriggerInputProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/bridge/triggerinput/triggerinput-playmaker")]
    public class TriggerInputProxy : ArdunityProxy
    {
        public readonly string builtInOnTrigger = "TRIGGER INPUT / ON TRIGGER";

        public string eventOnTrigger = "TRIGGER INPUT / ON TRIGGER";

        private TriggerInput _triggerInput;
        
        protected override void Awake()
        {
            base.Awake();
            
            _triggerInput = GetComponent<TriggerInput>();
            if (_triggerInput != null)
            {
                _triggerInput.OnTrigger.AddListener(OnTrigger);
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
        
        private void OnTrigger()
		{
            CallEvent(eventOnTrigger);
		}
    }
}