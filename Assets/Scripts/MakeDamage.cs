using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public Animator animatorEnemy;
    public EnemyLife enemyLife;
    public int pointsDamage = 10;

    public void DamageFunction()
    {
        animatorEnemy.SetBool("IsDamaging",true);
        enemyLife.UpdateLifePoints(pointsDamage);
    }
}
