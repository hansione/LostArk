using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Roll,
        Attack,
        Damaged,
        Down,
        Die
    }

    public PlayerState pState;
    Vector3 moveDir;
    RaycastHit hit;

    Camera camera;
    public NavMeshAgent agent;
    Animator anim;
    Skill skill;

    public float attackDamage = 15;
    bool isAttack = false;

    public Slider hpBar;
    public float hp = 100;
    float maxHp = 100;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("BossZoneTrigger"))
        {
            other.gameObject.GetComponent<BossTrigger>().isBoss = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Wall"))
        {
            agent.stoppingDistance = 2f;
            agent.isStopped = true;
            agent.ResetPath();
        }

        if (pState == PlayerState.Attack)
        {
            print(other.gameObject);
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().Damaged(attackDamage);
            }
        }
    }

    private void Awake()
    {
        Player[] obj = FindObjectsOfType<Player>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (obj.Length != 1)
        {
            obj[0].gameObject.transform.position = new Vector3(0f, 0f, -12.39f);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.updateRotation = false;
        skill = GetComponent<Skill>();

        pState = PlayerState.Idle;

    }


    // Update is called once per frame
    void Update()
    {
        anyState();

        switch (pState)
        {
            case PlayerState.Idle:
                idle();
                break;

            case PlayerState.Walk:
                walk();
                break;

            case PlayerState.Roll:
                reState();
                break;

            case PlayerState.Attack:
                reState();
                break;

            case PlayerState.Damaged:
                reState();
                break;

            case PlayerState.Down:
                reState();
                break;

            case PlayerState.Die:

                break;
        }

        setHpBar();

        if (!CharacterStart.isStart) agent.ResetPath();
    }

    void setHpBar()
    {
        hpBar.value = hp / maxHp;
    }

    // 마우스 좌표
    void setDestination()
    {
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            agent.SetDestination(hit.point);
        }

        moveDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
        transform.forward = moveDir;
    }

    void anyState()
    {
        if (pState != PlayerState.Roll && Input.GetKeyDown(KeyCode.Space))
        {
            if (pState != PlayerState.Die)
            {
                agent.ResetPath();

                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    moveDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                    transform.forward = moveDir;
                }

                pState = PlayerState.Roll;
                anim.SetTrigger("Roll");

            }
        }
    }

    void idle()
    {
        anim.SetBool("Walk", false);

        if (Input.GetMouseButton(1))
        {
            pState = PlayerState.Walk;
        }

        // 공격
        if (skill.IsKey())
        {
            agent.ResetPath();
            anim.SetTrigger("Attack");
            pState = PlayerState.Attack;
            attack();
        }
    }

    void walk()
    {
        anim.SetBool("Walk", true);

        if (Input.GetMouseButton(1))
        {            
            setDestination();
        }

        if (!Input.GetMouseButton(1) && agent.velocity.magnitude.Equals(0f))
        {
            pState = PlayerState.Idle;
        }

        // 공격
        if (skill.IsKey())
        {
            agent.ResetPath();
            anim.SetTrigger("Attack");
            pState = PlayerState.Attack;
            attack();
        }
    }

    void reState()
    {
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(anim.GetNextAnimatorStateInfo(0).IsName("Sword Stance"))
        {
            pState = PlayerState.Idle;
        }
        else if(anim.GetNextAnimatorStateInfo(0).IsName("Sword Walk"))
        {
            pState = PlayerState.Walk;
        }
    }

    void attack()
    {
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.forward = hit.point - transform.position;
        }

        anim.SetInteger("AtkNum", skill.skillNum);
        attackDamage = skill.skillSet[skill.skillNum].damage;
        skill.StartEffect();
    }

    public void Damaged(float damage, int damagedAnim)
    {
        if (pState == PlayerState.Damaged || pState == PlayerState.Die || pState == PlayerState.Roll)
        {
            return;
        }

        hp -= damage;

        agent.isStopped = true;
        agent.ResetPath();

        if (hp > 0)
        {
            pState = PlayerState.Damaged;
            if (damagedAnim == 1)
            {
                anim.SetTrigger("Damage");
            }
            else
            {
                anim.SetTrigger("Down");
                StartCoroutine("down");
            }
        }
        else
        {
            pState = PlayerState.Die;
            die();
        }

    }

    IEnumerator down()
    {
        yield return new WaitForSeconds(2f);

        anim.SetTrigger("Stand");
    }

    void die()
    {
        anim.SetTrigger("Die");
    }


}
