using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneBehaviour : Utilities {

    public float KillzonePositionOffset = 3;
    private float _killzoneScaleOffset;

    void Start()
    {

        _killzoneScaleOffset = (KillzonePositionOffset + 0.5f) * 2;

        if (gameObject.name == "KillzoneU")
        {
            gameObject.transform.position = new Vector2(0.0f, GetMaxVerticalPosition() + KillzonePositionOffset);
            gameObject.transform.localScale = new Vector2(GetMaxHorizontalPosition() - GetMinHorizontalPosition() + _killzoneScaleOffset, 1.0f);
        }
        else if (gameObject.name == "KillzoneR")
        {
            gameObject.transform.position = new Vector2(GetMaxHorizontalPosition() + KillzonePositionOffset, 0.0f);
            gameObject.transform.localScale = new Vector2(1.0f, GetMaxVerticalPosition() - GetMinVerticalPosition() + _killzoneScaleOffset);
        }
        else if (gameObject.name == "KillzoneD")
        {
            gameObject.transform.position = new Vector2(0.0f, GetMinVerticalPosition() - KillzonePositionOffset);
            gameObject.transform.localScale = new Vector2(GetMaxHorizontalPosition() - GetMinHorizontalPosition() + _killzoneScaleOffset, 1.0f);
        }
        else if (gameObject.name == "KillzoneL")
        {
            gameObject.transform.position = new Vector2(GetMinHorizontalPosition() - KillzonePositionOffset, 0.0f);
            gameObject.transform.localScale = new Vector2(1.0f, GetMaxVerticalPosition() - GetMinVerticalPosition() + _killzoneScaleOffset);
        }
        else {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.CompareTag("Enemy1") || other.CompareTag("Enemy2") || other.CompareTag("PlayerBullet") || other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
