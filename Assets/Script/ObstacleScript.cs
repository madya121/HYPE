using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {

	public SpriteRenderer[] spriteRenderers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ChangeSpritesColor (Color color) {
		foreach(SpriteRenderer spriteRenderer in spriteRenderers) {
			spriteRenderer.color = color;
		}
	}
}
