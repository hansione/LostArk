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
    bool isQuestConfirm = false;

    public GameObject resultImage;

    private void Awake()
    {
        if (Instance == null) Instance = this;
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

    }

    // ���� â ���� ��ư
    public void ShopExitButton()
    {
        shopImage.SetActive(false);
    }

    // ����Ʈ â ����
    public void QuestStart()
    {
        selectPanel.SetActive(false);
        questPanel.SetActive(true);
    }

    // ����Ʈ â ���� ��ư
    public void QuestExitButton()
    {
        questPanel.SetActive(false);
    }

    // ����Ʈ �����ϱ� ��ư
    public void QuestAcceptButton()
    {
        if (isQuestConfirm)
        {
            isQuestConfirm = false;
            text.text = "����";
        }
        else
        {
            isQuestConfirm = true;
            text.text = "���";
        }

    }

    public void ResultImage()
    {
        resultImage.SetActive(true);
    }
}
