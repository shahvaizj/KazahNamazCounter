using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PKazaNamazMenuEventListner : MonoBehaviour {
    
    public Text [] kazaCountersText;
    
    public void Start() {

        for(int i = 0; i < kazaCountersText.Length; i++) {

            kazaCountersText[i].text = Toolbox.Instance.userPrefs.pNamazCounter[i].ToString();
        }
    }

    public void OnPressPlusButton(int i) {

        Toolbox.Instance.userPrefs.pNamazCounter[i]++;
        Toolbox.Instance.userPrefs.SavePNamazCounter(i);

        kazaCountersText[i].text = Toolbox.Instance.userPrefs.pNamazCounter[i].ToString();
    }

    public void OnPressMinusButton(int i) {

        if(--Toolbox.Instance.userPrefs.pNamazCounter[i] >= 0) {

            Toolbox.Instance.userPrefs.SavePNamazCounter(i);

            kazaCountersText[i].text = Toolbox.Instance.userPrefs.pNamazCounter[i].ToString();
        }
        
    }
}
