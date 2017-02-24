using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/DragInputProxy")]
    public class DragInputProxy : ArdunityProxy
    {
        public readonly string builtInOnDragStart = "DRAG INPUT / ON DRAG START";
        public readonly string builtInOnDragEnd = "DRAG INPUT / ON DRAG END";

        public string eventOnDragStart = "DRAG INPUT / ON DRAG START";
        public string eventOnDragEnd = "DRAG INPUT / ON DRAG END";
        
        private DragInput _dragInput;
        
        protected override void Awake()
        {
            base.Awake();
            
			_dragInput = GetComponent<DragInput>();
            if (_dragInput != null)
            {
                _dragInput.OnDragStart.AddListener(OnDragStart);
                _dragInput.OnDragEnd.AddListener(OnDragEnd);
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

