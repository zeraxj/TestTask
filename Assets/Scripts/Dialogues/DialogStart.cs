using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogStart : MonoBehaviour
{
    public GameObject player;
    public GameObject npc;
    public GameObject npcCanvas; // канвас кнопрки взаимодействи с нпс
    public GameObject dialogCanvas; // канвас диалога
    public Transform playerPositionAtDialog;
    public GameObject dialogCamera;
    private bool dialogStart;
    public bool questFinish;
    public GameObject questCanvas;

    void Update()
    {
        if (dialogStart)
        {
            player.transform.position = playerPositionAtDialog.transform.position;
            player.transform.LookAt(npc.transform.position);
        }
        
    }

    public void DialogOnStart()
    {
        
        dialogStart = true;
        player.GetComponent<PlayerInput>().DeactivateInput();
        
        

        Animator npcAnim = npc.GetComponent<Animator>();
        
        npcAnim.SetBool("Dialog", true);
        npcCanvas.SetActive(false);

        dialogCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogCanvas.SetActive(true);
        Quest quest = questCanvas.GetComponent<Quest>();
        if (quest.enemy == 3)
        {
            questFinish = true;
        }


    }
    public void DialogOnFinish()
    {

        dialogStart =false;
        player.GetComponent<PlayerInput>().ActivateInput();
        
        

        Animator npcAnim = npc.GetComponent<Animator>();
        
        npcAnim.SetBool("Dialog", false);
        npcCanvas.SetActive(true);

        dialogCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogCanvas.SetActive(false);
        Quest quest = questCanvas.GetComponent<Quest>();
        if (quest.enemy < 3)
        {
            questCanvas.SetActive(true);
        }
        else if (quest.enemy == 3)
        {
            questCanvas.SetActive(false);
            npcAnim.SetTrigger("dancing");
            Invoke("LoadScene", 10);
        }


    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    
    
}
