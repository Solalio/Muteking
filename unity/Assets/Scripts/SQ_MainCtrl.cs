using UnityEngine;
using System.Collections;

///--------------------------------
/// <sammary>
/// ゲームメインシーケンス
/// </sammary>
///--------------------------------
public class SQ_MainCtrl : MonoBehaviour {

	public enum MODE
	{
		NONE,
		
		START,
		
		TITLE_INIT,
		TITLE_LOOP,
		
		END	
	};
	public MODE m_Mode = MODE.NONE;
	
	void Awake()
	{
		m_Mode = MODE.START;
	}
	
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
				add_Object.GetComponent<SQ_TitleCtrl>().Init();
				
				ModeChange( MODE.TITLE_LOOP );
				
				break;
			
			case MODE.TITLE_LOOP:
				break;	
			
		}
	}
	
	private void ModeChange( MODE mode )
	{
		m_Mode = mode;
	}
}
