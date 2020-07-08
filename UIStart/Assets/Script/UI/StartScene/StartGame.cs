using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	[SerializeField] GameObject m_StartPanel = null;
	[SerializeField] GameObject m_CountdownPanel = null;
	[SerializeField] Button m_btnStart = null;			// 시작 버튼
	[SerializeField] Text m_txtCountdown = null;       // 카운트다운 텍스트
	[SerializeField] Text m_txtSubCountdown = null;       // 카운트다운 텍스트

	[SerializeField] Vector3 m_StartSize = Vector3.zero;
	[SerializeField] Vector3 m_EndSize = Vector3.zero;

	bool m_bStart = false;
	int m_nCountdownTime = 4;
	float m_nTime = 1;
	float m_nSizeTime = 0;

    void Start()
    {
		Initialize();
	}

	void Initialize()
	{
		m_btnStart.onClick.AddListener(OnClick_StartButton);
		m_txtCountdown.gameObject.transform.localScale = m_StartSize;
		m_txtSubCountdown.gameObject.transform.localScale = m_StartSize;
	}

    void Update()
    {
		Update_Countdown();
		Update_Size();
	}

	void OnClick_StartButton()
	{
		m_StartPanel.SetActive(false);
		m_CountdownPanel.SetActive(true);
		m_bStart = true;
	}

	void Update_Countdown()
	{
		if(m_bStart)
		{
			m_nTime += Time.deltaTime;
			if (m_nTime >= 1)
			{
				m_nTime = 0;
				m_nCountdownTime -= 1;
				if (m_nCountdownTime <= 0)
				{
					string start = "Start";
					m_txtCountdown.text = start;
					m_txtSubCountdown.text = start;
				}
				else
				{
					m_txtCountdown.text = m_nCountdownTime.ToString();
					m_txtSubCountdown.text = m_nCountdownTime.ToString();
				}
			}
		}
	}
	void Update_Size()
	{
		if (m_nCountdownTime < 0)
		{
			m_txtCountdown.gameObject.SetActive(false);
			m_txtSubCountdown.gameObject.SetActive(false);
		}
		if (m_bStart && m_nCountdownTime > -1)
		{
			m_nSizeTime += Time.deltaTime;
			if(m_nSizeTime > 0.2f)
			{
				m_txtCountdown.gameObject.transform.localScale = m_EndSize;
				m_txtSubCountdown.gameObject.transform.localScale = m_EndSize;
			}
			if (m_nSizeTime >= 1)
			{
				m_txtCountdown.gameObject.transform.localScale = m_StartSize;
				m_txtSubCountdown.gameObject.transform.localScale = m_StartSize;
				m_nSizeTime = 0;
			}
		}
	}
}