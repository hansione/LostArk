using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillData skill;
    public Image image;
    public Text countText;
    float count;

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString("F0");

        if (skill.isUse)
        {            
            countText.gameObject.SetActive(true);
            time();

            changeColor(100f / 255);
        }
        else
        {
            countText.gameObject.SetActive(false);

            count = skill.cooltime + 1;

            if (skill.type.Equals(SkillData.Type.Holding))
            {
                count += 0.8f;
            }

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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillInfo info = GameManager.Instance.skilInfo;

        info.gameObject.SetActive(true);
        info.image.sprite = image.sprite;

        switch (skill.type)
        {
            case SkillData.Type.Normal:
                info.type.text = "일반 스킬";
                break;

            case SkillData.Type.Magic:
                info.type.text = "마법 스킬";
                break;

            case SkillData.Type.Holding:
                info.type.text = "홀딩 스킬";
                break;
        }

        info.coolTime.text = skill.cooltime.ToString() +"s";
        info.info.text = skill.skillInfo;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.skilInfo.gameObject.SetActive(false);
    }
}
