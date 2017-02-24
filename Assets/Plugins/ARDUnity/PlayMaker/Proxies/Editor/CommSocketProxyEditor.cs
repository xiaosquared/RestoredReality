using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(CommSocketProxy))]
public class CommSocketProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/CommSocketProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<CommSocket>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/CommSocketProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<CommSocketProxy>();
    }
    
    SerializedProperty commSocket;
    
    void OnEnable()
	{
        commSocket = serializedObject.FindProperty("commSocket");
	}
    
	public override void OnInspectorGUI()
	{
        this.serializedObject.Update();
        
        CommSocketProxy proxy = (CommSocketProxy)target;
        
        EditorGUILayout.PropertyField(commSocket, new GUIContent("commSocket"));
		if(proxy.commSocket == null)
		{
			EditorGUILayout.HelpBox("There is no CommSocket!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnOpen = ProxyEditorUtility.EventField(target, "OnOpen", proxy.eventOnOpen, proxy.builtInOnOpen);
			proxy.eventOnClose = ProxyEditorUtility.EventField(target, "OnClose", proxy.eventOnClose, proxy.builtInOnClose);
			proxy.eventOnOpenFailed = ProxyEditorUtility.EventField(target, "OnOpenFailed", proxy.eventOnOpenFailed, proxy.builtInOnOpenFailed);
            proxy.eventOnErrorClosed = ProxyEditorUtility.EventField(target, "OnErrorClosed", proxy.eventOnErrorClosed, proxy.builtInOnErrorClosed);
            proxy.eventOnStartSearch = ProxyEditorUtility.EventField(target, "OnStartSearch", proxy.eventOnStartSearch, proxy.builtInOnStartSearch);
            proxy.eventOnStopSearch = ProxyEditorUtility.EventField(target, "OnStopSearch", proxy.eventOnStopSearch, proxy.builtInOnStopSearch);
        }
        
        this.serializedObject.ApplyModifiedProperties();
	}
}
