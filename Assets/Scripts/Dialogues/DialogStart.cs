using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogStart : MonoBehaviour
{
    public GameObject player;
    public GameObject npc;
    public GameObject npcCanvas; // ������ ������� ������������� � ���
    public GameObject dialogCanvas; // ������ �������
    public Transform playerPositionAtDialog;
    public GameObject dialogCamera;
    private bool dialogStart;

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


    }

    
    
}
