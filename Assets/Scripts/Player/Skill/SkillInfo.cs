using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    public SkillImage skill;

    public Image image;
    public Text type;
    public Text coolTime;
    public Text info;

    // Start is called before the first frame update

    void Update()
    {
        if(skill == null)
        {
            return;
        }

        image.sprite = skill.image.sprite;

        switch (skill.skill.type)
        {
            case SkillData.Type.Combo:
                type.text = "�Ϲ� ��ų";
                break;

            case SkillData.Type.Magic:
                type.text = "���� ��ų";
                break;

            case SkillData.Type.Holding:
                type.text = "Ȧ�� ��ų";
                break;
        }

        coolTime.text = skill.skill.cooltime.ToString() + "s";
        info.text = skill.skill.skillInfo;

    }
}
