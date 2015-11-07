using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///--------------------------------
/// <sammary>
/// UI表示メインキャンバス
/// </sammary>
///--------------------------------
public class MainCanvasCtrl : MonoBehaviour {
	
	[SerializeField]
	private RectTransform m_UIRectTransform;

	///--------------------------------
	/// <sammary>
	/// 初期化
	/// </sammary>
	///--------------------------------
	void Awake()
	{
		StaticAccess.m_MainCanvasCtrl = this;
	}
	
	public void AddUI( RectTransform t )
	{
		t.SetParent( m_UIRectTransform, false );
	}
	
}
