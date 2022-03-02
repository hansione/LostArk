using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy
{
    public enum BossState
    {
        Turm,
        Run,
        Attack,
        Die
    }

    public enum BossAttackType
    {
        Attack1,
        ATtack2
    }

    public BossState bState;
    BossAttackType bAttackType;

    public GameObject range;

    // Start is called before the first frame update
    void Start()
    {
        SetStart();

        bState = BossState.Turm;

        attackDistance = 4f;
        attackDamage = 10f;
        hp = maxHp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        switch (bState)
        {
            case BossState.Turm:
                turm();
                break;

            case BossState.Run:
                run();
                break;

            case BossState.Attack:
                attack();
                break;

            case BossState.Die:
                die();
                break;

            default:
                break;
        }

        setHpBar();
    }

    void setHpBar()
    {
        hpBar.value = hp / maxHp;
    }

    void turm()
    {
        if(anim.GetNextAnimatorStateInfo(0).IsName("Run"))
        {
            bState = BossState.Run;
        }
    }
    
    void run()
    {
        if(Vector3.Distance(player.position, transform.position) < attackDistance)
        {
            bState = BossState.Attack;

            attackPathern();
        }
        else
        {
            agent.stoppingDistance = attackDistance;
            agent.ResetPath();

            agent.SetDestination(player.position);
        }

    }

    void attackPathern()
    {
        attackCount++;

        switch (attackCount)
        {
            case 1:
            case 2:
                isAttack = true;
                attackDamage = 20;

                anim.SetTrigger("Attack1");
                break;

            case 3:
                attackDamage = 50;
                attackCount = 0;

                StartCoroutine(attachRange());

                anim.SetTrigger("Attack2");
                anim.speed /= 2;
                break;
        }
    }

    IEnumerator attachRange()
    {
        isAttack = false;
        range.SetActive(true);

        yield return new WaitForSeconds(2.4f);
        isAttack = true;

        yield return new WaitForSeconds(0.3f);
        range.SetActive(false);
        
    }

    void attack()
    {
        if (anim.GetNextAnimatorStateInfo(0).IsName("Turm"))
        {
            isAttack = false;
            bState = BossState.Turm;
            anim.speed = 1;
        }
    }

    override public void Damaged(float damage)
    {
        if(bState == BossState.Die)
        {
            return;
        }

        hp -= damage;

        if (hp <= 0)
        {
            bState = BossState.Die;
            anim.SetTrigger("Die");
        }

    }

    void die()
    {
        UIManager.Instance.ResultImage();
    }
}
