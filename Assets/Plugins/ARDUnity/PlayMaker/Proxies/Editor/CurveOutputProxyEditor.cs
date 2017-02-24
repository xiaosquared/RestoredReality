using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(CurveOutputProxy))]
public class CurveOutputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/CurveOutputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<CurveOutput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/CurveOutputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<CurveOutputProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        CurveOutputProxy proxy = (CurveOutputProxy)target;

		if(proxy.GetComponent<CurveOutput>() == null)
		{
			EditorGUILayout.HelpBox("There is no CurveOutput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnStart = ProxyEditorUtility.EventField(target, "OnStart", proxy.eventOnStart, proxy.builtInOnStart);
			proxy.eventOnStop = ProxyEditorUtility.EventField(target, "OnStop", proxy.eventOnStop, proxy.builtInOnStop);
        }
	}
}
