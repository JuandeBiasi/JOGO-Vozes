using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    // Referência ao componente Image que exibirá o ícone do item.
    public Image icon;

    // Método para atualizar o slot com um item
    public void SetItem(Item newItem)
    {
        if (newItem != null && newItem.itemIcon != null)
        {
            icon.sprite = newItem.itemIcon;
            icon.enabled = true; // Ativa a imagem
        }
        else
        {
            // Se não houver item, limpa o slot
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}
