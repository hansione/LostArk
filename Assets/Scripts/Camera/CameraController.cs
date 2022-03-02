using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    // �÷��̾� - ī�޶� ��ġ
    Vector3 dir;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        // �ʱ⿡ ������ ī�޶� ��ġ ����
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

    // �� ��, �� �ƿ�
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
