using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Animator anim;
    protected Transform player;

    protected float attackDistance;

    protected float attackDamage;

    protected int attackCount = 0;

    [SerializeField]
    protected Slider hpBar;
    protected float hp;
    protected float maxHp;

    protected bool isAttack = false;

    public void SetStart()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Skill"))
        {
            other.tag = "Untagged";

            Skill skill = player.gameObject.GetComponent<Skill>();            
            Damaged(skill.skillSet[skill.skillNum].damage);
        }

        if (isAttack)
        {
            isAttack = false;
            if (other.tag.Equals("Player"))
            {
                if (attackCount != 0)
                {
                    other.GetComponent<Player>().Damaged(attackDamage, 1);
                }
                else
                {
                    other.GetComponent<Player>().Damaged(attackDamage, 2);
                }
            }
        }

        
    }

    virtual public void Damaged(float damage) { }

}
