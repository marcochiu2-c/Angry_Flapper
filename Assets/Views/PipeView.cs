using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;


public partial class PipeView{
	private int playtime;
	public override void Awake(){
		base.Awake();
		this.transform.position = new Vector3(12f, UnityEngine.Random.Range(-2.3f, 4.11f));
	}

	public override void Start ()
	{	
		if(Pipe.ParentAngryFlappersGame != null)
			playtime = Pipe.ParentAngryFlappersGame.Try;
		Debug.Log (playtime);
		base.Start ();

	}

	public void OnTriggerExit2D(Collider2D other){
		ExecutePassed ();
	}
	
	public void Update(){
		if (Pipe != null && Pipe.ParentAngryFlappersGame.State == AngryFlappersGameState.Playing) {
			this.transform.position -= Vector3.right * Pipe.ParentAngryFlappersGame.ScrollSpeed * Time.deltaTime;
			if (this.transform.position.x < -15f || playtime != Pipe.ParentAngryFlappersGame.Try) {
				gameObject.SetActive (false);
				ExecuteRemoveFromScreen ();
				Destroy (gameObject);
			}
		}
	}
}