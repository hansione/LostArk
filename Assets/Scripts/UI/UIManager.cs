using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    public GameObject selectPanel;

    public GameObject shopImage;
    public GameObject InvenImage;

    public GameObject questPanel;
    public Text text;
    public GameObject NoQuest;

    public GameObject resultImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(resultImage == null)
        {
            resultImage = GameObject.Find("Result");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            questPanel.SetActive(!questPanel.activeSelf);
        }
    }

    // ���� â ����
    public void SelectStart()
    {
        selectPanel.SetActive(true);
    }

    // ���� â ����
    public void ShopStart()
    {
        selectPanel.SetActive(false);
        shopImage.SetActive(true);
        InvenImage.SetActive(true);

        Inven.Instance.isActived = true;
        Inven.Instance.isShopUse = true;
    }

    // ���� â ���� ��ư
    public void ShopExitButton()
    {
        shopImage.SetActive(false);

        Inven.Instance.isShopUse = false;
    }

    // ����Ʈ â ����
    public void QuestStart()
    {
        selectPanel.SetActive(false);
        questPanel.SetActive(true);

        if (GameManager.Instance.isQuestButton && GameManager.Instance.isQuestComplete)
        {
            text.text = "�Ϸ�";
        }

    }

    // ����Ʈ â ���� ��ư
    public void QuestExitButton()
    {
        questPanel.SetActive(false);
    }

    // ����Ʈ �����ϱ� ��ư
    public void QuestAcceptButton()
    {
        if(text.text.Equals("�Ϸ�"))
        {
            QuestExitButton();
            questPanel = NoQuest;

            GameManager.Instance.isQuestComplete = false;
            return;
        }

        if (GameManager.Instance.isQuestButton)
        {
            GameManager.Instance.isQuestButton = false;
            text.text = "����";
        }
        else
        {
            GameManager.Instance.isQuestButton = true;
            text.text = "���";
        }
    }

    public void ResultImage()
    {
        resultImage.SetActive(true);
    }
}
