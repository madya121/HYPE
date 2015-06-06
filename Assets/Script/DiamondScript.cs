using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiamondScript : MonoBehaviour {

	public GameObject score;
	public GameObject blast;
	public GameObject blastForce;
	public GameObject mainCamera;
	public float maxForceY = 10;
	public float maxForceX = 10;

	private Rigidbody2D rig2D;
	private int scoreInt = 0;
	private Text textScore;
	private float secondAfterLastHit = 0f;

	// Use this for initialization
	void Start () {
		rig2D = GetComponent<Rigidbody2D>();
	
		scoreInt = 0;
		textScore = score.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		secondAfterLastHit += Time.deltaTime;
		
		if (secondAfterLastHit >= 7f && Time.timeScale != 0.2f) {
			secondAfterLastHit = 0f;
			rig2D.velocity = new Vector2(Random.Range(-5, 5), Random.Range(5, 7));
			Instantiate(blastForce, transform.position, Quaternion.identity);
		}
	}
	
	void LateUpdate () {
		float X = rig2D.velocity.x;
		float Y = rig2D.velocity.y;
		if (X <= -maxForceX) X = -maxForceX;
		if (X >= maxForceX) X = maxForceX;
		if (Y <= -maxForceY) Y = -maxForceY;
		if (Y >= maxForceY) Y = maxForceY;
		rig2D.velocity = new Vector2(X, Y);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			if (Time.timeScale == 0.2f) return;
			Instantiate(blast, transform.position, Quaternion.identity);
			scoreInt++;
			textScore.text = scoreInt + "";
			mainCamera.GetComponent<MainCameraGamplayScript>().Shake();
		}
	}
	
	public void GetHit() {
		secondAfterLastHit = 0f;
	}
}
