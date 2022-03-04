using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTrigger : MonoBehaviour
{    
    public GameObject bossZone;
    public GameObject bossZoneTrigger;
    public GameObject boss;
    public bool isBoss;

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
