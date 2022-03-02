using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    Vector3 dir;

    float value = 5f / (2.5f / 0.02f);

    private void FixedUpdate()
    {
        dir.x += value;
        dir.z += value;

        transform.localScale = dir;
    }

    private void OnEnable()
    {
        dir = new Vector3(5, 0.01f, 5);
    }
}
