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

    }

    // 상점 창 끄기 버튼
    public void ShopExitButton()
    {
        shopImage.SetActive(false);
    }

    // 퀘스트 창 열기
    public void QuestStart()
    {
        selectPanel.SetActive(false);
        questPanel.SetActive(true);
    }

    // 퀘스트 창 끄기 버튼
    public void QuestExitButton()
    {
        questPanel.SetActive(false);
    }

    // 퀘스트 수락하기 버튼
    public void QuestAcceptButton()
    {
        if (isQuestConfirm)
        {
            isQuestConfirm = false;
            text.text = "수락";
        }
        else
        {
            isQuestConfirm = true;
            text.text = "취소";
        }

    }

    public void ResultImage()
    {
        resultImage.SetActive(true);
    }
}
