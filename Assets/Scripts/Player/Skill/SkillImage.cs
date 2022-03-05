using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillData skill;

    public Image coolTimeImage;
    public Image image;
    public Text countText;

    float count;

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString("F0");
        print(coolTimeImage.fillAmount);

        if (skill.isUse)
        {            
            countText.gameObject.SetActive(true);
            coolTimeImage.gameObject.SetActive(true);
            time();

            changeColor(100f / 255);
        }
        else
        {
            countText.gameObject.SetActive(false);
            coolTimeImage.gameObject.SetActive(false);

            count = skill.cooltime;
            coolTimeImage.fillAmount = 1f;

            changeColor(1);
        }
    }

    void changeColor(float color)
    {
        image.color = new Color(color, color, color);
    }

    void time()
    {
        count -= Time.deltaTime;
        coolTimeImage.fillAmount = count / skill.cooltime;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillInfo info = GameManager.Instance.skilInfo;

        info.gameObject.SetActive(true);
        info.skill = this;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.skilInfo.gameObject.SetActive(false);
    }
}
