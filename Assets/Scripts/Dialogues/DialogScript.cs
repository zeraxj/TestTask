using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    private string[] replic = {"����: ��� ���������?", "������: ������� ������ �� ������� ����� ����", "������: ��� ����� ���",
        "������: ����������, � ������ ����, ������ ��� � � � ����� �� ��������", "����: ������, � ���������", "����: � �� ���� ��������� �����", "����: �� ����������, � ���������"};
    public Text dialogText;
    public int numberReplic = 0;
    public DialogStart dialogFinishScript;
    public Animator serahAnim;
    
    void Start()
    {
        
        
        
        
        
            dialogText.text = replic[numberReplic];
        


    }
    private void Update()
    {
        if (dialogFinishScript.questFinish)
        {
            dialogText.text = "������� �� ���! ��� ��������)";

        }
    }



    public void NumberReplic()
    {
        if (dialogFinishScript.questFinish)
        {
            
            dialogFinishScript.DialogOnFinish();
        }
        else
        {
            if (numberReplic < 5)
            {
                numberReplic++;
                if (numberReplic == 3)
                {
                    serahAnim.SetBool("Praying", true);
                }
                else
                {
                    serahAnim.SetBool("Praying", false);
                }
                ReplicSwitch();
            }
            else
            {
                numberReplic = 6;
                dialogText.text = replic[numberReplic];
                dialogFinishScript.DialogOnFinish();
            }
        }
        
        
    }

    private void ReplicSwitch()
    {
        dialogText.text = replic[numberReplic];
    }
}
