using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CKazaNamazMenuEventListner : MonoBehaviour {
    
    public Text [] kazaCountersText;
    
    public void Start() {

        for(int i = 0; i < kazaCountersText.Length; i++) {

            kazaCountersText[i].text = Toolbox.Instance.userPrefs.cNamazCounter[i].ToString();
        }
    }

    public void OnPressPlusButton(int i) {

        Toolbox.Instance.userPrefs.cNamazCounter[i]++;
        Toolbox.Instance.userPrefs.SaveCNamazCounter(i);

        kazaCountersText[i].text = Toolbox.Instance.userPrefs.cNamazCounter[i].ToString();
    }

    public void OnPressMinusButton(int i) {

        if(--Toolbox.Instance.userPrefs.cNamazCounter[i] >= 0) {

            Toolbox.Instance.userPrefs.SaveCNamazCounter(i);

            kazaCountersText[i].text = Toolbox.Instance.userPrefs.cNamazCounter[i].ToString();
        }        
    }
}
