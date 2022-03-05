using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public bool isMove;
    int speed = -2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            isMove = true;
        }

        if(isMove)
        {
            MoveAction();
        }
    }

    public void MoveAction()
    {
        if(Camera.main.fieldOfView < 40)
        {
            speed = 2;
        }

        if (Camera.main.fieldOfView > 60)
        {
            Camera.main.fieldOfView = 60;

            speed = -2;
            isMove = false;
            return;
        }

        Camera.main.fieldOfView += speed;
    }


}
