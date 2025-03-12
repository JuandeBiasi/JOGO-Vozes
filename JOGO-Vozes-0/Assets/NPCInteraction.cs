using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public string npcName = "NPC";  // Nome do NPC
    public GameObject dialogueBox;  // Referência a uma UI de diálogo (opcional)
    private bool isPlayerNearby = false;  // Checa se o player está perto

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Confere se o objeto que entrou é o Player
        {
            isPlayerNearby = true;
            Debug.Log(npcName + ": Oi, jogador!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log(npcName + ": Até mais!");
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))  // Se o player está perto e pressionar "E"
        {
            Debug.Log(npcName + ": Você interagiu comigo!");
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(!dialogueBox.activeSelf);  // Ativa/desativa UI de diálogo
            }
        }
    }
}
