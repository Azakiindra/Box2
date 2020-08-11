using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed, StartWaitTime;
	private float WaitTime;
	public Transform[] moveSpots;
	private int randomSpot;
	void Start() {
		WaitTime = StartWaitTime;
		randomSpot = Random.Range(0, moveSpots.Length);
		for (int i = 0; i < moveSpots.Length; i++)
		{
			
			moveSpots[i] = GameObject.Find("Spot ("+ (i+1) + ")").transform;

		}

	}
	void Update(){

		MyBox();

	}

	private void MyBox(){

		transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

		if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
			//random dari npc
			if(WaitTime <= 0) {
				randomSpot = Random.Range(0, moveSpots.Length);
				WaitTime = StartWaitTime;
				//Debug.Log(gameObject.transform.rotation);
				//Debug.Log(randomSpot);
			}
			else{
				WaitTime -= Time.deltaTime;
			}

			//perbaikan scale dari npc

		}

	}

}
