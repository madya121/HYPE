using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutScript : MonoBehaviour {

	public GameObject diamond;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartNewGame () {
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void StartGame()	{
		Rigidbody2D rig2D = diamond.GetComponent<Rigidbody2D>();
		rig2D.velocity = new Vector2(Random.Range(-5, 5), Random.Range(5, 7));
	
		GetComponent<Image>().enabled = false;
	}
}
