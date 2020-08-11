using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	public Transform ValueB;
	public CinemachineFreeLook ValueX;
	public int a = 0, MaxJump=0;
	private bool ChangeMode = false;

	void Update() {

		//Debug.Log(this.transform.position);
		//Debug.Log("rotation :" + TransformUtils.GetInspectorRotation(gameObject.transform));
		//Debug.Log(cfc.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY);
		if (this.transform.position.y < -7)
		{
			ChangePosition();

		}
		
		PlayerControl();


	}

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.name == "Trigger")
			{
				SceneManager.LoadScene("BoxRun");
			}
		}
		private void OnCollisionStay(Collision other) {
			
			//if player goto elevator, player rotation freeze
			if (other.gameObject.tag == "Elevator")
			{
				MaxJump = 0;
				transform.eulerAngles = new Vector3(0f, 0f, 0f);
				speed = 1000f;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;	
			}
			//end
			if (other.gameObject.tag == "Grounds")
			{
				MaxJump = 0;
			}
			if (other.gameObject.name == "Finish")
			{
			
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

			}

		}
		private void OnCollisionEnter(Collision other) {

			//if player goto elevator, player rotation freeze
			if (other.gameObject.tag == "Elevator")
			{
				MaxJump = 0;
				transform.eulerAngles = new Vector3(0f, 0f, 0f);
				speed = 1000f;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;	
			}
			//end
			if (other.gameObject.name == "Finish")
			{
				
				GameObject.Find("Batang").GetComponent<Animator>().SetBool("Bendera", true);

			}
			if (other.gameObject.name == "Door")
			{
				
				GameObject.Find("Door").GetComponent<Animator>().SetBool("door1", true);

			}


		}
		private void ChangePosition(){

			this.gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(-5f, 5f), Random.Range(10f, 20f), Random.Range(6f, 8f));

		}

		private void PlayerControl(){
			float n,x,y;
			x = ValueB.transform.localPosition.x;
			y = ValueB.transform.localPosition.y;
			n = ValueX.m_XAxis.Value;

			if (Input.GetKey(KeyCode.E))
			{

				this.transform.position = new Vector3(-19.2f, 3.55f, 32.8f);

			}
			//condition 1
			if((n <= -46f && n >= -136f) || (n <= 314f && n >= 224f)){


				if(Input.GetKey(KeyCode.A) || x < -52){
					rb.AddForce(0, 0, -speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.D) || x > 52){
					rb.AddForce(0, 0, speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.W) || y > 52){
					rb.AddForce(-speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.S) || y < -52){
					rb.AddForce(speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else{
					if(a == 50){
						a = 0;
						transform.eulerAngles = new Vector3(0f, 0f, 0f);
					}
					else{
						a = a + 1;
					}
				}

			}

			//condition 2
			else if((n <= -137f && n >= -227f) || (n <= 223f && n >= 133f)){

				if(Input.GetKey(KeyCode.A) || x < -52){
					rb.AddForce(speed * Time.deltaTime,0 ,0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.D) || x > 52){
					rb.AddForce(-speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.W) || y > 52){
					rb.AddForce(0, 0, -speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.S) || y < -52){
					rb.AddForce(0, 0, speed * Time.deltaTime);
					a = 0;
				}
				else{
					if(a == 50){
						a = 0;
						transform.eulerAngles = new Vector3(0f, 0f, 0f);
					}
					else{
						a = a + 1;
					}
				}

			}

			//condition 3
			else if((n <= -228f && n >= -318f) || (n <= 132f && n >= 42f)){

				if(Input.GetKey(KeyCode.A) || x < -52){
					rb.AddForce(0, 0, speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.D) || x > 52){
					rb.AddForce(0, 0, -speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.W) || y > 52){
					rb.AddForce(speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.S) || y < -52){
					rb.AddForce(-speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else{
					if(a == 50){
						a = 0;
						transform.eulerAngles = new Vector3(0f, 0f, 0f);
					}
					else{
						a = a + 1;
					}
				}

			}

			//condition else
			else{

				if(Input.GetKey(KeyCode.A) || x < -52){
					rb.AddForce(-speed * Time.deltaTime,0 ,0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.D) || x > 52){
					rb.AddForce(speed * Time.deltaTime, 0, 0);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.W) || y > 52){
					rb.AddForce(0, 0, speed * Time.deltaTime);
					a = 0;
				}
				else if(Input.GetKey(KeyCode.S) || y < -52){
					rb.AddForce(0, 0, -speed * Time.deltaTime);
					a = 0;
				}
				else{
					if(a == 50){
						a = 0;
						transform.eulerAngles = new Vector3(0f, 0f, 0f);
					}
					else{
						a = a + 1;
					}
				}						

			}

	}

		public void ChangeWalk(){

			if (ChangeMode == false)
			{

				speed = 500f;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				ChangeMode = true;
				
			}
			else
			{
				
				transform.eulerAngles = new Vector3(0f, 0f, 0f);
				speed = 1000f;
				this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;				
				ChangeMode = false;

			}

		}
		public void Jump(){

			if(MaxJump < 1){

				rb.AddForce(0, 200, 0);
				Debug.Log(MaxJump);
				MaxJump++;

			}

		}

}
