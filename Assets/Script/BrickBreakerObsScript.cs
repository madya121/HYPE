using UnityEngine;
using System.Collections;

public class BrickBreakerObsScript : MonoBehaviour {

	private GameObject diamond;
	private Vector3 velocity = Vector3.zero;

	void Awake () {
		diamond = GameObject.FindGameObjectWithTag("Diamond");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		float X = diamond.gameObject.transform.position.x;
		float Y = 1;
		float Z = 0;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(X, Y, Z), ref velocity, 0.5f);
	}
}
