 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {

	public Rigidbody rb;
	[SerializeField]
	private float Distracejump = 0, MaxJump = 0, a = 0;

	private void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "ObstacleBox")
		{
			
			GetComponent<Animator>().SetBool("Condition", true);

		}

	}
	private void OnCollisionEnter(Collision other) {

		if (other.gameObject.name == "Ground")
		{

			MaxJump = 0;
			
		}

	}
	public void OnPlayerClick(){

		if (MaxJump == 0)
		{
			
			rb.velocity = Vector3.up * Distracejump;			
			MaxJump ++;

		}
		else if (MaxJump == 1)
		{

			if (Distracejump > 0)
			{
				rb.velocity = Vector3.up * (Distracejump - a);
			}	
			else if (Distracejump < 0)
			{
				rb.velocity = Vector3.up * (Distracejump + a);
			}	
			MaxJump ++;

		}

	}

	public void OnBoxHit(){

		GetComponent<Animator>().SetBool("Condition", false);

	}
}
