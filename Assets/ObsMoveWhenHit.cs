using UnityEngine;
using System.Collections;

public class ObsMoveWhenHit : MonoBehaviour {

	public float X, Y;
	public GameObject obstacle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag != "Diamond") return;
		
		GameObject diamond = coll.gameObject;
		Vector3 position = obstacle.transform.position;
		if (X > 0) {
			if (diamond.transform.position.x < transform.position.x) {
				position.x += X;
				obstacle.transform.position = position;
			}
		}
		if (X < 0) {
			if (diamond.transform.position.x > transform.position.x) {
				position.x += X;
				obstacle.transform.position = position;
			}
		}
		if (Y > 0) {
			if (diamond.transform.position.y < transform.position.y) {
				position.y += Y;
				obstacle.transform.position = position;
			}
		}
		if (Y < 0) {
			if (diamond.transform.position.y > transform.position.y) {
				position.y += Y;
				obstacle.transform.position = position;
			}
		}
	}
}
