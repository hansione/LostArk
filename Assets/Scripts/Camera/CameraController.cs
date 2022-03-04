using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    // 플레이어 - 카메라 위치
    public Vector3 dir;

    private void Awake()
    {
        var obj = FindObjectsOfType<CameraController>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;

        // 초기에 설정된 카메라 위치 고정
        dir = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
        Zoom();
    }

    void CameraFollow()
    {
        transform.position = player.position - dir;
    }

    // 줌 인, 줌 아웃
    void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * 10f;

        if (distance != 0)
        {
            Camera.main.fieldOfView += distance;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40f, 60f);
        }
    }
}
