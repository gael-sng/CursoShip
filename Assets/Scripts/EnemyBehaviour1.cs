using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour1 : MonoBehaviour {

    private Rigidbody2D _rigid;
    public GameObject Bullet;
	public Transform Target;

    public GameManager gm;

    public int HitPoints;
    public int ScoreValue = 50;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float ChaseRange;
    public float BulletSpeed;
    public int BulletDamage;

    private float _time;
    public float FireRate;
	public GameObject Explosion;

    private float _targetPosition;

	// Use this for initialization
	void Start () {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null)
        {
            _targetPosition = Target.position.y;
        }

        Move();
        if (_time >= 1 / FireRate)
        {
            _time = 0;
            Shoot();
        }
        _time += Time.deltaTime;
    }

    void Move()
    {
        if (_targetPosition > transform.position.y +ChaseRange)
        {
            _rigid.velocity = new Vector3(-HorizontalSpeed, VerticalSpeed, 0);
        }
        else if(_targetPosition < transform.position.y -ChaseRange)
        {
            _rigid.velocity = new Vector3(-HorizontalSpeed, -VerticalSpeed, 0);
        }
        else
        {
            _rigid.velocity = new Vector3(-HorizontalSpeed, 0, 0);
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
			if(Explosion != null)Instantiate(Explosion, transform.position, transform.rotation);
            gm.Score += ScoreValue;
            Destroy(gameObject);
        }
    }

}
