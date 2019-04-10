using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorEventListner : MonoBehaviour {

    public Text[] timeTexts;

    public int[] numValue = { 0, 0, 0 };

    private void OnEnable() {

        timeTexts[0].text = "0";
        timeTexts[1].text = "0";
        timeTexts[2].text = "0";

        numValue[0] = 0;
        numValue[1] = 0;
        numValue[2] = 0;
    }

    public void OnPressPlusButton(int i) {

        numValue[i]++;

        timeTexts[i].text = numValue[i].ToString();
    }

    public void OnPressMinusButton(int i) {
        
        if(--numValue[i] >= 0) {

            timeTexts[i].text = numValue[i].ToString();
        }

    }

}
