using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Cloud.Analytics;
using System.Collections;

public class GameplayScript : MonoBehaviour {

	public int tilePressed = 0;
	public TilesScript[] tiles;
	public GameObject fadeOut;
	public int obstacleTotal;
	public int tryObs = -1;

	void OnAwake () {
		Input.multiTouchEnabled = true;
	}

	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("42336");
		const string projectId = "0425a17a-2648-4360-88bb-e1cf57cdf5d5";
		UnityAnalytics.StartSDK (projectId);
		
		if (tryObs == -1) {
			string obsName = "Obstacle " + Random.Range(1, obstacleTotal + 1);
			Instantiate(Resources.Load(obsName, typeof(GameObject)));
		} else {
			string obsName = "Obstacle " + tryObs;
			Instantiate(Resources.Load(obsName, typeof(GameObject)));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == .2f) {
			if (Input.GetKeyDown(KeyCode.Return))
				OnRestartClick();
		}
	}
	
	void LateUpdate () {
		tilePressed = 0;
		for(int i=0;i<tiles.Length;i++)
			tilePressed += ((tiles[i].tilePressed == true) ? 1 : 0);
	}
	
	public void OnRestartClick () {
		GameDataStatic.AddPlaying();
		if (Advertisement.isReady() && GameDataStatic.GetPlayingSum() % 5 == 0) Advertisement.Show();
		else {
			fadeOut.GetComponent<Image>().enabled = true;
			fadeOut.GetComponent<Animator>().SetTrigger("Fadeout");
		}
	}
}
