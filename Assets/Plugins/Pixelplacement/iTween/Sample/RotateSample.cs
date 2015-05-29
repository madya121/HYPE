using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		//iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
		//iTween.MoveTo(gameObject, iTween.Hash("position", Vector3.zero, "time", 5));
		
		
	}
	
	void Update () {
		transform.position = iTween.Vector3Update(transform.position, new Vector3(50, 50, 0), 10);
	}
}

