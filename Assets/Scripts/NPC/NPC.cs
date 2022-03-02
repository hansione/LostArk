using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform player;

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            UIManager.Instance.SelectStart();
        }
    }
}
