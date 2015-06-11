using UnityEngine;
using System.Collections;

public class PointPlanetScript : MonoBehaviour {

	public float maxGravDist = 4.0f;
	public float maxGravity = 35.0f;
	
	private GameObject diamond;
	private GameObject[] dusts;
	private Rigidbody2D rgBody2D;

	// Use this for initialization
	void Start () {
		diamond = GameObject.FindGameObjectWithTag("Diamond");
		rgBody2D = diamond.GetComponent<Rigidbody2D>();
		
		dusts = GameObject.FindGameObjectsWithTag("Dust");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		float dist = Vector3.Distance(diamond.transform.position, transform.position);
		if (dist <= maxGravDist) {
			Vector3 v = transform.position - diamond.transform.position;
			rgBody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
		}
		
		foreach(GameObject dust in dusts) {
			Rigidbody2D rgBodyDust2D = dust.GetComponent<Rigidbody2D>();
		
			dist = Vector3.Distance(dust.transform.position, transform.position);
			if (dist <= maxGravDist) {
				Vector3 v = transform.position - dust.transform.position;
				rgBodyDust2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
			}	
		}
	}
}
