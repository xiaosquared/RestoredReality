using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Ardunity.PlayMaker;


public class ProxyEditorUtility
{
    public static void EventTargetField(ArdunityProxy proxy)
	{
		proxy.eventTarget = (GameObject)EditorGUILayout.ObjectField("eventTarget", proxy.eventTarget, typeof(GameObject), true);
        if(proxy.eventTarget == null)
            proxy.targetFSM = null;
        else
        {
            PlayMakerFSM[] fsms = proxy.eventTarget.GetComponents<PlayMakerFSM>();
            if(fsms.Length > 0)
            {
                List<string> fsmNames = new List<string>();
                fsmNames.Add("Inclueded All FSM");
                for(int i=0; i<fsms.Length; i++)
                    fsmNames.Add(fsms[i].FsmName);
                    
                int selection = 0;
                if(proxy.targetFSM != null)
                {
                    for(int i=0; i<fsms.Length; i++)
                    {
                        if(proxy.targetFSM.Equals(fsms[i]))
                        {
                            selection = i + 1;
                            break;
                        }
                    }
                }
                
                selection = EditorGUILayout.Popup("Target FSM", selection, fsmNames.ToArray());
                if(selection > 0)
                    proxy.targetFSM = fsms[selection - 1];
                else
                    proxy.targetFSM = null;
            }
            else
            {
                EditorGUILayout.HelpBox("There is no FSM.", MessageType.Warning);
                proxy.targetFSM = null;
            }
        }
        if(proxy.eventTarget == null)
            EditorGUILayout.HelpBox("If eventTarget is null, it will be send to all PlayMaker FSM.", MessageType.Info);
	}
    
	public static string EventField(Object target, string eventName, string customEvent, string builtInEvent)
	{
		EditorGUILayout.LabelField(string.Format("Event: {0}", eventName));
		EditorGUI.indentLevel++;
		GUILayout.BeginHorizontal();
		customEvent = EditorGUILayout.TextField(customEvent);
		if(customEvent.Equals(builtInEvent) == false)
		{
            GUI.SetNextControlName("Reset");
			if(GUILayout.Button("Reset", GUILayout.Width(50f)) == true)
			{
				customEvent = builtInEvent;
                GUI.FocusControl("Reset");
				EditorUtility.SetDirty(target);
			}
		}
		GUILayout.EndHorizontal();
		EditorGUI.indentLevel--;
		
		return customEvent;
	}
}
