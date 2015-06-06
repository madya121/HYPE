using UnityEngine;
using System.Collections;

public class MainCameraGamplayScript : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	
	private bool shaking;
	private Transform _transform;
	
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(!shaking)
			return;
		if (shake_intensity > 0f){
			//_transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
			_transform.localRotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else {
			shaking = false;
			//_transform.localPosition = originPosition;
			_transform.localRotation = originRotation;	
		}
	}
	
	public void Shake(){
		if(!shaking) {
			//originPosition = _transform.localPosition;
			originRotation = _transform.localRotation;
		}
		shaking = true;
		shake_intensity = .03f;
		shake_decay = 0.0007f;
	}
}
