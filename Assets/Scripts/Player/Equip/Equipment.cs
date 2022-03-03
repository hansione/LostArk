using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject equipBase;
    public GameObject equipSymbol;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Inven.Instance.isEquipUse = !Inven.Instance.isEquipUse;
            equipBase.SetActive(Inven.Instance.isEquipUse);
            equipSymbol.SetActive(Inven.Instance.isEquipUse);
        }
    }
}
