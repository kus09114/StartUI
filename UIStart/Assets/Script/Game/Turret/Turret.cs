using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] GameObject m_Head;
	[SerializeField] GameObject m_Target;
	[SerializeField] GameObject m_Bullet;
	[SerializeField] Transform m_FirePos;
	[SerializeField] Transform m_FireParent;

	[SerializeField] float m_fDelayTime = 0;
	[SerializeField] float m_fBulletSpeed;

	public Vector3 m_vDir;

	float m_fTime = 0;

    void Start()
    {
		Initialize();
    }

	void Initialize()
	{

	}

	void Update()
	{
		FollowTarget();
		Fire();
	}

	void FollowTarget()
	{
		m_Head.transform.LookAt(m_Target.transform);

		//m_vDir = m_Target.transform.position - m_Head.transform.position;
		//m_Head.transform.rotation = Quaternion.LookRotation(m_vDir);
	}

	void Fire()
	{
		m_fTime += Time.deltaTime;
		if(m_fTime > m_fDelayTime)
		{
			m_fTime = 0;
			GameObject go = Instantiate(m_Bullet, m_FireParent);
			go.transform.position = m_FirePos.position;
			Bullet kBullet = go.GetComponent<Bullet>();

			kBullet.Initialize(m_Target.transform.position, m_fBulletSpeed);
		}
	}
}
