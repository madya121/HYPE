using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GameObject fade;

	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown(0) || Input.touches.Length > 0) && hasStarted == false) {
			hasStarted = true;
			fade.GetComponent<Animator>().SetTrigger("StartFade");
		}
	}
}
