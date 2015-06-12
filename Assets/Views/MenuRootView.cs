using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public partial class MenuRootView { 

	public Text _ScoreLabel;
	//public Text _ScoreLabel2;
    /// Subscribes to the property and is notified anytime the value changes.
    public override void ScoreChanged(Int32 value) {
        base.ScoreChanged(value);
		_ScoreLabel.text = string.Format ("PlayerPrefs Score: {0}", PlayerPrefs.GetInt("score"));
		//_ScoreLabel2.text = string.Format ("PlayerPrefs Score: {0}", );

    }

}
