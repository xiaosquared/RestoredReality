using UnityEngine;
using System.Collections;

public class Demo3 : MonoBehaviour
{
	public GameObject[] m_Gos;
	private bool m_ToggleBump = false;

	void Start ()
	{
		Shader.DisableKeyword ("CRYSTAL_GLASS_BUMP");
	}
	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 250, 30), "Crystal Glass Demo");
		
		m_ToggleBump = GUI.Toggle (new Rect(10, 45, 120, 30), m_ToggleBump, "Bump Mapping");
		for (int i = 0; i < m_Gos.Length; i++)
		{
			Renderer rd = m_Gos[i].GetComponent<Renderer>();
			if (m_ToggleBump)
				rd.material.EnableKeyword ("CRYSTAL_GLASS_BUMP");
			else
				rd.material.DisableKeyword ("CRYSTAL_GLASS_BUMP");
		}
	}
}