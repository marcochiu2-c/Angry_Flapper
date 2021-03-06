using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using DG.Tweening;


public partial class BirdView {
	public Camera Cam;
	/// Subscribes to the property and is notified anytime the value changes.
    public override void StateChanged(BirdState value) {
        base.StateChanged(value);
		if (value == BirdState.Alive) {
			gameObject.SetActive(true);
			this.transform.position = Vector3.zero;
			Cam.transform.position = new Vector3(0, 0, -10);
		}
		//else if (value == BirdState.Dea) {
		//	this.transform.position = Vector3.zero;
		//}
    }

	public void OnTriggerEnter2D(Collider2D other){
		if (!other.gameObject.IsView<PipeView> ()) {
			ExecuteHit ();

			//Shake Carmera
			Tweener tweener = Cam.transform.DOShakePosition (1f);
		}
	}
	
	private Vector3 _Velocity = Vector3.zero;
	private bool _didFlap = false;
	private float angle;

	public void FixedUpdate(){

		if (Bird.State != BirdState.Alive) {
			_Velocity += new Vector3 (0f, Bird.ParentAngryFlappersGame.Gravity, 0f) * Time.deltaTime;
			transform.position += _Velocity * Time.deltaTime;

			angle = _Velocity.y < 0 ? Mathf.Lerp (0f, -90, -_Velocity.y / Bird.MaxSpeed) : 0;
			transform.rotation = Quaternion.Euler (0f, 0f, angle);

			if(transform.position.y < -8)
				gameObject.SetActive(false);
			
		}
		if (Bird.ParentAngryFlappersGame.State != AngryFlappersGameState.Playing)
			return;

		_Velocity += new Vector3 (0f, Bird.ParentAngryFlappersGame.Gravity, 0f) * Time.deltaTime;

		if (_didFlap) {
			_didFlap = false;
			_Velocity += new Vector3(0f, Bird.FlapVelocity, 0f);
		}

		_Velocity = Vector3.ClampMagnitude (_Velocity, Bird.MaxSpeed);
		transform.position += _Velocity * Time.deltaTime;

		angle = _Velocity.y < 0 ? Mathf.Lerp (0f, -70f, -_Velocity.y / Bird.MaxSpeed) : 0;
		transform.rotation = Quaternion.Euler (0f, 0f, angle);
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			_didFlap = true;
		}
	}
}
