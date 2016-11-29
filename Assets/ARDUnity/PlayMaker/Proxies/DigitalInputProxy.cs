using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/DigitalInputProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/controller/digitalinput/digitalinput-playmaker")]
    public class DigitalInputProxy : ArdunityProxy
    {
        public readonly string builtInOnTrue = "DIGITAL INPUT / ON TRUE";
        public readonly string builtInOnFalse = "DIGITAL INPUT / ON FALSE";

        public string eventOnTrue = "DIGITAL INPUT / ON TRUE";
        public string eventOnFalse = "DIGITAL INPUT / ON FALSE";

        private DigitalInput _digitalInput;
        
        protected override void Awake()
        {
            base.Awake();
            
            _digitalInput = GetComponent<DigitalInput>();
            if (_digitalInput != null)
            {
                _digitalInput.OnValueChanged.AddListener(OnValueChanged);
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
        
        private void OnValueChanged(bool value)
		{
            if(value)
                CallEvent(eventOnTrue);
            else
                CallEvent(eventOnFalse);
		}
    }
}

