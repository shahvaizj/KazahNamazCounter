using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayServicesManager : MonoBehaviour  {

	//void Start (){

	//	PlayGamesClientConfiguration config = new 
	//		PlayGamesClientConfiguration.Builder()
	//		.Build();

	//	PlayGamesPlatform.DebugLogEnabled = true;

	//	PlayGamesPlatform.InitializeInstance(config);
	//	PlayGamesPlatform.Activate();

	//	AdsManager.Instance.unity_rAd_Status.text = "AUTHNTICATED";
	//}

	//public void SignIN(){

	//	if (Social.localUser.authenticated) {
			
	//		AdsManager.Instance.unity_rAd_Status.text = "LOGGED IN";

	//	} else {
	//		AdsManager.Instance.unity_rAd_Status.text = "L1 Try";
		
	//		Social.localUser.Authenticate (success => {

	//			if(success){
	//				AdsManager.Instance.unity_rAd_Status.text = "NEW_IN";
	//			}else{
	//				AdsManager.Instance.unity_rAd_Status.text = "NEW_OUT";
	//			}
	//		});
	//	}
	//}

	//public void ShowAchievements(){
	
	//	if (Social.localUser.authenticated) {
	//		AdsManager.Instance.unity_iAd_Status.text = "Called Show Achievements";

	//		Social.ShowAchievementsUI ();

	//	} else {
	//		AdsManager.Instance.unity_iAd_Status.text = "CANT! Not Loged IN";
	//	}
	//}
}
