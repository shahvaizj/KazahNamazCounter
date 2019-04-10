using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems {
	public static string scenePath = "Assets/-Scenes/Intro.unity";

	[MenuItem("GIFS/Play Intro #F1")]
	private static void NewMenuOption1(){
		
		EditorApplication.SaveCurrentSceneIfUserWantsTo(); 
		EditorApplication.OpenScene(scenePath);
		EditorApplication.isPlaying = true;
	}

	[MenuItem("GIFS/Clear PlayerPrefs")]
	private static void NewMenuOption2(){
	
		PlayerPrefs.DeleteAll ();
	}
}
