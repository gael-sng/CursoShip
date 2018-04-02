using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Utilities {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public List<GameObject> EnemyList;

    public Transform Target;
    public GameManager gm;

    private float _spawnPosX;
    private float _spawnPosY;

    private float _time;
    public float SpawnDelay;

    void Start()
    {
        EnemyList = new List<GameObject>();
        EnemyList.Add(Enemy1);
        EnemyList.Add(Enemy2);
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
		if (_time >= SpawnDelay)
        {
			if(Target != null)Spawn();
            _time = 0;
        }
        _time += Time.deltaTime;
    }

    void Spawn()
    {
        _spawnPosX = GetMaxHorizontalPosition() + 1.5f;
        _spawnPosY = Random.Range(GetMinVerticalPosition(), GetMaxVerticalPosition());

        int number = Random.Range(0, 2);

        GameObject enemy = (GameObject)Instantiate(EnemyList[number], new Vector3(_spawnPosX, _spawnPosY, 0), Quaternion.identity);
        enemy.transform.Rotate(0, 0, 90f);

        if (enemy.tag == "Enemy1") {
            enemy.GetComponent<EnemyBehaviour1>().Target = Target;
            enemy.GetComponent<EnemyBehaviour1>().gm = gm;
        }
        else if (enemy.tag == "Enemy2")
        {
            enemy.GetComponent<EnemyBehaviour2>().Target = Target;
            enemy.GetComponent<EnemyBehaviour2>().gm = gm;
        }
    }
}
