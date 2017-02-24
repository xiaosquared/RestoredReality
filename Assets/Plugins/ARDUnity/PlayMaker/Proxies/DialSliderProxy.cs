using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/DialSliderProxy")]
    public class DialSliderProxy : ArdunityProxy
    {
        public readonly string builtInOnDragStart = "DIALSLIDER / ON DRAG START";
        public readonly string builtInOnDragEnd = "DIALSLIDER / ON DRAG END";

        public string eventOnDragStart = "DIALSLIDER / ON DRAG START";
        public string eventOnDragEnd = "DIALSLIDER / ON DRAG END";

        private DialSlider _dialSlider;
        
        protected override void Awake()
        {
            base.Awake();
            
            _dialSlider = GetComponent<DialSlider>();
            if (_dialSlider != null)
            {
                _dialSlider.OnDragStart.AddListener(OnDragStart);
				_dialSlider.OnDragEnd.AddListener(OnDragEnd);
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
        
        private void OnDragStart()
		{
            CallEvent(eventOnDragStart);
		}

		private void OnDragEnd()
		{
            CallEvent(eventOnDragEnd);
		}
    }
}

