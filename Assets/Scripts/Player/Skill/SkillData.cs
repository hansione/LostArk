using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/Skill")]
public class SkillData : ScriptableObject
{
    public enum Type
    {
        Combo,
        Magic,
        Holding
    }

    public Type type;

    public GameObject effect;
    public float damage;
    public float cooltime;
    public bool isUse;

    public string skillInfo;
}

