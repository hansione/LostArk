using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public Transform player;

    public GameObject image;

    private void Update()
    {
        image.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 4.5f + Vector3.right * 0.2f);

        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            UIManager.Instance.SelectStart();
        }
    }
}
