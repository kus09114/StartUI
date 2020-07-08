using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float m_fTime = 0;
	float m_Speed;

	Vector3 m_vDir;

    void Start()
    {
        
    }

	public void Initialize(Vector3 target, float speed)
	{
		m_vDir = target - transform.position;
		m_vDir.Normalize();
		m_Speed = speed;
	}

	void Update()
    {
		Move();

		m_fTime += Time.deltaTime;
		if(m_fTime > 5)
		{
			Destroy(this.gameObject);
		}
    }

	void Move()
	{
		transform.Translate(m_vDir * m_Speed);
	}
}
