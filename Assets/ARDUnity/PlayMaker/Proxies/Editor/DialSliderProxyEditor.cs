using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(DialSliderProxy))]
public class DialSliderProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/DialSliderProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<DialSlider>() == null)
			return false;
		
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/DialSliderProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<DialSliderProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        DialSliderProxy proxy = (DialSliderProxy)target;

		if(proxy.GetComponent<DialSlider>() == null)
		{
			EditorGUILayout.HelpBox("There is no DialSlider!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnDragStart = ProxyEditorUtility.EventField(target, "OnDragStart", proxy.eventOnDragStart, proxy.builtInOnDragStart);
			proxy.eventOnDragEnd = ProxyEditorUtility.EventField(target, "OnDragEnd", proxy.eventOnDragEnd, proxy.builtInOnDragEnd);
        }
	}
}
