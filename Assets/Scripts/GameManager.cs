using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    public GameObject bossZone;
    public GameObject bossZoneTrigger;
    public GameObject boss;
    public bool isBoss;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoss)
        {
            bossStart();
        }
    }

    public void bossStart()
    {
        boss.SetActive(true);
        bossZone.SetActive(true);
    }

}
