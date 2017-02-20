using UnityEngine;
using UnityEditor;
using Ardunity;
using Ardunity.PlayMaker;


[CustomEditor(typeof(RTTTLSongProxy))]
public class RTTTLSongProxyEditor : Editor
{
    [MenuItem("ARDUnity/Add PlayMaker/RTTTLSongProxy", true)]
	static bool ValidateMenu()
	{
		if(Selection.activeGameObject == null)
			return false;
		
		if(Selection.activeGameObject.GetComponent<RTTTLSong>() == null)
			return false;
			
		return true;
	}
	[MenuItem("ARDUnity/Add PlayMaker/RTTTLSongProxy", false, 10)]
    static void DoMenu()
    {
        Selection.activeGameObject.AddComponent<RTTTLSongProxy>();
    }

    
	public override void OnInspectorGUI()
	{
        RTTTLSongProxy proxy = (RTTTLSongProxy)target;

		if(proxy.GetComponent<RTTTLSong>() == null)
		{
			EditorGUILayout.HelpBox("There is no RTTTLSong!", MessageType.Error);
		}
		else
		{
            ProxyEditorUtility.EventTargetField(proxy as ArdunityProxy);
			proxy.eventOnEnd = ProxyEditorUtility.EventField(target, "OnnEnd", proxy.eventOnEnd, proxy.builtInOnEnd);
        }
	}
}
