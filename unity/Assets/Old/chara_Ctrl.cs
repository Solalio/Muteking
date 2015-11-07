using UnityEngine;
using System.Collections;

public class chara_Ctrl : MonoBehaviour {

	CharacterController character;
	Vector3 velocity;
	public float Speed = 1; 
	public float timeSpan = 0.01f;
	public float jumpSpd = 6;
	float gravity = 9.81f;
	float t = 0;

	void Start () {
		character = GetComponent<CharacterController>();
		StartCoroutine ("mov");
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "deads")
		{
			Debug.Log ("Dead!!");
		}
		if(hit.gameObject.tag == "Finish")
		{
			Debug.Log ("GOALL!!");
		}
	}

	//void Update ()
	IEnumerator mov()
	{
		while (true)
		{
			if (character.isGrounded)
			{
				t = 0;
				//float v = Input.GetAxis("Vertical");
				float h = Input.GetAxis ("Horizontal");
				if (h > 0)
				{
					h = 1;
				}
				velocity = new Vector3 (h, 0, 0);
				velocity = transform.TransformDirection (velocity);
				velocity *= Speed;
				if(Input.GetButton("Jump"))
				{				
					velocity.y = jumpSpd;
				}
			}
			if (!character.isGrounded)
			{
					t += Time.deltaTime;
			}
			velocity.y -= gravity * t;
			character.Move (velocity * Time.deltaTime);
			yield return new WaitForSeconds(timeSpan);
		}
	}
}
