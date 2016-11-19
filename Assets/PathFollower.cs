using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

	
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawPath ()
    {   if (path.Length > 0)
        for (int i = 0; i < path.Length; i++)
       {     if (path[i] !=null)
            {

            }

        }
    }
}
