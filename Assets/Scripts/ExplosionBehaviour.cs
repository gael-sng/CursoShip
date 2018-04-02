using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {
	private float _timeCounter;
	public float Duration;
	// Use this for initialization
	void Start () {
		if (Duration <= 0.0f)
			Duration = 1.0f;
		_timeCounter = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		_timeCounter += Time.deltaTime;
		if (_timeCounter >= Duration)
			GameObject.Destroy (gameObject);
	}
}
