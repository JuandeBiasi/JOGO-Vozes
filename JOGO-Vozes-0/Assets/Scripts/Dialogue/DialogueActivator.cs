using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using RPG.UI;

public class DialogueActivator : MonoBehaviour
{
    [SerializeField] string conversantName;
    PlayerConversant playerConversant;
    [SerializeField] private GameObject dialogueButton; // Referência ao botão no Canvas
    [SerializeField] private Dialogue dialogue= null;
    private bool canActivate;

    private void Start()
    {
        playerConversant = GameObject.FindWithTag("Player")?.GetComponent<Entity>()?.GetComponent<PlayerConversant>();

        if (playerConversant == null)
        {
            Debug.LogWarning("PlayerConversant não encontrado no jogador.");
        }

        if (dialogueButton != null)
        {
            dialogueButton.SetActive(false); // Garante que o botão comece desativado
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;
            if (dialogueButton != null)
            {
                dialogueButton.SetActive(true); // Mostra o botão ao entrar no trigger
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
            if (dialogueButton != null)
            {
                dialogueButton.SetActive(false); // Esconde o botão ao sair do trigger
            }
        }
    }

    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.E))
        {
            canActivate = false;
            if (playerConversant != null)
            {
                playerConversant.StartDialogue(this.GetComponent<DialogueActivator>(), dialogue);
                if (dialogueButton != null)
                {
                    dialogueButton.SetActive(false); // Esconde o botão ao iniciar o diálogo
                }
            }
        }
    }
    public string GetName()
    {
        return conversantName;
    }


}
