using UnityEngine;
using System.Collections;

public class FollowAngleObsScript : MonoBehaviour {

	public GameObject target;
	public GameObject bullet;
	public float beginShoot = 3;
	public float shootTime = 3;
	public float deltaShoot = 0.5f;

	private GameObject diamond;
	private float secondShoot = 0f;
	private float secondDeltaShoot = 0f;
	private bool canShoot = false;

	void Awake () {
		diamond = GameObject.FindGameObjectWithTag("Diamond");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		secondShoot += Time.deltaTime;
		
		if (secondShoot >= beginShoot) {
			canShoot = true;
		}
		
		if (secondShoot >= beginShoot + shootTime) {
			secondShoot = 0;
			canShoot = false;
		}
		
		if (canShoot) {
			secondDeltaShoot += Time.deltaTime;
			if (secondDeltaShoot >= deltaShoot) {
				GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
				_bullet.GetComponent<BulletScript>().MoveTo(target.transform.position);
				_bullet.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
				secondDeltaShoot = 0f;
			}
		}
	}
	
	void FixedUpdate () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Camera.main.WorldToScreenPoint(diamond.transform.position) - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1);
	}
}
