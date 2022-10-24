using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text questName;
    public Text questTarget;
    public int enemy = 0;
    // Start is called before the first frame update
    void Start()
    {

        questName.text = "����� ���� ��������";
    }

    // Update is called once per frame
    void Update()
    {
        questTarget.text = enemy + "/3";
        if (enemy == 3)
        {
            FinishQuest();
        }
    }

    private void FinishQuest()
    {
        questName.text = "��������� � ��������";
        questTarget.enabled = false;

    }

    public void EnemyKill()
    {
        enemy++;
    }
}
