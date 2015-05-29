using UnityEngine;
using System.Collections;

public class TilesScript : MonoBehaviour {

	public GameObject gameplayScriptObject;
	public Color notPressed;
	public Color pressed;
	public GameObject gameoverMenu;
	public int tileNumber;
	public bool tilePressed = false;

	private GameplayScript gameplayScript;
	private bool canBounce = false;

	// Use this for initialization
	void Start () {
		gameplayScript = gameplayScriptObject.GetComponent<GameplayScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//KeyboardInput();
	}
	
	void KeyboardInput() {		
		if (tileNumber == 1) {
			bool left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J);
			if (left) Pressed();
			else NotPressed();
		} else if (tileNumber == 2) {
			bool center = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.K);
			if (center) Pressed();
			else NotPressed();
		} else if (tileNumber == 3) {
			bool right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L);
			if (right) Pressed();
			else NotPressed();
		}
	}
	
	void Pressed() {
		if (Time.timeScale == 0.2f) return;
		if (gameplayScript.tilePressed < 1) {
			canBounce = true;
			gameObject.GetComponent<SpriteRenderer>().color = pressed;
			tilePressed = true;
		}
	}
	
	void NotPressed() {
		if (Time.timeScale == 0.2f) return;
		if (tilePressed == true) {
			canBounce = false;
			gameObject.GetComponent<SpriteRenderer>().color = notPressed;
			tilePressed = false;
		}
	}
	
	void OnMouseDown() {
		Pressed();
	}
	
	void OnMouseUp() {
		NotPressed();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Diamond") {
			if (canBounce == true) {
				int Xplus = Random.Range(-300, -50);
				int Xmin = Random.Range(50, 300);
				int X = (Random.Range(0, 10) % 2 == 0) ? Xplus : Xmin;
				
				int Yplus = Random.Range(-70, -30);
				int Ymin = Random.Range(30, 70);
				int Y = (Random.Range(0, 10) % 2 == 0) ? Yplus : Ymin;
				
				coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y));
				coll.gameObject.GetComponent<DiamondScript>().GetHit();
			} else {
				if (Time.timeScale != 0.2f)
					gameoverMenu.GetComponent<Animator>().SetTrigger("Gameover");
				Time.timeScale = 0.2f;
				coll.gameObject.GetComponent<Rigidbody2D>().velocity = coll.gameObject.GetComponent<Rigidbody2D>().velocity * 0.2f;
			}
		}
	}
}
