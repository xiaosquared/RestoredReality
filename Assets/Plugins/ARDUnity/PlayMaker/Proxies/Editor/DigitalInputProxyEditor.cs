using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(DigitalInputProxy))]
public class DigitalInputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/DigitalInputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<DigitalInput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/DigitalInputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<DigitalInputProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        DigitalInputProxy proxy = (DigitalInputProxy)target;

		if(proxy.GetComponent<DigitalInput>() == null)
		{
			EditorGUILayout.HelpBox("There is no DigitalInput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnTrue = ProxyEditorUtility.EventField(target, "OnTrue", proxy.eventOnTrue, proxy.builtInOnTrue);
			proxy.eventOnFalse = ProxyEditorUtility.EventField(target, "OnFalse", proxy.eventOnFalse, proxy.builtInOnFalse);
        }
	}
}
