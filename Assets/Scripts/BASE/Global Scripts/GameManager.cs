using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[Header ("Important Scenes")]

	public string menuScene;
	public string [] gameScenes;

	[Header ("Bool")]
	public static bool islevelScene = false;
	public static bool doNotShowPopup = false;

	public bool isPortrait = false;

	[Header ("Int")]
	public float levelCompleteDelay = 2;
	public float levelFailDelay = 2;

	[Header("Other")]
	[HideInInspector]
	public AsyncOperation async = null; // When assigned, load is in progress.

	[HideInInspector]
	public GameObject callingSureMenuGameobject;

	bool canRecharge = false;

	DateTime rechargeStartTime;
	public DateTime rechargeTime;
	public int rechargeStartedSeconds = 0;
	float temptime = 1;

	void Start(){

		CheckStartRecharge ();
	}

	void FixedUpdate(){
		
//		Debug.Log ("Fixed Update!");
	}

	void Update(){

//		Debug.Log ("Update!");


		if (canRecharge) {
//			Debug.LogError (">>NOW > " + DateTime.Now);

			temptime -= Time.deltaTime;

			if (temptime <= 0) {
			
				temptime = 1;
				rechargeStartedSeconds++;
			}

			if(DateTime.Now >= rechargeTime){
//				Debug.LogError (">>DOWNLOAD > " + rechargeTime);

				canRecharge = false;
				rechargeStartedSeconds = 0;
				CubeRecharged ();
			}	
		}
	}

	void LateUpdate(){

//		Debug.Log ("LateUpdate!");

		if (async != null) {

			if (async.progress == 1) {

				async = null;
			}
		}



	}

	public void Set_DefaultValues(){


		Time.timeScale = 1;
		doNotShowPopup = false;
	}

	public void Load_MenuScene(){

		StartCoroutine("LoadMenuScene");
	}

	public void Load_GameScene(){

		StartCoroutine("LoadGameScene");
	}

	private IEnumerator LoadMenuScene() {

		Instantiate_Loading ();

		async = SceneManager.LoadSceneAsync(this.menuScene);
		yield return async;
	}

	private IEnumerator LoadGameScene() {

		Instantiate_Loading ();

		//async = SceneManager.LoadSceneAsync(this.gameScenes[Toolbox.Instance.userPrefs.currentLevel]);
		yield return async;
	}

	public void Direct_LoadGameScene(){

		//SceneManager.LoadScene (this.gameScenes[Toolbox.Instance.userPrefs.currentLevel]);
	}

	//Runtime Menu Handling
	public void Instantiate_PauseMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/PauseMenu-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/PauseMenu-Landscape"));
		}

	}

	public void Instantiate_LowCoins(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LowCoins-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LowCoins-Landscape"));
		}

	}

	public void Instantiate_Sure( GameObject obj){

		callingSureMenuGameobject = obj;

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Sure-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Sure-Landscape"));
		}

	}

	public void Instantiate_SelectCharacterMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/CharacterSelection-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/CharacterSelection-Landscape"));
		}
	}

	public void Instantiate_OptionsMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Options-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Options-Landscape"));
		}
	}

	public void Instantiate_LevelLockedMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelLocked-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelLocked-Landscape"));
		}
	}

	public void Instantiate_Loading(){

		Toolbox.Instance.soundManager.Stop_BGSound ();

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Loading-Portrait"));
		
		} else {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/Loading-Landscape"));
		
		}
	}


	//LevelComplete
	public void LevelCompleteWithDelay(){
//		if (doNotShowPopup)
//			return;

		doNotShowPopup = true;
	
		StartCoroutine (LevelCompleteAfterDelay());
	}

	IEnumerator LevelCompleteAfterDelay(){

		yield return new WaitForSeconds (levelCompleteDelay);

		Instantiate_LevelCompleteMenu ();
	}

	void Instantiate_LevelCompleteMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelComplete-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelComplete-Landscape"));
		}
	}


	//LevelFailed
	public void LevelFailWithDelay(){
//		Debug.Log("DoNotShowPopup = " + doNotShowPopup);

//		if (doNotShowPopup)
//			return;

//		Time.timeScale = 0.5f;

		doNotShowPopup = true;

		StartCoroutine (LevelFailAfterDelay ());
	}

	IEnumerator LevelFailAfterDelay(){

		yield return new WaitForSeconds (levelFailDelay);

		Instantiate_LevelFailMenu ();
	}

	void Instantiate_LevelFailMenu(){

		if (islevelScene) {

			if (isPortrait) {
				Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelFail-Portrait"));

			} else {

				Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelFail-Landscape"));
			}

		} else {

			Instantiate_TryAgainMenu ();
		}
	}

	private void Instantiate_TryAgainMenu(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/TryAgain-Portrait"));

		} else {

			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/TryAgain-Landscape"));
		}

	}

	public void instantiateLevelFailWithoutDelay(){

		if (isPortrait) {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelFail-Portrait"));

		} else {
			Instantiate ((GameObject)Resources.Load ("Prefabs/Menues/LevelFail-Landscape"));
		}

	}

	public void CheckStartRecharge(){

//		int t = 15 - Toolbox.Instance.userPrefs.totalCubes;

//		if (t > 0) {

//			Toolbox.Instance.userPrefs.LoadTime ();

////			Debug.LogError ("TIME - " + rechargeTime);


//			for (int i = 0; i < t; i++) {
			
//				if (DateTime.Now > rechargeTime) { // if current time is greater than recharge time

//					if(Toolbox.Instance.userPrefs.totalCubes < 15)
//						Toolbox.Instance.userPrefs.totalCubes++;

//					if (Toolbox.Instance.userPrefs.totalCubes >= 15) { //if cubes are full 
					
//						break;
					
//					} else {
					
//						rechargeTime = rechargeTime.AddSeconds (Toolbox.Instance.constants.cubeRechargeDelay);
//					}
				
//				} else {
				
////					Debug.LogError (">>REC LESS");

//					canRecharge = true;
//					break;
//				}
//			}

//		}
	}

	public void StartRecharge(){
		
//		Debug.LogError ("CUR TIME - " + DateTime.Now);

		if (!canRecharge) { // if allready recharging then dont update recharge time
		
			rechargeTime = DateTime.Now.AddSeconds (Toolbox.Instance.constants.cubeRechargeDelay);
			canRecharge = true;
		}


//		Debug.LogError ("REC - " + rechargeTime);

	}

	public void CubeRecharged(){


		//if (Toolbox.Instance.userPrefs.totalCubes < 15) {
		
		//	StartRecharge ();
		//} else {
		
		//	canRecharge = false;
		//}
	}

	void OnApplicationFocus(bool focus){
	
		if (!focus) {

		}
			
	}

	void OnApplicationQuit(){

		SaveRechargeDATETIME ();
	}

	void SaveRechargeDATETIME(){

		//if (canRecharge) {
		
		//	int t = 15 - Toolbox.Instance.userPrefs.totalCubes;
		//	t = (t * Toolbox.Instance.constants.cubeRechargeDelay);
		//	t -= rechargeStartedSeconds;

		//	Toolbox.Instance.userPrefs.SaveTime ();	
		//}

		//Toolbox.Instance.userPrefs.Save ();	
	}
}
