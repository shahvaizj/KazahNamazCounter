using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public bool lookAtTarget = false;

	public enum CamState{
		REST,
		DEFAULTVIEW,
		CHANGEVIEW
	}; 

	public CamState camState;

	public GameObject target;

	public Transform camTransform;
	public Transform defaultCamTransform;
	public Transform [] viewPoints;

	private Vector3 offset;

	public float followSpeed = 1;
	public float startingChangePosSpeed = 1;
	public float changePosSpeed = 1;

	public int curViewPoint = 0;

	bool positionInPlace = false;
	bool rotationInPlace = false;

	void Start () {
		
		offset = transform.position - target.transform.position;
		startingChangePosSpeed = changePosSpeed;
	}

	void FixedUpdate () {

		if (target) {

			this.transform.position = Vector3.Lerp (this.transform.position, target.transform.position + offset, followSpeed);

			if(lookAtTarget)
				transform.LookAt (target.transform);


			switch (camState) {

			case CamState.REST:

				break;

			case CamState.DEFAULTVIEW:

				DefaultView ();

				break;

			case CamState.CHANGEVIEW:

				ChangeView ();

				break;


			}
		}
	}

	void DefaultView(){

		camTransform.position = Vector3.Lerp (this.camTransform.position, defaultCamTransform.position , changePosSpeed);
		camTransform.rotation = Quaternion.Slerp (this.camTransform.rotation, defaultCamTransform.rotation, changePosSpeed);

		if (this.camTransform.position == defaultCamTransform.position) {

			positionInPlace = true;
		}

		if (this.camTransform.rotation == defaultCamTransform.rotation) {

			rotationInPlace = true;
		}

		if (positionInPlace && rotationInPlace) {

			Set_RestState ();
			positionInPlace = false;
			rotationInPlace = false;
		}
	}

	void ChangeView(){
	
		camTransform.position = Vector3.Lerp (this.camTransform.position, viewPoints[curViewPoint].position , changePosSpeed);
		camTransform.rotation = Quaternion.Slerp (this.camTransform.rotation, viewPoints[curViewPoint].rotation, changePosSpeed);

		if (this.camTransform.position == viewPoints [curViewPoint].position) {
		
			positionInPlace = true;
		}

		if (this.camTransform.rotation == viewPoints [curViewPoint].rotation) {

			rotationInPlace = true;
		}

		if (positionInPlace && rotationInPlace) {
		
			Set_RestState ();
			positionInPlace = false;
			rotationInPlace = false;
		}
	}

	public void Set_RestState(){

		camState = CamState.REST;
	}

	public void Set_DefaultState(){

		Set_DefaultChangePosSpeed ();

		camState = CamState.DEFAULTVIEW;
	}

	public void Set_ChangeViewState(int view){

		curViewPoint = view;
		camState = CamState.CHANGEVIEW;
	}

	public void Set_DefaultChangePosSpeed(){

		changePosSpeed = startingChangePosSpeed;
	}

	public void Set_ChangePosSpeed(float speed){

		changePosSpeed = speed;
	}


}
