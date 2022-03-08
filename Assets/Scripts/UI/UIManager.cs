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

    // 선택 창 열기
    public void SelectStart()
    {
        selectPanel.SetActive(true);
    }

    // 상점 창 열기
    public void ShopStart()
    {
        selectPanel.SetActive(false);
        shopImage.SetActive(true);
        InvenImage.SetActive(true);

        Inven.Instance.isActived = true;
        Inven.Instance.isShopUse = true;
    }

    // 상점 창 끄기 버튼
    public void ShopExitButton()
    {
        shopImage.SetActive(false);

        Inven.Instance.isShopUse = false;
    }

    // 퀘스트 창 열기
    public void QuestStart()
    {
        selectPanel.SetActive(false);
        questPanel.SetActive(true);

        if (GameManager.Instance.isQuestButton && GameManager.Instance.isQuestComplete)
        {
            text.text = "완료";
        }

    }

    // 퀘스트 창 끄기 버튼
    public void QuestExitButton()
    {
        questPanel.SetActive(false);
    }

    // 퀘스트 수락하기 버튼
    public void QuestAcceptButton()
    {
        if(text.text.Equals("완료"))
        {
            QuestExitButton();
            questPanel = NoQuest;

            GameManager.Instance.isQuestComplete = false;
            return;
        }

        if (GameManager.Instance.isQuestButton)
        {
            GameManager.Instance.isQuestButton = false;
            text.text = "수락";
        }
        else
        {
            GameManager.Instance.isQuestButton = true;
            text.text = "취소";
        }
    }

    public void ResultImage()
    {
        resultImage.SetActive(true);
    }
}
