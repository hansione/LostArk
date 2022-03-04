using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneTag
{
    Town,
    Dungeon
}

public class PortalController : MonoBehaviour
{
    public ESceneTag scene;

    [SerializeField]
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(GameManager.Instance.isPortal)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.Equals(player))
        {
            player.transform.position = new Vector3(-46f, 0f, -87f);
            MoveScene();

            GameManager.Instance.isPortal = true;
        }
    }

    public void MoveScene()
    {
        SceneManager.LoadScene((int)scene);
    }
}
