using UnityEngine;
using System.Collections;

public class RandomColorWhenStartScript : MonoBehaviour {

	public Color[] colors;
	public GameObject[] objects;
	
	private SpriteRenderer spriteRenderer;
	
	void Awake () {
		Color color = colors[Random.Range(0, colors.Length)];
		
		foreach (GameObject _object in objects) {
			_object.GetComponent<SpriteRenderer>().color = color;
		}
	}
	
	public void ChangeColor(Color color) {
		foreach(GameObject _object in objects) {
			_object.GetComponent<SpriteRenderer>().color = color;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
