using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tripod : MonoBehaviour
{
    Toggle ability;
    public SkillImage skill;

    float initDamage;
    public float addDamage;

    // Start is called before the first frame update
    void Start()
    {
        ability = GetComponent<Toggle>();

        ability.isOn = false;

        initDamage = skill.skill.damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(ability.isOn)
        {
            skill.skill.damage = initDamage * (100 + addDamage) / 100;
        }
        else
        {
            skill.skill.damage = initDamage;
        }    
    }
}
