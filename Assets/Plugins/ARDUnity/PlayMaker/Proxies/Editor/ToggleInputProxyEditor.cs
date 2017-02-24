using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(ToggleInputProxy))]
public class ToggleInputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/ToggleInputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<ToggleInput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/ToggleInputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<ToggleInputProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        ToggleInputProxy proxy = (ToggleInputProxy)target;

		if(proxy.GetComponent<ToggleInput>() == null)
		{
			EditorGUILayout.HelpBox("There is no ToggleInput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnTrue = ProxyEditorUtility.EventField(target, "OnTrue", proxy.eventOnTrue, proxy.builtInOnTrue);
			proxy.eventOnFalse = ProxyEditorUtility.EventField(target, "OnFalse", proxy.eventOnFalse, proxy.builtInOnFalse);
        }
	}
}
