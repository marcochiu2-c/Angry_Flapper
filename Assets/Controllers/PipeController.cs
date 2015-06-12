using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class PipeController : PipeControllerBase {
    
    public override void InitializePipe(PipeViewModel pipe) {
    }

	public override void Passed (PipeViewModel pipe)
	{
		base.Passed (pipe);
		pipe.ParentAngryFlappersGame.Score++;
	}

	public override void RemoveFromScreen (PipeViewModel pipe)
	{
		base.RemoveFromScreen (pipe);
		pipe.ParentAngryFlappersGame.Pipes.Remove (pipe);
	}
}
