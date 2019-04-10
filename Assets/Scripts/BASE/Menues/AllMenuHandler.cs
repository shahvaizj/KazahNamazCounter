using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMenuHandler : MonoBehaviour {

    public GameObject cNamazMenu;
    public GameObject pNamazMenu;
    public GameObject calculator;
    public GameObject tutorialObj;

    public CalculatorEventListner cal;


    private void Start() {

        if(Toolbox.Instance.userPrefs.tutorialShowed == 0) {

            tutorialObj.SetActive(true);
        }
    }

    public void OnPressCalculator() {

        cNamazMenu.SetActive(false);
        pNamazMenu.SetActive(false);
        calculator.SetActive(true);

    }

    public void OnPressCross() {

        tutorialObj.SetActive(false);
        Toolbox.Instance.userPrefs.tutorialShowed = 1;

        Toolbox.Instance.userPrefs.Save();
    }

    public void OnPressCNamazCalculator() {
        cNamazMenu.SetActive(true);
        pNamazMenu.SetActive(false);
        calculator.SetActive(false);
    }

    public void OnPressPNamazCalculator() {
        cNamazMenu.SetActive(false);
        pNamazMenu.SetActive(true);
        calculator.SetActive(false);
    }

    public void OnPress_Calculate() {

        int days;

        days = (cal.numValue[0] * 365) + (cal.numValue[1] * 31) + cal.numValue[2];

        PKazaNamazMenuEventListner pkaza = pNamazMenu.GetComponent<PKazaNamazMenuEventListner>();

        for(int i = 0; i < 5; i++) {

            pkaza.kazaCountersText[i].text = days.ToString();
            Toolbox.Instance.userPrefs.pNamazCounter[i] = days;
            Toolbox.Instance.userPrefs.SavePNamazCounter(i);
        }

        cNamazMenu.SetActive(false);
        pNamazMenu.SetActive(true);
        calculator.SetActive(false);

        
    }
}
