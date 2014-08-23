using UnityEngine;
using System.Collections;

public class HomeWorldTriggerBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		Debug.Log ("collided with trigger: " + other.rigidbody.isKinematic);
		//other.rigidbody.isKinematic = false;
	}
}
