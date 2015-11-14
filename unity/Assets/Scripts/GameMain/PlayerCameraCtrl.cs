using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
/// プレイヤーカメラ制御
/// </sammary>
///--------------------------------
public class PlayerCameraCtrl : MonoBehaviour {

	Camera m_PlayerCamera;

	Transform m_TargetTransform;

	float m_ChaseRimitMin;
	float m_ChaseRimitMax;

	public void Init()
	{
		m_PlayerCamera = GetComponent<Camera> ();
	}

	public void SetTargetTransform( Transform t )
	{
		m_TargetTransform = t;
	}

	public void SetChaseRimitPosition( float xMin, float xMax )
	{
		m_ChaseRimitMin = xMin;
		m_ChaseRimitMax = xMax;
	}

	public void ChaseTarget()
	{
		if( m_TargetTransform.position.x <= m_ChaseRimitMin || m_TargetTransform.position.x >= m_ChaseRimitMax )
		{
			transform.parent = null;
			return;
		}
		
		float h = Input.GetAxis( "Horizontal" );

		Vector3 targetPosition = m_PlayerCamera.WorldToScreenPoint( m_TargetTransform.position );

		if( targetPosition.x < Screen.width * 0.25f && h < 0 )
		{
			transform.SetParent( m_TargetTransform );
		}
		else if( targetPosition.x > Screen.width * 0.75f && h > 0 )
		{
			transform.SetParent( m_TargetTransform );
		}
		else
		{
			transform.parent = null;
		}
	}

}
