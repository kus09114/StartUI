using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_fMoveSpeed = 0;

    void Start()
    {
		Initialize();
	}

	void Initialize()
	{

	}

	void FixedUpdate()
	{
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		Vector3 pos = transform.position;

		pos.x += hor * Time.deltaTime * m_fMoveSpeed;
		pos.z += ver * Time.deltaTime * m_fMoveSpeed;

		transform.position = pos;
	}
}
