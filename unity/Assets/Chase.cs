using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	GameObject Plyers;

	void Start () {
		Plyers = GameObject.FindWithTag ("Player").gameObject;
		transform.position = Plyers.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		Vector3 Ppos = Camera.main.WorldToScreenPoint(Plyers.transform.position);

		if(Ppos.x < Screen.width * 0.25f)
		{
			transform.parent = Plyers.transform;
			if(h > 0)
			{
				transform.parent = null;
			}
		}

		else if (Ppos.x > Screen.width * 0.75f)
		{
			transform.parent = Plyers.transform;
			if(h < 0)
			{
				transform.parent = null;
			}
		} else {
			transform.parent = null;
		}
		//transform.position = Plyers.transform.position;
	}
}
