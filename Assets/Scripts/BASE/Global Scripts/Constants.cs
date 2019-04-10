using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

	[Header("Links")]
	public string fbLink = "https://www.facebook.com/"; 
	public string moreGamesLink = "https://play.google.com/store?hl=en";
	public string rateUsLink = "https://play.google.com/store/apps/details?id=com.cmplay.dancingline&hl=en";
	public string privacyPolicy = "www.google.com";

	[Header("Ads ID")]
	public string admob_IAD_ID = "ca-app-pub-5770418752327094/7624135890";
	public string admob_RAD_ID = "ca-app-pub-5770418752327094/6665443297";

	public string unity_IAD_ID = "1713219";
	public string unity_RAD_ID = "rewardedVideo";


	[Header("Delays")]
	public int firstAdDelay = 120;
	public int secondAdDelay = 60;

	public int cubeRechargeDelay = 120;

}
