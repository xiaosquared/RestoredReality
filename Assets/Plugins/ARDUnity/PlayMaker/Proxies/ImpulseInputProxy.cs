using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/ImpulseInputProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/bridge/impulseinput/impulseinput-playmaker")]
    public class ImpulseInputProxy : ArdunityProxy
    {
        public readonly string builtInOnImpulse = "IMPULSE INPUT / ON IMPULSE";

        public string eventOnImpulse = "IMPULSE INPUT / ON IMPULSE";

        private ImpulseInput _impulseInput;
        
        protected override void Awake()
        {
            base.Awake();
            
            _impulseInput = GetComponent<ImpulseInput>();
            if (_impulseInput != null)
            {
                _impulseInput.OnTriggerShot.AddListener(OnImpulse);
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
        
        private void OnImpulse()
		{
            CallEvent(eventOnImpulse);
		}
    }
}