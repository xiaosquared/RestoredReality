using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(DragInputProxy))]
public class DragInputProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/DragInputProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<DragInput>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/DragInputProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<DragInputProxy>();
    }
 
    
	public override void OnInspectorGUI()
	{
        DragInputProxy proxy = (DragInputProxy)target;
        
        if(proxy.GetComponent<DragInput>() == null)
		{
			EditorGUILayout.HelpBox("There is no DragInput!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnDragStart = ProxyEditorUtility.EventField(target, "OnDragStart", proxy.eventOnDragStart, proxy.builtInOnDragStart);
			proxy.eventOnDragEnd = ProxyEditorUtility.EventField(target, "OnDragEnd", proxy.eventOnDragEnd, proxy.builtInOnDragEnd);
        }
	}
}
