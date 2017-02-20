using UnityEngine;
using HutongGames.PlayMaker;


namespace Ardunity.PlayMaker
{
    [AddComponentMenu("ARDUnity/PlayMaker/ArdunityProxy")]
    public class ArdunityProxy : MonoBehaviour
    {        
        public GameObject eventTarget;
        public PlayMakerFSM targetFSM;
        
        private PlayMakerFSM _fsm;
        private FsmEventTarget _fsmEventTarget;
        
        protected virtual void Awake()
        {
            _fsm = FindObjectOfType<PlayMakerFSM>();
            if (_fsm != null)
            {
                _fsmEventTarget = new FsmEventTarget();
                if(eventTarget == null)
                {
                    _fsmEventTarget.target = FsmEventTarget.EventTarget.BroadcastAll;
                    _fsmEventTarget.excludeSelf = false;
                }
                else
                {
                    if(targetFSM == null)
                    {
                        _fsmEventTarget.target = FsmEventTarget.EventTarget.GameObject;
                        FsmOwnerDefault owner = new FsmOwnerDefault();
                        owner.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
                        owner.GameObject = new FsmGameObject();
                        owner.GameObject.Value = eventTarget;
                        _fsmEventTarget.gameObject = owner;
                    }
                    else
                    {
                        _fsmEventTarget.target = FsmEventTarget.EventTarget.FSMComponent;
                        _fsmEventTarget.fsmComponent = targetFSM;
                    }
                }
            }
        }

        protected void CallEvent(string eventName)
        {
            if(_fsm != null)
                _fsm.Fsm.Event(_fsmEventTarget, eventName);
        }
    }
}

