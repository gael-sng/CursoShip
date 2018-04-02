using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Utilities {

    public Camera MainCamera;

    public Image HealthBar;
    public Text HealthText;
    private int _maxHP;

    public int Score;
    public Text ScoreText;

    public Transform Player;
    private CharacterController _cc;
    public bool GameOver = false;
    public Text GameOverText;

	// Use this for initialization
	void Start () {
        _cc = Player.GetComponent<CharacterController>();
        _maxHP = _cc.HitPoints;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();

        if (GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
	}

    void UpdateUI()
    {
        HealthBar.transform.localScale = new Vector3(((float)_cc.HitPoints) / 100f, 1, 1);
        HealthText.text = string.Concat(_cc.HitPoints, " / ", _maxHP);
        ScoreText.text = string.Concat("Score ", Score);

        if (GameOver)
        {
            GameOverText.gameObject.SetActive(true);
        }
    }
}
