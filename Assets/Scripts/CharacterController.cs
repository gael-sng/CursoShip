using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private Rigidbody2D _rigid;
    public GameObject Bullet;

    public int HitPoints;
    public float MoveSpeed;
    public float BulletSpeed;
    public int BulletDamage;

    private bool _isShooting;
    private float _time;
    public float FireRate;

    public GameObject GameManager;
    public GameObject Explosion;

	// Use this for initialization
	void Start () {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        Move();
        _time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isShooting = false;
        }

        if (_isShooting)
        {
            if (_time >= 1/FireRate)
            {
                _time = 0;
                Shoot();
            }            
        }
	}

    void Move()
    {
        _rigid.velocity = new Vector2(MoveSpeed*Input.GetAxis("Horizontal"), MoveSpeed*Input.GetAxis("Vertical"));
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, transform.position + new Vector3(1.5f, 0, 0), transform.rotation);
        BulletBehaviour bc = bullet.GetComponent<BulletBehaviour>();
        bc.Velocity = transform.up * BulletSpeed;
        bc.Damage = BulletDamage;
    }

    public void Hit(int damage)
    {
        HitPoints -= damage;
        if(HitPoints <= 0)
        {
            if (Explosion != null) Instantiate(Explosion, transform.position, transform.rotation);
            GameManager.GetComponent<GameManager>().GameOver = true;
            Destroy(gameObject);
        }
    }

}
