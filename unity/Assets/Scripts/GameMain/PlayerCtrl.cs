using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
// プレイヤー制御
/// </sammary>
///--------------------------------
public class PlayerCtrl : MonoBehaviour {

	[SerializeField]
	private float GRAVITY = 0.981f;
	[SerializeField]
	private float MOVE_SPEED = 5.0f;
	[SerializeField]
	private float JUMP_SPEED = 5.0f;

	private CharacterController m_CharacterController;

	private Vector3 m_Velocity;
	private float m_jumpTime;

	public void Init()
	{
		m_CharacterController = GetComponent<CharacterController> ();

		m_jumpTime = 0.0f;
	}

	// Update is called once per frame
	public void MovePlayer () {

		if ( m_CharacterController.isGrounded )
		{
			float h = Input.GetAxis( "Horizontal" );
			m_jumpTime = 0.0f;
			
			m_Velocity = new Vector3 (h, 0, 0);
			m_Velocity = transform.TransformDirection ( m_Velocity );
			m_Velocity *= MOVE_SPEED;

			if( Input.GetButtonDown( "Jump" ) )
			{
				m_Velocity.y = JUMP_SPEED;
			}
		}
		else
		{
			m_jumpTime += Time.fixedDeltaTime;
		}

		m_Velocity.y -= GRAVITY * m_jumpTime;
		m_CharacterController.Move ( m_Velocity * Time.fixedDeltaTime );
	
	}
}
