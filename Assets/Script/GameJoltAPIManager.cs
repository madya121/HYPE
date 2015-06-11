using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameJoltAPIManager : MonoBehaviour {

	public int gameID;
	public string privateKey;
	public bool isLogin = false;
	public bool isGuest = false;
	
	public Image userNameField, userTokenField;
	public Text loginInfo;
	
	void Awake () {
		DontDestroyOnLoad ( gameObject );
		GJAPI.Init ( gameID, privateKey );
		GJAPI.Users.VerifyCallback += OnVerifyUser;
	}
	
	void OnVerifyUser ( bool success ) {
		if ( success ) {
			Debug.Log ( "Yepee!" );
			loginInfo.text = "Login Succeed";
			loginInfo.color = new Color(0, 1, 0);
			isLogin = true;
		}
		else {
			Debug.Log ( "Um... Something went wrong." );
			userNameField.color = new Color(255f / 255f, 184f / 255f, 184f / 255f);
			userTokenField.color = new Color(255f / 255f, 184f / 255f, 184f / 255f);
			loginInfo.text = "Login Failed. Check your Username / Token or Your Internet Connection";
			loginInfo.color = new Color(1, 0, 0);
		}
	}
	
	public void VerifyUser(string userName, string userToken) {
		if (userName.Trim() == string.Empty || userToken.Trim() == string.Empty) {
			loginInfo.text = "Both Field Cannot Be Empty";
			loginInfo.color = new Color(1, 0, 0);
			userNameField.color = new Color(255f / 255f, 184f / 255f, 184f / 255f);
			userTokenField.color = new Color(255f / 255f, 184f / 255f, 184f / 255f);
			return;
		}
		GJAPI.Users.Verify ( userName, userToken );
		userNameField.color = new Color(1, 1, 1);
		userTokenField.color = new Color(1, 1, 1);
	}
}