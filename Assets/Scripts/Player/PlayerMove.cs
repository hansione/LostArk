using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    int money = 100;

    Camera camera;
    NavMeshAgent agent;

    bool isMove;
    float speed = 5f;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                setDestination(hit.point);
            }
        }

        move();

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(camera);
    }

    // 마우스 좌표
    void setDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    // 방향으로 움직이기
    void move()
    {
        if(isMove)
        {
            if(agent.velocity.magnitude.Equals(0f)) 
            {
                isMove = false;
                return;
            }

            // 플레이어 방향 및 이동
            Vector3 dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            transform.forward = dir;                                     
        }
    }
}
