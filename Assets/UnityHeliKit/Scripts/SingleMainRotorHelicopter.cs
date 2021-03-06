﻿using UnityEngine;
using HeliSharp;

public class SingleMainRotorHelicopter : Helicopter {

    public override HeliSharp.Helicopter model { get { return _model; } }
    public HeliSharp.SingleMainRotorHelicopter _model { get; set; }

    public Rotor mainRotor;
	public Rotor tailRotor;
	public Stabilizer horizontalStabilizer;
	public Stabilizer verticalStabilizer;

    public SingleMainRotorHelicopter() {
		_model = new HeliSharp.SingleMainRotorHelicopter ();
	}

    public override void FixedUpdate () {
		if (body == null) return;

        base.FixedUpdate();
        /*
        if (debugText != null) {
			string text = "";
			text += "WASH " + Mathf.Round((float)_model.MainRotor.WashVelocity.Norm(2)) + "\n";
			debugText.text += text;
		}
        */
    }

	public override void ParametrizeUnityFromModel() {
        base.ParametrizeUnityFromModel();
		mainRotor = _model.MainRotor;
		tailRotor = _model.TailRotor;
		horizontalStabilizer = _model.HorizontalStabilizer;
		verticalStabilizer = _model.VerticalStabilizer;
	}

	public override void ParametrizeModelsFromUnity() {
	    model.LoadDefault();
	    _model.MainRotor = mainRotor;
	    _model.TailRotor = tailRotor;
	    _model.HorizontalStabilizer = horizontalStabilizer;
	    _model.VerticalStabilizer = verticalStabilizer;
	    base.ParametrizeModelsFromUnity();
	}
}
