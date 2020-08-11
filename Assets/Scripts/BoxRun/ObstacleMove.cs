using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

	[SerializeField]
	private float Speed;
	void Update () {
		transform.position += Vector3.left * Speed * Time.deltaTime;
	}
}
