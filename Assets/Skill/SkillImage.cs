using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImage : MonoBehaviour
{
    public SkillData skill;
    Image image;
    public Text countText;
    float count;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

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

}
