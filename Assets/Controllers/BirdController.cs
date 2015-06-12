using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class BirdController : BirdControllerBase {

    public override void InitializeBird(BirdViewModel bird) {
    }

	public override void Hit (BirdViewModel bird)
	{
		base.Hit (bird);
		bird.State = BirdState.Dead;
		AngryFlappersGameController.GameOver (AngryFlappersGame);
	}
}
