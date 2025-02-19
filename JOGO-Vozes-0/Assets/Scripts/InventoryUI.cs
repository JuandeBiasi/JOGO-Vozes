using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Arraste aqui o painel do inventário (InventoryPanel)
    public GameObject inventoryPanel;

    void Update()
    {
        // Verifica se a tecla I foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Inverte o estado de ativo/inativo do painel
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }
    }
}
