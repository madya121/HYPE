using UnityEngine;
using System.Collections;

public class BackgroundGameplayScript : MonoBehaviour {

	public GameObject diamond;
	
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		float X = diamond.gameObject.transform.position.x / 7f;
		float Y = diamond.gameObject.transform.position.y / 7f;
		float Z = 0;
		transform.position = new Vector3(X, Y, Z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		float X = diamond.gameObject.transform.position.x / 6f;
		float Y = diamond.gameObject.transform.position.y / 6f;
		float Z = 0;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(X, Y, Z), ref velocity, 0.2f);
	}
}
