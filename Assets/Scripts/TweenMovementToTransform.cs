using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMovementToTransform : MonoBehaviour {

	[Header("Movement In Start")]
	public bool enableInStart = false;
	public float startDelay;


	public enum State{
		REACHPOINT
	}; 

	[Header("Other")]
	public State state;

	public bool neverStop = true;
//	public bool takeLocalPos = true;
	public Transform target;

	Vector3 finalTargetPos;
	Vector3 startPosition;

	public float speed = 0.05f;

	[Header("Loop State Specific")]
	int curcycle = 0;
	public int cycle = 0;

	bool enableMovement = false;
	bool targetSwich = false;

	[Header("Random Generate Value")]
	public float minRandDelay = 0;
	public float maxRandDelay = 1;

	[Header("Fixed Generate Value")]
	public float maxFixedDelay = 1;

//	[Header("Custom Editor Options")]
//	public bool setX = true;
//	public bool setY = true;
//	public bool setZ = true;


	void Start(){

		startPosition = this.transform.position;

		if (enableInStart) {
		
			Invoke ("StartMovement", startDelay);
		}
	}

	public void StartMovementwithRandromDelay(){

		float rand = Random.Range (minRandDelay, maxRandDelay);

		Invoke ("StartMovement", rand);
	}

	public void StartMovementwithFixedDelay(){

		Invoke ("StartMovement", maxFixedDelay);
	}

	void StartMovement(){

		enableMovement = true;
	}

	void Update(){
		

		if (!enableMovement) {
		
			return;
		}
			

		switch (state) {

		case State.REACHPOINT:

			ReachPointMovement ();

			return;

		}


	}

	void ReachPointMovement(){	

		this.transform.position = Vector3.Slerp (this.transform.position, target.position, speed);

		if (this.transform.position == target.position && !neverStop) {

			enableMovement = false;
		}
	
	}


}
