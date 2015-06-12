using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class CamController : CamControllerBase {
    
    public override void InitializeCam(CamViewModel cam) {
    }
	/*
	public override void Shake (CamViewModel cam)
	{
		base.Shake (cam);
		cam.State = CamState.GameOver;
		Debug.Log(cam.State);
	}
	*/
}
