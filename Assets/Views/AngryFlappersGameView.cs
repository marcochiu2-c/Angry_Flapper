using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UnityEngine.UI;


public partial class AngryFlappersGameView { 

	public Text _ScoreLabel;
	public Text  _FinalScoreLabel;
    /// Subscribes to the property and is notified anytime the value changes.
    public override void ScoreChanged(Int32 value) {
		base.ScoreChanged (value);
		_ScoreLabel.text = string.Format ("儲蓄: HKD{0}", value);
		_FinalScoreLabel.text = string.Format ("儲蓄: HKD{0}", value);

	}

    // This binding will add or remove views based on an element/viewmodel collection.
    public override ViewBase CreatePipesView(PipeViewModel item) {
        return base.CreatePipesView(item);
    }
    
    // This binding will add or remove views based on an element/viewmodel collection.
    public override void PipesAdded(ViewBase item) {
        base.PipesAdded(item);
    }
    
    /// This binding will add or remove views based on an element/viewmodel collection.
    public override void PipesRemoved(ViewBase item) {
        base.PipesRemoved(item);
		Destroy (item.gameObject);
	}

	public Transform _MenuDisplay;
	public Transform _GameOverDisplay;
	public Transform _HudDisplay;

    /// Subscribes to the property and is notified anytime the value changes.
    public override void StateChanged(AngryFlappersGameState value) {
        base.StateChanged(value);

		_MenuDisplay.gameObject.SetActive (value == AngryFlappersGameState.Menu || value == AngryFlappersGameState.GameOver);
		_GameOverDisplay.gameObject.SetActive (value == AngryFlappersGameState.GameOver);
		_HudDisplay.gameObject.SetActive (value == AngryFlappersGameState.Playing);
    }

	public void StartTheGame(){
		if (AngryFlappersGame.State == AngryFlappersGameState.Menu || AngryFlappersGame.State == AngryFlappersGameState.GameOver) 
			ExecutePlay ();
		}
}
 