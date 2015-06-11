using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GameObject fade;
	public GameJoltAPIManager GJAPIManager;
	public Text userNameUI, userTokenUI;
	public Text loginInfo;

	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GJAPIManager.isLogin == true && hasStarted == false) {
			GoToGameplay();
		}
	}
	
	public void GoToGameplay () {
		if (hasStarted == false) {
			hasStarted = true;
			fade.GetComponent<Animator>().SetTrigger("StartFade");
			fade.GetComponent<Image>().enabled = true;
		}
	}
	
	public void PlayPressed () {
		if (hasStarted == true) return;
		loginInfo.text = "Loging In ...";
		loginInfo.color = new Color(0, 1, 0);
		GJAPIManager.VerifyUser(userNameUI.text, userTokenUI.text);
	}
	
	public void GuestPressed () {
		if (hasStarted == true) return;
		GJAPIManager.isGuest = true;
		GoToGameplay();
	}
}
