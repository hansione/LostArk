using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStart : MonoBehaviour
{
    Player player;

    public static bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;

        StartCoroutine(start());

        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isStart = true;
        }

        if (!isStart)
        {
            player.transform.position = transform.position;
        }

    }

    IEnumerator start()
    {

        yield return new WaitForSeconds(0.1f);

        isStart = true;
    }



}
