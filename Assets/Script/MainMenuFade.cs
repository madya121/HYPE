using UnityEngine;
using System.Collections;

public class MainMenuFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void MoveToGamePlay() {
		Application.LoadLevel("GamePlay");
	}
}
