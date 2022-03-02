using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public enum ESceneTag
    {
        Town,
        Dungeon
    }

    public ESceneTag scene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Player"))
        {
            other.transform.position = new Vector3(-46f , 0f, -87f);
            MoveScene();
        }
    }

    public void MoveScene()
    {
        SceneManager.LoadScene((int)scene);
    }
}
