using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/ToggleInputProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/bridge/toggleinput/toggleinput-playmaker")]
    public class ToggleInputProxy : ArdunityProxy
    {
        public readonly string builtInOnTrue = "TOGGLE INPUT / ON TRUE";
        public readonly string builtInOnFalse = "TOGGLE INPUT / ON FALSE";

        public string eventOnTrue = "TOGGLE INPUT / ON TRUE";
        public string eventOnFalse = "TOGGLE INPUT / ON FALSE";

        private ToggleInput _toggleInput;
        
        protected override void Awake()
        {
            base.Awake();
            
            _toggleInput = GetComponent<ToggleInput>();
            if (_toggleInput != null)
            {
                _toggleInput.OnValueChanged.AddListener(OnValueChanged);
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

