using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TweenMovementInspectorButton))]
public class ObjectBuilderEditor2 : Editor{

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		TweenMovementInspectorButton myScript = (TweenMovementInspectorButton)target;

		if(GUILayout.Button("Set Target Pos"))
		{
			myScript.SetCurPosAsTargetPosition ();
		}

	}
}
