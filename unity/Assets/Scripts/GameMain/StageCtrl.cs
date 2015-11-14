using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///--------------------------------
/// <sammary>
/// ステージ制御
/// </sammary>
///--------------------------------
public class StageCtrl : MonoBehaviour {

	private int m_StageBlockLength = 10;

	private List<GameObject> m_StageBlockList = new List<GameObject>();

	public void Init()
	{
		GameObject stageBlock;
		for (int i = 0; i < m_StageBlockLength; i++)
		{
			stageBlock = Instantiate( Resources.Load( "GameMain/StageBlockPrefab" ) as GameObject );
			stageBlock.transform.position = new Vector3( stageBlock.transform.localScale.x * i, 0.0f, 0.0f );

			m_StageBlockList.Add( stageBlock );
		}
	}

	///--------------------------------
	// 解放
	///--------------------------------
	private void ReleaseAllObjectsAndCtrls()
	{
		for (int i = 0; i < m_StageBlockList.Count; i++)
		{
			Destroy( m_StageBlockList[i] );
		}
		m_StageBlockList.Clear ();
		
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

	public float GetStartPosition()
	{
		return m_StageBlockList[ 0 ].transform.position.x;
	}

	public float GetEndPosition()
	{
		return m_StageBlockList[ m_StageBlockList.Count - 1 ].transform.position.x;
	}
}
