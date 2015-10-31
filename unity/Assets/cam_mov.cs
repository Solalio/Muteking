using UnityEngine;
using System.Collections;

public class cam_mov : MonoBehaviour {

	public GameObject target;
	Vector3 camPos;

	void Start () {
		camPos = gameObject.transform.position;
	}

	void Update () {
		camPos.x = target.transform.position.x;
		gameObject.transform.position = camPos;
	}
}
