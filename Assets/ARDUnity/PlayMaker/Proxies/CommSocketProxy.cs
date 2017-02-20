using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/CommSocketProxy")]
    public class CommSocketProxy : ArdunityProxy
    {
        public readonly string builtInOnOpen = "COMM SOCKET / ON OPEN";
        public readonly string builtInOnClose = "COMM SOCKET / ON CLOSE";
        public readonly string builtInOnOpenFailed = "COMM SOCKET / ON OPEN FAILED";
        public readonly string builtInOnErrorClosed = "COMM SOCKET / ON ERROR CLOSED";
        public readonly string builtInOnStartSearch = "COMM SOCKET / ON START SEARCH";
        public readonly string builtInOnStopSearch = "COMM SOCKET / ON STOP SEARCH";

        public string eventOnOpen = "COMM SOCKET / ON OPEN";
        public string eventOnClose = "COMM SOCKET / ON CLOSE";
        public string eventOnOpenFailed = "COMM SOCKET / ON OPEN FAILED";
        public string eventOnErrorClosed = "COMM SOCKET / ON ERROR CLOSED";
        public string eventOnStartSearch = "COMM SOCKET / ON START SEARCH";
        public string eventOnStopSearch = "COMM SOCKET / ON STOP SEARCH";
        
        public CommSocket commSocket;
        
        protected override void Awake()
        {
            base.Awake();
            
            if (commSocket != null)
            {
                commSocket.OnOpen.AddListener(OnOpen);
                commSocket.OnClose.AddListener(OnClose);
                commSocket.OnOpenFailed.AddListener(OnOpenFailed);
                commSocket.OnErrorClosed.AddListener(OnErrorClosed);
                commSocket.OnStartSearch.AddListener(OnStartSearch);
                commSocket.OnStopSearch.AddListener(OnStopSearch);
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
        
        private void OnOpen()
		{
            CallEvent(eventOnOpen);
		}

		private void OnClose()
		{
            CallEvent(eventOnClose);
		}

		private void OnOpenFailed()
		{
            CallEvent(eventOnOpenFailed);
		}

        private void OnErrorClosed()
        {
            CallEvent(eventOnErrorClosed);
        }
        
        private void OnStartSearch()
        {
            CallEvent(eventOnStartSearch);
        }
        
        private void OnStopSearch()
        {
            CallEvent(eventOnStopSearch);
        }
    }
}

