using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		// Prevent cursor from moving to avoid flickering
		//Cursor.lockState = CursorLockMode.Locked;
		// Hide the cursor
		Cursor.visible = false;
	}
}