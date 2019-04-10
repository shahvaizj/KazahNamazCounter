using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;

public class AdsManager : Singleton<AdsManager> {

//	bool adMob_IAdShown = false;
//	bool adMob_RAdShown = false;


//	#if UNITY_ANDROID

//	public string adMob_IAD_ID = "";
//	public string adMob_RAD_ID = "";

//	public string unity_IAD_ID = "1713219";
//	public string unity_RAD_ID = "";

//	#elif UNITY_IPHONE

//	#endif

//	InterstitialAd iAd;
//	private RewardBasedVideoAd rAd;


//	public bool showAdStatus;
//	public Text admob_iAd_Status;
//	public Text admob_rAd_Status;
//	public Text unity_iAd_Status;
//	public Text unity_rAd_Status;

//	public static int rewardNum = 0;

//	#region TimeHandling
//	bool firstAd;
//	bool canShowAd;

//	float curTime;
//	Constants constants;
//	#endregion

//	public void Init()
//	{
//		UpdateKeys ();

//		iAd = new InterstitialAd(adMob_IAD_ID);
//		rAd = RewardBasedVideoAd.Instance;

//		if(Advertisement.isSupported)
//			Advertisement.Initialize (unity_IAD_ID);

//		SetupEvents();

//		//load Rewarded Videos
////		this.Request_Admob_RAD();

//		firstAd = true;
//		canShowAd = false;
//		curTime = 0;
//		constants = Toolbox.Instance.constants;
//	}

//	void UpdateKeys (){
	
//		Constants constants = Toolbox.Instance.constants;

//		adMob_IAD_ID = constants.admob_IAD_ID;
//		adMob_RAD_ID = constants.admob_RAD_ID;

//		unity_IAD_ID = constants.unity_IAD_ID;
//		unity_RAD_ID = constants.unity_RAD_ID;

//	}
		

//	void SetupEvents()
//	{

//		// Get singleton reward based video ad reference.

//		//INTERSTITIAL EVENETS
//		// Called when an ad request has successfully loaded.
//		// Called when an ad request failed to load.

//		//REWARDED EVENETS

//		// Called when an ad request has successfully loaded.
//		// Called when an ad request failed to load.
//		// Called when an ad is shown.
////		rAd.OnAdOpening += HandleRewardBasedVideoOpened;
//		// Called when the ad starts to play.
////		rAd.OnAdStarted += HandleRewardBasedVideoStarted;
//		// Called when the user should be rewarded for watching a video.
//		// Called when the ad is closed.
////		rAd.OnAdClosed += HandleRewardBasedVideoClosed;
//		// Called when the ad click caused the user to leave the application.
////		rAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

//	}

//	void Update(){
	
//		if (!canShowAd) {
		
//			if (firstAd) {

//				curTime = Time.time;

//				if (curTime > constants.firstAdDelay) {

//					canShowAd = true;
//					firstAd = false;
//				}

//			} else {

//				curTime -= Time.deltaTime;

//				if (curTime <= 0) {
				
//					canShowAd = true;
//				}
//			}
//		}

//	}

//	public void Show_IAD(){

//		if (!canShowAd)
//			return;

//		if (adMob_IAdShown) {

//			if (Advertisement.IsReady ()) {
//				Show_Unity_IAd ();
//			} else {
//				Show_AdMob_IAd ();
//			}

//		}else{

//			if (iAd.IsLoaded ()) {
//				Show_AdMob_IAd ();			
			
//			} else {
//				Show_Unity_IAd ();
//			}
//		}


//	}

//	public void Show_RAD(){

//		if (adMob_RAdShown) {

//			Show_Unity_RewardedVideo ();

//		}else{

//			adMob_RAdShown = true;

//			Show_Admob_RAD ();
//		}

//	}

//	public void RequestAdmobAds(){
	
//		Request_Admob_IAD ();
//		Request_Admob_RAD ();
//	}

//	public void Request_Admob_IAD(){
		
//		Debug.Log ("REQUESTING IAD");
//		// Create an empty ad request.
//		AdRequest request = new AdRequest.Builder().Build();
//		// Load the interstitial with the request.
//		iAd.LoadAd(request);

//		if(showAdStatus)
//			admob_iAd_Status.text = "Requesting IAd";

//	}

//	public void Show_AdMob_IAd(){
	
//		if (!canShowAd)
//			return;

//		if(iAd.IsLoaded()){
//			Debug.Log ("SHOWING  ADMOB IAD");

//			iAd.Show ();

//			adMob_IAdShown = true;

//			if(showAdStatus)
//				admob_iAd_Status.text = "SHOWING IAD";
			
//		} else {
//			Debug.Log ("ADMOB IAD NOT LOADED");

//			if(showAdStatus)
//				admob_iAd_Status.text = "IAD NOT LOADED";
//		}

//		curTime = constants.secondAdDelay;
//		canShowAd = false;
//	}

//	public void Request_Admob_RAD(){
		
//		Debug.Log ("REQUESTING RAD");
//		// Create an empty ad request.
//		AdRequest request = new AdRequest.Builder().Build();
//		// Load the rewarded video ad with the request.

//		this.rAd.LoadAd(request, adMob_RAD_ID);

//		if(showAdStatus)
//			admob_rAd_Status.text = "Requesting RAd";

//	}

//	public void Show_Admob_RAD(){

//		if (rAd.IsLoaded ()) {
//			Debug.Log ("SHOWING RAD");

//			adMob_RAdShown = true;

//			rAd.Show();

//			if(showAdStatus)
//				admob_rAd_Status.text = "SHOWING RAD";


//		} else {
//			Debug.Log ("RAD NOT LOADED");

//			if(showAdStatus)
//				admob_rAd_Status.text = "RAD NOT LOADED";

//			Show_Unity_RewardedVideo ();
//		}
//	}


//	public void Show_Unity_IAd(){

////		if (Advertisement.IsReady (unity_IAD_ID)){

//			adMob_IAdShown = false;

//			if(showAdStatus)
//				unity_iAd_Status.text = "Showing Unity Ad";
			
//			Advertisement.Show ();

//			Debug.Log ("SHOWING  Unity IAD");

////		} else {
////			if(showAdStatus)
////				unity_iAd_Status.text = "UnityAD not Available";
////			
////			Debug.Log ("UNITY IAD NOT LOADED");
////
////		}

//		curTime = constants.secondAdDelay;
//		canShowAd = false;
//	}

//	public void Show_Unity_RewardedVideo ()
//	{
//		ShowOptions options = new ShowOptions();
//		options.resultCallback = HandleShowResult;

//		Advertisement.Show(unity_RAD_ID, options);

//		adMob_RAdShown = false;

//		if(showAdStatus)
//			unity_rAd_Status.text = "Showing Rewarded Unity";
//	}

//	void HandleShowResult (ShowResult result)
//	{
//		if(result == ShowResult.Finished) {
//			Debug.Log("Video completed - Offer a reward to the player");
//			if(showAdStatus)
//				unity_rAd_Status.text = "RewarDING";

//		}else if(result == ShowResult.Skipped) {
//			Debug.LogWarning("Video was skipped - Do NOT reward the player");

//		}else if(result == ShowResult.Failed) {
//			Debug.LogError("Video failed to show");

//			Show_Admob_RAD ();
//		}
//	}

//	public bool IsAnyRewardedVideoAvailable(){

//		if (rAd.IsLoaded() || Advertisement.IsReady(unity_RAD_ID)) {
		
//			return true;

//		}else {

//			return true;
//		}
//	}





//	//  ADMOB INTERSTITIAL EVENTS -----------------------------------

//	public void HandleOnAdLoaded(object sender, EventArgs args)
//	{
//		if(showAdStatus)
//			admob_iAd_Status.text = "Loaded";

//		MonoBehaviour.print("HandleAdLoaded event received");


//	}

//	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//	{
//		if(showAdStatus)
//			admob_iAd_Status.text = "Failed - " + args.Message;


//		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
//			+ args.Message);
//	}


//	//  REWARDED EVENTS -----------------------------------


//	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
//	{
//		if(showAdStatus)
//			admob_rAd_Status.text = "loaded";

//		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
//	}

//	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//	{
//		if(showAdStatus)
//			admob_rAd_Status.text = "Failed - " + args.Message;

//		MonoBehaviour.print(
//			"HandleRewardBasedVideoFailedToLoad event received with message: "
//			+ args.Message);

//	}

//	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//	{
//		if(showAdStatus)
//			admob_rAd_Status.text = "Rewarded";

//		string type = args.Type;
//		double amount = args.Amount;
//		MonoBehaviour.print(
//			"HandleRewardBasedVideoRewarded event received for "
//			+ amount.ToString() + " " + type);
//	}
		

}
