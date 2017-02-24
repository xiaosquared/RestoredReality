using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(TriggerInputProxy))]
public class TriggerInputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/TriggerInputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<TriggerInput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/TriggerInputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<TriggerInputProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        TriggerInputProxy proxy = (TriggerInputProxy)target;

		if(proxy.GetComponent<TriggerInput>() == null)
		{
			EditorGUILayout.HelpBox("There is no TriggerInput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnTrigger = ProxyEditorUtility.EventField(target, "OnTrigger", proxy.eventOnTrigger, proxy.builtInOnTrigger);
        }
	}
}
