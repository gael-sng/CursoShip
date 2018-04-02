using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour2 : Utilities {
	public GameObject Bullet;
    public Transform Target;

    public GameManager gm;

	public int HitPoints;
    public int ScoreValue = 100;
	public float BulletSpeed;
	public int BulletDamage;

    public float MovementDelay;
    private float _movementTime;
    public float FireRate;
    private float _bulletTime;
	private Rigidbody2D _rigid;
	private Vector2 _destination;

	public GameObject Explosion;

	public float Speed;
	// Use this for initialization
	void Start () {
		ChoseRandomDestinantion ();
		_movementTime = 0;
		_rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		_movementTime += Time.deltaTime;
		_bulletTime += Time.deltaTime;

		if (_movementTime > MovementDelay) {
			_movementTime = 0f;
			ChoseRandomDestinantion ();
		}
		if (_bulletTime >= 1 / FireRate)
		{
			_bulletTime = 0;
			Shoot();
		}
		Move ();
		Rotate ();
	}


	private void ChoseRandomDestinantion (){
		float x = Random.Range (GetMinHorizontalPosition () + 0.5f, GetMaxHorizontalPosition () - 0.5f);
		float y = Random.Range (GetMinVerticalPosition () + 0.5f, GetMaxVerticalPosition () - 0.5f);
		_destination = new Vector2 (x, y);
	}

	private void Move(){
		Vector2 targetDir = _destination - (Vector2)transform.position;
		if (targetDir.magnitude > 0.1f) {
			_rigid.velocity = targetDir * Speed;
		} else {
			_rigid.velocity = Vector2.zero;
		}
	}

	private void Rotate (){
		//point the barrel to the Target, by rotating the enemy
		if(Target != null){
			Vector3 targetDir = Target.position - transform.position;
			float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, 0, angle - 90f);
		}
	}

	private void Shoot()
	{
		GameObject bullet = Instantiate(Bullet, transform.position + (Vector3)transform.up, transform.rotation);
		BulletBehaviour bc = bullet.GetComponent<BulletBehaviour>();
		bc.Velocity = transform.up * BulletSpeed;
		bc.Damage = BulletDamage;
	}

	public void Hit(int damage)
	{
		HitPoints -= damage;
		if (HitPoints <= 0)
		{
			if(Explosion != null)Instantiate(Explosion,transform.position, transform.rotation);

            gm.Score += ScoreValue;
			Destroy(gameObject);
		}
	}
}
