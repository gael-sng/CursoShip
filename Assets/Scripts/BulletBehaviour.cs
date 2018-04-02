using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    private Rigidbody2D rigid;

    public Vector2 Velocity;
    public int Damage = 10;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Velocity;
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "EnemyBullet" && other.tag != "PlayerBullet")
        {
            if (other.tag == "Player" && tag == "EnemyBullet")
            {
                CharacterController cc = other.GetComponent<CharacterController>();
                cc.Hit(Damage);
                Destroy(gameObject);
            }
            if(other.tag == "Enemy1" && tag == "PlayerBullet")
            {
                EnemyBehaviour1 eb = other.GetComponent<EnemyBehaviour1>();
                eb.Hit(Damage);
                Destroy(gameObject);
            }
			if(other.tag == "Enemy2" && tag == "PlayerBullet")
			{
				EnemyBehaviour2 eb = other.GetComponent<EnemyBehaviour2>();
				eb.Hit(Damage);
				Destroy(gameObject);
			}
        }
    }
}
