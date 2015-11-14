using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
/// ゲームメインシーケンス
/// </sammary>
///--------------------------------
public class SQ_MainCtrl : MonoBehaviour {
	
	///--------------------------------
	// シーケンスモード
	///--------------------------------
	public enum MODE
	{
		NONE,
		
		START,
		
		TITLE_INIT,
		TITLE_LOOP,

		GAME_MAIN_INIT,
		GAME_MAIN_LOOP,
		
		END	
	};
	public MODE m_Mode = MODE.NONE;
	
	///--------------------------------
	// メンバー
	///--------------------------------

	private SQ_TitleCtrl m_SQ_TitleCtrl;

	private SQ_GameMainCtrl m_SQ_GameMainCtrl;
	
	///--------------------------------
	// 初期化
	///--------------------------------
	void Awake()
	{
		m_Mode = MODE.START;
	}
	
	///--------------------------------
	// 解放
	///--------------------------------
	private void ReleaseAllObjectsAndCtrls()
	{
		if ( m_SQ_TitleCtrl != null)
		{
			Destroy( m_SQ_TitleCtrl.gameObject );
			m_SQ_TitleCtrl = null;
		}
		
		if ( m_SQ_GameMainCtrl != null )
		{
			Destroy( m_SQ_GameMainCtrl.gameObject );
			m_SQ_GameMainCtrl = null;
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
	
	///--------------------------------
	// 更新
	///--------------------------------
	void Update()
	{
		GameObject add_Object;
		
		switch ( m_Mode )
		{
			case MODE.START:
				
				ModeChange( MODE.TITLE_INIT );
				break;
				
			case MODE.TITLE_INIT:
			
				add_Object = Instantiate( Resources.Load( "SQ_TitleCtrlPrefab" ) as GameObject ) ;
				m_SQ_TitleCtrl = add_Object.GetComponent<SQ_TitleCtrl>();
				m_SQ_TitleCtrl.Init();

				ModeChange( MODE.TITLE_LOOP );
				
				break;
			
			case MODE.TITLE_LOOP:

				if( !m_SQ_TitleCtrl.IsClose() )
				{
					break;
				}

				ReleaseAllObjectsAndCtrls();
			
				ModeChange( MODE.GAME_MAIN_INIT );

				break;

		case MODE.GAME_MAIN_INIT:

			add_Object = Instantiate( Resources.Load( "SQ_GameMainCtrlPrefab" ) as GameObject );
			m_SQ_GameMainCtrl = add_Object.GetComponent<SQ_GameMainCtrl>();
			m_SQ_GameMainCtrl.Init();

			ModeChange( MODE.GAME_MAIN_LOOP );

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
}
