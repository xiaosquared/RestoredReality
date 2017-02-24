using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/ArdunityAppProxy")]
    [HelpURL("https://sites.google.com/site/ardunitydoc/references/ardunityapp/ardunityapp-playmaker")]
    public class ArdunityAppProxy : ArdunityProxy
    {
        public readonly string builtInOnConnected = "ARDUNITY APP / ON CONNECTED";
        public readonly string builtInOnConnectionFailed = "ARDUNITY APP / ON CONNECTION FAILED";
        public readonly string builtInOnDisconnected = "ARDUNITY APP / ON DISCONNECTED";
        public readonly string builtInOnLostConnection = "ARDUNITY APP / ON LOST CONNECTION";

        public string eventOnConnected = "ARDUNITY APP / ON CONNECTED";
        public string eventOnConnectionFailed = "ARDUNITY APP / ON CONNECTION FAILED";
        public string eventOnDisconnected = "ARDUNITY APP / ON DISCONNECTED";
        public string eventOnLostConnection = "ARDUNITY APP / ON LOST CONNECTION";
        
        private ArdunityApp _ardunityApp;
        
        protected override void Awake()
        {
            base.Awake();
            
            _ardunityApp = GetComponent<ArdunityApp>();
            if (_ardunityApp != null)
            {
                _ardunityApp.OnConnected.AddListener(OnConnected);
                _ardunityApp.OnConnectionFailed.AddListener(OnConnectionFailed);
                _ardunityApp.OnDisconnected.AddListener(OnDisconnected);
                _ardunityApp.OnLostConnection.AddListener(OnLostConnection);
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
        
        private void OnConnected()
		{
            CallEvent(eventOnConnected);
		}

		private void OnConnectionFailed()
		{
            CallEvent(eventOnConnectionFailed);
		}

		private void OnDisconnected()
		{
            CallEvent(eventOnDisconnected);
		}

        private void OnLostConnection()
        {
            CallEvent(eventOnLostConnection);
        }
    }
}

