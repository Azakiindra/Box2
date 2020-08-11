using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallObstacle : MonoBehaviour {

	[SerializeField]
	private float time = 0, MaxTime = 0, Height = 0;
	public GameObject Obstacle;
	void Update () {

		if (time > MaxTime)
		{

			GameObject NewObstacle = Instantiate(Obstacle);
			NewObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-Height, Height), 0);
			Destroy(NewObstacle, 6);
			time = 0;

		}	

		time += Time.deltaTime;

	}
}
