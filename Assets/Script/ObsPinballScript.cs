using UnityEngine;
using System.Collections;

public class ObsPinballScript : MonoBehaviour {

	public Animator bumper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Diamond") {
			bumper.SetTrigger("Bump");
		}
	}
}
