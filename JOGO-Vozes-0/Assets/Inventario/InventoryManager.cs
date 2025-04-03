using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemEvent : UnityEvent<Item> { }

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> items = new();
    public ItemEvent OnItemUsed = new(); // Agora é UnityEvent

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log("Item adicionado: " + newItem.itemName);
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (items.Remove(itemToRemove))
        {
            Debug.Log("Item removido: " + itemToRemove.itemName);
        }
    }

    public void UseItem(Item item)
    {
        RemoveItem(item);
        OnItemUsed.Invoke(item);
    }
}
