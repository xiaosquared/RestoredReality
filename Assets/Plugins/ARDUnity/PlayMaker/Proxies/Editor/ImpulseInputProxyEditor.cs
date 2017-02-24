using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(ImpulseInputProxy))]
public class ImpulseInputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/ImpulseInputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<ImpulseInput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/ImpulseInputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<ImpulseInputProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        ImpulseInputProxy proxy = (ImpulseInputProxy)target;

		if(proxy.GetComponent<ImpulseInput>() == null)
		{
			EditorGUILayout.HelpBox("There is no ImpulseInput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnImpulse = ProxyEditorUtility.EventField(target, "OnImpulse", proxy.eventOnImpulse, proxy.builtInOnImpulse);
        }
	}
}
