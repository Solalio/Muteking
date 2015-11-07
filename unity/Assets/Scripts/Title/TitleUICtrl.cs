using UnityEngine;
using System.Collections;

public class TitleUICtrl : MonoBehaviour {

	private Animator m_Animator;
	
	private bool m_OpenRq	= false;
	private bool m_CloseRq	= false;
	
	public void Init()
	{
		m_Animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		if( m_OpenRq )
		{
			if( IsClose() )
			{
				Open();
			}
			m_OpenRq = false;
		}
		
		if( m_CloseRq )
		{
			if( IsOpen() )
			{
				Close();
			}
			m_CloseRq = false;
		}
	}
	
	public void OpenRq()
	{
		m_OpenRq = true;
	}
	
	public void CloseRq()
	{
		m_CloseRq = true;
	}
	
	public bool IsOpen()
	{
		AnimatorStateInfo stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
		
		if( stateInfo.nameHash ==  Animator.StringToHash("Base Layer.OpenLoop") )
		{
			return true;
		}
		return false;
	}
	
	public bool IsClose()
	{
		AnimatorStateInfo stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
		
		if( stateInfo.nameHash ==  Animator.StringToHash("Base Layer.CloseLoop") )
		{
			return true;
		}
		return false;
	}
	
	private void Open()
	{
		m_Animator.SetTrigger( "Open" );
	}
	
	private void Close()
	{
		m_Animator.SetTrigger( "Close" );
	}
}
