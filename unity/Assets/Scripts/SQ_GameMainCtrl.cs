using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
/// ゲームメインシーケンス
/// </sammary>
///--------------------------------
public class SQ_GameMainCtrl : MonoBehaviour {

	///--------------------------------
	// シーケンスモード
	///--------------------------------
	public enum MODE
	{
		NONE,
		
		START,
		
		LOAD_INIT,
		LOAD_LOOP,
		
		SCENE_OPEN_INIT,
		SCENE_OPEN_LOOP,
		
		INPUT_WAIT_INIT,
		INPUT_WAIT_LOOP,
		
		SCENE_CLOSE_INIT,
		SCENE_CLOSE_LOOP,
		
		CLOSE	
	};
	public MODE m_Mode = MODE.NONE;
	
	///--------------------------------
	// メンバー
	///--------------------------------

	private StageCtrl m_StageCtrl = null;

	private PlayerCameraCtrl m_PlayerCameraCtrl = null;

	private PlayerCtrl m_PlayerCtrl = null;
	
	private bool m_ClickLock = true;

	///--------------------------------
	// 初期化
	///--------------------------------
	public void Init()
	{
		ModeChange( MODE.START );
	}
	
	///--------------------------------
	// 解放
	///--------------------------------
	private void ReleaseAllObjectsAndCtrls()
	{
		if ( m_StageCtrl != null )
		{
			Destroy( m_StageCtrl.gameObject );
			m_StageCtrl = null;
		}

		if ( m_PlayerCameraCtrl != null )
		{
			Destroy( m_PlayerCameraCtrl.gameObject );
			m_PlayerCameraCtrl = null;
		}

		if( m_PlayerCtrl != null )
		{
			Destroy( m_PlayerCtrl.gameObject );
			m_PlayerCtrl = null;
		}

		System.GC.Collect ();
		
		Resources.UnloadUnusedAssets ();
	}
	
	///--------------------------------
	// 破棄
	///--------------------------------
	void OnDestroy()
	{
		ReleaseAllObjectsAndCtrls ();
	}

	void Update()
	{
		GameObject add_GameObject;

		switch (m_Mode)
		{
			case MODE.START:

				ReleaseAllObjectsAndCtrls();

				ModeChange( MODE.LOAD_INIT );

				break;

			case MODE.LOAD_INIT:

				add_GameObject = Instantiate( Resources.Load ( "GameMain/StageCtrlPrefab" ) as GameObject );
				m_StageCtrl = add_GameObject.GetComponent<StageCtrl>();
				m_StageCtrl.Init();

				add_GameObject = Instantiate( Resources.Load ( "GameMain/PlayerPrefab" ) as GameObject );
				m_PlayerCtrl = add_GameObject.GetComponent<PlayerCtrl>();
				m_PlayerCtrl.Init();
			
				add_GameObject = Instantiate( Resources.Load ( "GameMain/PlayerCameraPrefab" ) as GameObject );
				m_PlayerCameraCtrl = add_GameObject.GetComponent<PlayerCameraCtrl>();
				m_PlayerCameraCtrl.Init();

				ModeChange( MODE.LOAD_LOOP );

				break;

			case MODE.LOAD_LOOP:

				ModeChange( MODE.SCENE_OPEN_INIT );

				break;

			case MODE.SCENE_OPEN_INIT:
			
				m_PlayerCameraCtrl.SetTargetTransform( m_PlayerCtrl.gameObject.transform );
				m_PlayerCameraCtrl.SetChaseRimitPosition( m_StageCtrl.GetStartPosition(), m_StageCtrl.GetEndPosition() );
				
				ModeChange( MODE.SCENE_OPEN_LOOP );

				break;

			case MODE.SCENE_OPEN_LOOP:

				ModeChange( MODE.INPUT_WAIT_INIT );

				break;

			case MODE.INPUT_WAIT_INIT:

				m_ClickLock = false;

				ModeChange( MODE.INPUT_WAIT_LOOP );

				break;

			case MODE.INPUT_WAIT_LOOP:
			
				m_PlayerCameraCtrl.ChaseTarget();

				m_PlayerCtrl.MovePlayer();

				break;

			case MODE.SCENE_CLOSE_INIT:

				ModeChange( MODE.SCENE_CLOSE_LOOP );

				break;

			case MODE.SCENE_CLOSE_LOOP:

				ModeChange( MODE.CLOSE );

				break;

			case MODE.CLOSE:

				break;

		}
	}
	
	///--------------------------------
	// モード切り替え
	///--------------------------------
	private void ModeChange( MODE mode )
	{
		m_Mode = mode;
	}
	
	public bool IsClose()
	{
		if ( m_Mode == MODE.CLOSE )
		{
			return true;
		}
		
		return false;
	}
}
