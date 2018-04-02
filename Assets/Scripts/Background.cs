using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class shifts the texture of the background in order to make it seem like its moving
public class Background : MonoBehaviour {

	public float speed=0;
	private float _size;
	private Vector3 _initialPosition;

	void Start(){
		_size = transform.lossyScale.x;
		_initialPosition = transform.position;
	}
	void Update () {
		transform.position += new Vector3((-Time.deltaTime*speed), 0f, 1f);
		if (transform.position.x < _initialPosition.x - _size)
			transform.position = _initialPosition;
	}
}