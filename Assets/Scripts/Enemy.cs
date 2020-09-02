using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    public class EnemyStats
    {
        public int MaxEnemyHealth = 100; 
        private int EnemyHealth = 100;
          public int GetCurrentHealth
        {
            get { return EnemyHealth; }
            set { EnemyHealth = Mathf.Clamp(value, 0, MaxEnemyHealth); }
        }

    }

     EnemyStats EnemyStatsInstance = new EnemyStats();
     public Transform EnemyHitParicles;
     public Transform EnemyDeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int Damage)
    {
        EnemyStatsInstance.GetCurrentHealth = EnemyStatsInstance.GetCurrentHealth - Damage;
        if(EnemyStatsInstance.GetCurrentHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }


    }
}
