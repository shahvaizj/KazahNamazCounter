using UnityEngine;
using System.Collections;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {} // guarantee this will be always a singleton only - can't use the constructor!

	public SoundManager soundManager;
	public UserPrefs userPrefs;
	public GameManager gameManager;
	public Constants constants;
	public GooglePlayServicesManager googleServicesManager;
//	public FBManager facebookManager;

	void Awake () {
		// Your initialization code here
		GameObject.DontDestroyOnLoad(this.gameObject);
	}
}