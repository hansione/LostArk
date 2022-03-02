using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Skeleton : Enemy
{
    enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Init,
        Damaged,
        Die
    }

    EnemyState eState;


    float findDistance = 6f;

    float currentTime = 0f;
    float attackDelay = 2.5f;

    Vector3 originPos;
    Quaternion originRot;
    public float chaseMaxDistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        SetStart();
        attackCount = 1;

        eState = EnemyState.Idle;

        attackDistance = 1.7f;
        attackDamage = 10;
        hp = maxHp = 100;

        originPos = transform.position;
        originRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (eState)
        {
            case EnemyState.Idle:
                idle();
                break;

            case EnemyState.Chase:
                chase();
                break;

            case EnemyState.Attack:
                attack();
                break;

            case EnemyState.Init:
                init();
                break;

            case EnemyState.Damaged:
                damaged();
                break;

            case EnemyState.Die:
                break;

            default:
                break;
        }

        setHpBar();
    }

    void setHpBar()
    {
        hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.8f);

        hpBar.value = hp / maxHp;
    }

    void idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            eState = EnemyState.Chase;
            anim.SetBool("Chase", true);
        }
    }

    void chase()
    {
        if(Vector3.Distance(transform.position, player.position) > chaseMaxDistance)
        {
            eState = EnemyState.Init;
        }
        else if(Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            agent.isStopped = true;
            agent.ResetPath();

            agent.stoppingDistance = attackDistance;
            agent.destination = player.position;
        }
        else
        {
            eState = EnemyState.Attack;
            isAttack = true;
            anim.SetBool("Attack", true);
        }
    }

    void attack()
    {
        if(Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;

            if(currentTime > attackDelay)
            {
                isAttack = true;
                currentTime = 0f;
                anim.SetTrigger("ReAttack");
                transform.forward = player.position - transform.position;
            }
        }
        else
        {
            anim.SetBool("Attack", false);

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                eState = EnemyState.Chase;
                currentTime = 0f;
            }
        }
    }

    void init()
    {
        if(Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            agent.destination = originPos;
            agent.stoppingDistance = 0f;
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();

            transform.position = originPos;
            transform.rotation = originRot;
            eState = EnemyState.Idle;

            anim.SetBool("Chase", false);
        }
    }

    void damaged()
    {
        if (anim.GetNextAnimatorStateInfo(0).IsName("Chase"))
        {
            anim.SetBool("Attack", false);
            currentTime = 0;
            eState = EnemyState.Chase;
        }
    }

    override public void Damaged(float damage)
    {
        if (eState == EnemyState.Die || eState == EnemyState.Init)
        {
            return;
        }

        hp -= damage;

        agent.ResetPath();

        if (hp > 0)
        {
            eState = EnemyState.Damaged;
            anim.SetTrigger("Damage");
        }
        else
        {
            eState = EnemyState.Die;
            die();
        }

    }

    void die()
    {
        anim.SetTrigger("Die");
        hpBar.gameObject.SetActive(false);
    }

}
