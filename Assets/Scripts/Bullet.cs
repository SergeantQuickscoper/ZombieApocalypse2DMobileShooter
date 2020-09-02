using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 230;
    public int BulletDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        if(collision.CompareTag("Enemy"))
        {
            Enemy HitEnemy = collision.gameObject.GetComponent<Enemy>();
            HitEnemy.DamageEnemy(BulletDamage);
            Instantiate(HitEnemy.EnemyHitParicles, transform.position, Quaternion.identity);

        }
    }
}
