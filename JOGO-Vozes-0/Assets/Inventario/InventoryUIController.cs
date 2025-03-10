using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    // Container que contém os slots do inventário (o objeto que tem o Grid Layout Group)
    public Transform slotContainer;

    // Array com todos os componentes InventorySlotUI que estão dentro do slotContainer
    private InventorySlotUI[] slots;

    private void Start()
    {
        // Obtém todos os InventorySlotUI que estão nos filhos do slotContainer
        slots = slotContainer.GetComponentsInChildren<InventorySlotUI>();
        UpdateUI();
    }

    // Atualiza os slots com os itens armazenados no InventoryManager
    public void UpdateUI()
    {
        // Obtem a lista de itens coletados
        List<Item> items = InventoryManager.Instance.items;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                // Se existir um item para esse slot, define o ícone
                slots[i].SetItem(items[i]);
            }
            else
            {
                // Caso contrário, limpa o slot
                slots[i].SetItem(null);
            }
        }
    }
}
