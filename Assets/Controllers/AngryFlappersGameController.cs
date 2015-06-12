using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class AngryFlappersGameController : AngryFlappersGameControllerBase {

    public override void InitializeAngryFlappersGame(AngryFlappersGameViewModel angryFlappersGame) {
    }

	public override void Play (AngryFlappersGameViewModel angryFlappersGame)
	{
		base.Play (angryFlappersGame);
		angryFlappersGame.Pipes.Clear();
		angryFlappersGame.State = AngryFlappersGameState.Playing;
		angryFlappersGame.Score = 0;
		angryFlappersGame.Bird.State = BirdState.Alive;
		angryFlappersGame.Try++;
		StartCoroutine(SpawnPipes());
	}

	public IEnumerator SpawnPipes(){
		while (AngryFlappersGame.State == AngryFlappersGameState.Playing) {
				AngryFlappersGame.Pipes.Add(new PipeViewModel(PipeController));
				yield return new WaitForSeconds(AngryFlappersGame.PipeSpawnSeed);
			}
		}

	public override void GameOver (AngryFlappersGameViewModel angryFlappersGame)
	{
		base.GameOver (angryFlappersGame);
		angryFlappersGame.State = AngryFlappersGameState.GameOver;
		PlayerPrefs.SetInt ("score", angryFlappersGame.Score);
		StopAllCoroutines ();
	}
}