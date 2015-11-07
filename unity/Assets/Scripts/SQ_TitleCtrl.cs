using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
/// タイトルシーケンス
/// </sammary>
///--------------------------------
public class SQ_TitleCtrl : MonoBehaviour {

	enum MODE
	{
		NONE,
		
		TITLE_UI_CREATE,
		
		TITLE_OPEN_INIT,
		TITLE_OPEN_LOOP,
		
		TITLE_CLOSE_INIT,
		TITLE_CLOSE_LOOP,
		
		CLOSE	
	};
	MODE m_Mode = MODE.NONE;
	
	private TitleUICtrl m_TitleUICtrl;
	
	public void Init()
	{
		ModeChange( MODE.TITLE_UI_CREATE );
	}
	
	void Update()
	{
		GameObject add_Object;
		
		switch ( m_Mode )
		{
			case MODE.TITLE_UI_CREATE:
			
				add_Object = Instantiate( Resources.Load( "Title/TitleUIPrefab" ) as GameObject );
				m_TitleUICtrl = add_Object.GetComponent<TitleUICtrl>();
				m_TitleUICtrl.Init();
				
				StaticAccess.m_MainCanvasCtrl.AddUI( add_Object.GetComponent<RectTransform>() );
				
				ModeChange( MODE.TITLE_OPEN_INIT );
				
				break;
				
			case MODE.TITLE_OPEN_INIT:
			
				m_TitleUICtrl.OpenRq();
				
				ModeChange( MODE.TITLE_OPEN_LOOP );
				
				break;
				
			case MODE.TITLE_OPEN_LOOP:
			
				if( !m_TitleUICtrl.IsOpen() )
				{
					break;
				}
				
				break;
		}
	}
	
	private void ModeChange( MODE mode )
	{
		m_Mode = mode;
	}
}
