using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    Transform player;

    public GameObject mark;

    public GameObject shopSymbol;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        shopSymbol.SetActive(UIManager.Instance.shopImage.activeSelf);

        mark.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 4.5f + Vector3.right * 0.2f);

        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            if((GameManager.Instance.isQuestButton && GameManager.Instance.isQuestComplete) ||
               !GameManager.Instance.isQuestButton)
            {
                mark.SetActive(true);
            }
        }
        else
        {
            mark.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            UIManager.Instance.SelectStart();
            mark.SetActive(false);
        }
    }
}
