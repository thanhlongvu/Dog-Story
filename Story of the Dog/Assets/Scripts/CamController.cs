using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour {

	public GameObject player;

	public Transform headPoint;
	public Transform endPoint;
	// Use this for initialization

	[Header("Cinemachine")]
	public float time;
	public float maxOrth = 9f;
	public float minOrth = 6.75f;

	private CinemachineVirtualCamera cinemachineCam;
	void Start () {
		cinemachineCam = GetComponent<CinemachineVirtualCamera>();
	}
	
	void Update () {
		if(player.transform.position.x > headPoint.position.x && player.transform.position.x < endPoint.position.x)
		{
			if(cinemachineCam.m_Lens.OrthographicSize + 0.1f >= maxOrth)
				return;

			if(cinemachineCam.m_Lens.OrthographicSize != maxOrth)
			{
				cinemachineCam.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineCam.m_Lens.OrthographicSize, maxOrth, time * Time.deltaTime);			
			}
				
		}
		else
		{
			if(cinemachineCam.m_Lens.OrthographicSize - 0.1f <= minOrth)
				return;
				
			if(cinemachineCam.m_Lens.OrthographicSize != minOrth)
			{
				cinemachineCam.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineCam.m_Lens.OrthographicSize, minOrth, time * Time.deltaTime);
			}
		}
	}
}
