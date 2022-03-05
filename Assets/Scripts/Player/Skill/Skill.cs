using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Transform player;

    public List<KeyCode> keyList;
    public int skillNum = 1;

    public List<SkillData> skillSet;

    public List<GameObject> skillEffect;
    public GameObject startPos;

    public Slider castingBar;
    bool isCasting = false;

    // ��ų ����Ʈ ������Ʈ Ǯ��
    private void Start()
    {
        for (int i = 0; i < skillSet.Count; i++)
        {
            skillSet[i].isUse = false;

            if (skillSet[i].effect == null)
            {
                skillEffect.Add(null);
            }
            else
            {
                GameObject effect = Instantiate(skillSet[i].effect);
                effect.SetActive(false);
                DontDestroyOnLoad(effect);
                skillEffect.Add(effect);
            }
        }
    }

    // Ȧ�� ��ų ĳ���� �ð�
    private void Update()
    {
        if (isCasting)
        {
            Cast(0.7f);
        }
    }

    // keyList�� ��ϵ� Ű�� �����ٸ�
    public bool IsKey()
    {
        for (int i = 0; i < keyList.Count; i++)
        {
            if (Input.GetKeyDown(keyList[i]))
            {
                skillNum = i;

                if (skillSet[skillNum].isUse)
                {
                    return false;
                }

                return true;
            }
        }

        return false;
    }

    // ��ų�� ����ϸ� (�÷��̾�)
    public void StartEffect()
    {
        if (skillEffect[skillNum] == null || skillSet[skillNum].isUse)
        {
            return;
        }

        if(skillSet[skillNum].type.Equals(SkillData.Type.Holding))
        {
            isCasting = true;
            castingBar.gameObject.SetActive(true);
        }
        else if(skillSet[skillNum].type.Equals(SkillData.Type.Magic))
        {
            // ����Ʈ
            skillEffect[skillNum].SetActive(!skillEffect[skillNum].activeSelf);

            if (skillEffect[skillNum].activeSelf)
            {
                skillEffect[skillNum].transform.position = startPos.transform.position;
                skillEffect[skillNum].transform.forward = startPos.transform.forward;
                StartCoroutine(MagicSkill());
            }
        }
        else
        {
            // ����Ʈ
            skillEffect[skillNum].SetActive(!skillEffect[skillNum].activeSelf);

            if (skillEffect[skillNum].activeSelf)
            {
                skillEffect[skillNum].transform.position = startPos.transform.position;
                skillEffect[skillNum].transform.forward = startPos.transform.forward;

            }
        }
    }

    IEnumerator MagicSkill()
    {
        int num = skillNum;

        skillSet[num].isUse = true;

        yield return new WaitForSeconds(2f);

        skillEffect[num].tag = "Skill";
        skillEffect[num].SetActive(false);

        yield return new WaitForSeconds(skillSet[num].cooltime - 2f);

        skillSet[num].isUse = false;

    }

    // Ȧ�� ��ų Ȱ��ȭ
    IEnumerator HoldingSkill()
    {
        int num = skillNum;

        skillEffect[num].SetActive(!skillEffect[num].activeSelf);

        if (skillEffect[num].activeSelf)
        {
            skillEffect[num].transform.position = startPos.transform.position;
        }

        yield return new WaitForSeconds(skillSet[skillNum].cooltime);
        
        skillEffect[num].tag = "Skill";
        skillEffect[num].SetActive(false);

        skillSet[num].isUse = false;
    }

    // Ȧ�� ��ų ĳ����
    public void Cast(float time)
    {
        //skillSet[skillNum].isUse = true;

        castingBar.value += 1f / (time / 0.02f);
        
        if (castingBar.value == 1)
        {
            StartCoroutine(HoldingSkill());
            skillSet[skillNum].isUse = true;
            isCasting = false;

            castingBar.gameObject.SetActive(false);
            castingBar.value = 0;
        }
    }

    public void NormalSkill(Animator anim)
    {
        if (skillNum == 0)
        { 
            if(Input.GetKeyDown(keyList[skillNum]))
            {
                anim.SetInteger("AtkCount", 1);
            }
        }
    }

}
