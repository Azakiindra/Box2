using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		
		if(other.gameObject.name == "Player"){
			other.transform.parent = transform;

		}

	}

	private void OnCollisionExit(Collision other) {

		if(other.gameObject.name == "Player"){

			other.transform.parent = null;

		}

	}

}
