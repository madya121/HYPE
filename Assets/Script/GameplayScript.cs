using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Cloud.Analytics;
using System.Collections;

public class GameplayScript : MonoBehaviour {

	public GameObject diamond;
	public GameObject[] backgrounds;
	public SpriteRenderer[] spriteRenderers;
	public Xft.XWeaponTrail[] xfts;
	public int tilePressed = 0;
	public TilesScript[] tiles;
	public GameObject fadeOut;
	public int obstacleTotal;
	public int tryObs = -1;
	public Color[] colors;
	
	private GameJoltAPIManager GJAPIManager;

	void Awake () {
		Input.multiTouchEnabled = true;
		
		GJAPIManager = GameObject.Find("_GameJoltAPIManager").GetComponent<GameJoltAPIManager>();
	}

	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("42336");
		const string projectId = "0425a17a-2648-4360-88bb-e1cf57cdf5d5";
		UnityAnalytics.StartSDK (projectId);
		
		if (tryObs == -1) {
			int prefabNumber = -1;
			Random.seed = Random.Range(0, 1000000);
			do {
				prefabNumber = Random.Range(1, obstacleTotal + 1);
			} while (prefabNumber == GameDataStatic.prefabBefore);
			GameDataStatic.prefabBefore = prefabNumber;
			string obsName = "Obstacle " + prefabNumber;
			
			GameObject obs = Instantiate(Resources.Load(obsName, typeof(GameObject))) as GameObject;
			int colorRandom = Random.Range(0, colors.Length);
			obs.GetComponent<ObstacleScript>().ChangeSpritesColor(colors[colorRandom]);
			diamond.GetComponent<SpriteRenderer>().color = colors[colorRandom];						
			
			foreach(GameObject background in backgrounds) {
				background.GetComponent<SpriteRenderer>().color = new Color(colors[colorRandom].r, 
			                                                            colors[colorRandom].g, 
			                                                            colors[colorRandom].b,
			                                                            background.GetComponent<SpriteRenderer>().color.a);
			}
			
			foreach(Xft.XWeaponTrail xft in xfts) {
				xft.MyColor = new Color(colors[colorRandom].r, 
				                        colors[colorRandom].g, 
				                        colors[colorRandom].b,
				                        100f / 255f);
			}
			
			foreach(SpriteRenderer spriteRenderer in spriteRenderers) {
				spriteRenderer.color = colors[colorRandom];
			}
		} else {
			string obsName = "Obstacle " + tryObs;
			GameObject obs = Instantiate(Resources.Load(obsName, typeof(GameObject))) as GameObject;
			int colorRandom = Random.Range(0, colors.Length);
			obs.GetComponent<ObstacleScript>().ChangeSpritesColor(colors[colorRandom]);
			diamond.GetComponent<SpriteRenderer>().color = colors[colorRandom];
			
			foreach(GameObject background in backgrounds) {
				background.GetComponent<SpriteRenderer>().color = new Color(colors[colorRandom].r, 
				                                                            colors[colorRandom].g, 
				                                                            colors[colorRandom].b,
				                                                            background.GetComponent<SpriteRenderer>().color.a);
			}
			
			foreach(Xft.XWeaponTrail xft in xfts) {
				xft.MyColor = new Color(colors[colorRandom].r, 
				                        colors[colorRandom].g, 
				                        colors[colorRandom].b,
				                        100f / 255f);
			}
			
			foreach(SpriteRenderer spriteRenderer in spriteRenderers) {
				spriteRenderer.color = colors[colorRandom];
			}
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
		//GameDataStatic.AddPlaying();
		//if (Advertisement.isReady() && GameDataStatic.GetPlayingSum() % 5 == 0) Advertisement.Show();
		//else {
			if (GJAPIManager.isGuest == false)
				GJAPIHelper.Scores.DismissLeaderboards();
			fadeOut.GetComponent<Image>().enabled = true;
			fadeOut.GetComponent<Animator>().SetTrigger("Fadeout");
		//}
	}
	
	public void OnLeaderboardClick () {
		if (GJAPIManager.isGuest == false) {
			GJAPIHelper.Scores.DismissLeaderboards();
			GJAPIHelper.Scores.ShowLeaderboards();
		}
	}
}
