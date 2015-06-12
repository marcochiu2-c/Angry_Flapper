using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using DG.Tweening;


public partial class CamView { 

    /// Subscribes to the property and is notified anytime the value changes.
    public override void StateChanged(CamState value) {
		Debug.Log ("CamViewStateChanged");
        base.StateChanged(value);
		if (value == CamState.GameOver) {
			this.transform.position = CamPosition + Vector3.right * 0.2f;
			Tweener tweener = this.transform.DOShakePosition(1f);
		}
    }
 
	Vector3 CamPosition;
	
	public void Start (){
		//base.Start ();
		CamPosition = this.transform.position;
	}
	/*
	public override void Update ()
	{
		if (Cam.State == CamState.GameOver) {
			this.transform.position = CamPosition + Vector3.right * 0.2f;
			Tweener tweener = this.transform.DOShakePosition(1f);
	}

	}
*/

}
	