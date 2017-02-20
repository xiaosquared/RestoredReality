using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(ArdunityAppProxy))]
public class ArdunityAppProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/ArdunityAppProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<ArdunityApp>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/ArdunityAppProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<ArdunityAppProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        ArdunityAppProxy proxy = (ArdunityAppProxy)target;

		if(proxy.GetComponent<ArdunityApp>() == null)
		{
			EditorGUILayout.HelpBox("There is no ArdunityApp!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnConnected = ProxyEditorUtility.EventField(target, "OnConnected", proxy.eventOnConnected, proxy.builtInOnConnected);
			proxy.eventOnConnectionFailed = ProxyEditorUtility.EventField(target, "OnConnectionFailed", proxy.eventOnConnectionFailed, proxy.builtInOnConnectionFailed);
			proxy.eventOnDisconnected = ProxyEditorUtility.EventField(target, "OnDisonnected", proxy.eventOnDisconnected, proxy.builtInOnDisconnected);
            proxy.eventOnLostConnection = ProxyEditorUtility.EventField(target, "OnLostConnection", proxy.eventOnLostConnection, proxy.builtInOnLostConnection);
        }
	}
}
