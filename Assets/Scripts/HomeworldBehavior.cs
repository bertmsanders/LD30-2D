using UnityEngine;
using System.Collections;

public class HomeworldBehavior : MonoBehaviour {

	//public CameraBehaviour subCamera;
	
	public float movementAccel = 50f;
	public float maxSpeed = 5f;
	public float increaseRatio = .25f;

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Input.GetAxis ("Horizontal") + " - " + Input.GetAxis("Vertical"));
		directionalInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
		this.transform.localEulerAngles = new Vector3(0,0,0);



	}



	void OnCollisionEnter(Collision collision){
		Collider other = collision.collider;
		Debug.Log ("collided");
		if(this.rigidbody.mass > other.rigidbody.mass){
			Debug.Log("I'm Bigger");
			float increaseX = (float)(other.transform.localScale.x * increaseRatio);
			float increaseY = (float)(other.transform.localScale.y * increaseRatio);
			this.transform.localScale += new Vector3(increaseX,increaseY,0);
			this.rigidbody.mass += other.rigidbody.mass;
			Destroy(other.gameObject);
			Debug.Log("I'm Bigger - Mass: " + this.rigidbody.mass + " Scale: " + this.transform.localScale.x);
		}else{
			Debug.Log("I'm Smaller");
		}
	}

	public void directionalInput(Vector2 moveVector) {
//			if(!audio.isPlaying){
//				Common.playSound(this.audio, movementSound);
//			}			
		//if (rigidbody.velocity.magnitude < maxSpeed) {
		//this.collider2D.attachedRigidbody.AddForce(moveVector * movementAccel);
		rigidbody.AddForce(moveVector * movementAccel, ForceMode.Acceleration);
		//}

		
	}

}
