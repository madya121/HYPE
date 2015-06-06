using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	private Rigidbody2D rgBody2D;
	
	void Awake () {
		rgBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void MoveTo(Vector3 destination) {
		float X = destination.x / 4f;
		float Y = destination.y / 4f;
		
		rgBody2D.velocity = new Vector2(X, Y);
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
