using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public GameObject skillBook;
    public GameObject skillSymbol;

    bool isActived = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            isActived = !isActived;

            skillBook.SetActive(isActived);
        }

        skillSymbol.SetActive(skillBook.activeSelf);
    }
}
