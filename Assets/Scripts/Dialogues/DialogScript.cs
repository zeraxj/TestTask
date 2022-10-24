using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    private string[] replic = {"Марк: Что случилось?", "Джесси: Бандиты напали на магазин моего папы", "Джесси: Они убьют его",
        "Джесси: Незнакомец, я умоляю тебя, помоги ему и я в долгу не останусь", "Марк: Хорошо, я попытаюсь", "Марк: А ты пока оставайся здесь", "Марк: Не беспокойся, я разберусь"};
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
            dialogText.text = "Спасибо за все! Еще увидемся)";

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
