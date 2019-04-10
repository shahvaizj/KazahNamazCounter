using UnityEngine;
using System.Collections;
using System;

public class UserPrefs : MonoBehaviour {

    public bool unlockAllLevels = false;
    public bool loadWeeknDay = true;

    //Prefs Names
    [Header("Strings")]
    private string _currentWeek = "CurrentWeek";
    private string _currentDay = "CurrentDay";
    private string _audioLanguage = "AudioLanguage";

    private string _gameAudio = "GameAudio";
    private string _totalCoins = "TotalCoins";
    private string _highScore = "HighScore";
    private string _language = "Language";

    private string _firstRun = "FirstRun";
    private string _tutorialShowed = "TutorialShowed";
    private string _appRated = "AppRated";

    public string[] _cNamazCounter = { "cFajr", "cZohr", "cAsar", "cMagrib", "cIsha" };
    public string[] _pNamazCounter = { "pFajr", "pZohr", "pAsar", "pMagrib", "pIsha" };

    [Header("Int")]
    public int currentWeek = 0;
    public int currentDay = 0;
    public int gameAudio = 1; // 1 is for true and 0 is for false
    public int audioLanguage = 1; // 1 is for true and 0 is for false
    public int totalCoins = 0;

    public int highScore = 0;
    public int language = 0;

    public int firstRun = 0;
    public int tutorialShowed = 0;
    public int appRated = 0;

    public int[] cNamazCounter = { 0, 0, 0, 0, 0 };
    public int[] pNamazCounter = { 0, 0, 0, 0, 0 };

    void Awake() {

        Load();
    }

    public void Save() {

        Debug.Log("SAVE!");

        PlayerPrefs.SetInt(_currentWeek, currentWeek);

        PlayerPrefs.SetInt(_currentDay, currentDay);

        PlayerPrefs.SetInt(_gameAudio, gameAudio);

        PlayerPrefs.SetInt(_totalCoins, totalCoins);

        PlayerPrefs.SetInt(_highScore, highScore);

        PlayerPrefs.SetInt(_audioLanguage, audioLanguage);

        PlayerPrefs.SetInt(_language, language);

        PlayerPrefs.SetInt(_appRated, appRated);

        PlayerPrefs.SetInt(_firstRun, firstRun);

        PlayerPrefs.SetInt(_tutorialShowed, tutorialShowed);     

    }

    public void SaveCNamazCounter(int i) {

        PlayerPrefs.SetInt(_cNamazCounter[i], cNamazCounter[i]);
    }

    public void SavePNamazCounter(int i) {

        PlayerPrefs.SetInt(_pNamazCounter[i], pNamazCounter[i]);
    }

    public void Load() {

        Debug.Log("LOAD!");

        LoadWeeknDay();

        totalCoins = PlayerPrefs.GetInt(_totalCoins, totalCoins);

        gameAudio = PlayerPrefs.GetInt(_gameAudio, gameAudio);

        highScore = PlayerPrefs.GetInt(_highScore, highScore);

        audioLanguage = PlayerPrefs.GetInt(_audioLanguage, audioLanguage);

        language = PlayerPrefs.GetInt(_language, language);

        appRated = PlayerPrefs.GetInt(_appRated, appRated);

        firstRun = PlayerPrefs.GetInt(_firstRun, firstRun);

        tutorialShowed = PlayerPrefs.GetInt(_tutorialShowed, tutorialShowed);

        for(int i=0; i<cNamazCounter.Length; i++) {

            cNamazCounter[i] = PlayerPrefs.GetInt(_cNamazCounter[i], cNamazCounter[i]);
        }

        for(int i = 0; i < pNamazCounter.Length; i++) {

            pNamazCounter[i] = PlayerPrefs.GetInt(_pNamazCounter[i], pNamazCounter[i]);
        }
    }

    private void LoadWeeknDay() {

        if(loadWeeknDay) {

            currentWeek = PlayerPrefs.GetInt(_currentWeek, currentWeek);
            currentDay = PlayerPrefs.GetInt(_currentWeek, currentDay);
        }
    }

    public void SaveCoins() {

        PlayerPrefs.SetInt(_totalCoins, totalCoins);
    }

}
