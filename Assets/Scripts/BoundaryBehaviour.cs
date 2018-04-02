using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour {

	public float BoundaryPositionOffset = 0.5f;
	private float _boundaryScaleOffset;

	// Use this for initialization
	void Start () {

		_boundaryScaleOffset = (BoundaryPositionOffset + 0.5f) *2;

		if (gameObject.name == "BoundaryU") {
			gameObject.transform.position = new Vector2 (0.0f, Utilities.GetMaxVerticalPosition() + BoundaryPositionOffset);
			gameObject.transform.localScale = new Vector2 ( Utilities.GetMaxHorizontalPosition () -  Utilities.GetMinHorizontalPosition () + _boundaryScaleOffset, 1.0f);
		} else if (gameObject.name == "BoundaryR") {
			gameObject.transform.position = new Vector2 ( Utilities.GetMaxHorizontalPosition() + BoundaryPositionOffset, 0.0f);
			gameObject.transform.localScale = new Vector2 (1.0f,  Utilities.GetMaxVerticalPosition() -  Utilities.GetMinVerticalPosition() + _boundaryScaleOffset);
		} else if (gameObject.name == "BoundaryD") {
			gameObject.transform.position = new Vector2 (0.0f,  Utilities.GetMinVerticalPosition() - BoundaryPositionOffset);
			gameObject.transform.localScale = new Vector2 ( Utilities.GetMaxHorizontalPosition () -  Utilities.GetMinHorizontalPosition () + _boundaryScaleOffset, 1.0f);
		} else if (gameObject.name == "BoundaryL") {
			gameObject.transform.position = new Vector2 ( Utilities.GetMinHorizontalPosition() - BoundaryPositionOffset, 0.0f);
			gameObject.transform.localScale = new Vector2 (1.0f,  Utilities.GetMaxVerticalPosition() -  Utilities.GetMinVerticalPosition() + _boundaryScaleOffset);
		} else {
			Debug.Log("ERRO!! uma bondary esta com nome errado");
			GameObject.Destroy (gameObject);
		}
	}
}
