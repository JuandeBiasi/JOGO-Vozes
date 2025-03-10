using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Singleton para facilitar acesso de outros scripts
    public static InventoryManager Instance;

    // Lista que armazena todos os itens coletados
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        // Configurando o Singleton
        if (Instance == null)
        {
            Instance = this;
            // Se quiser que esse objeto não seja destruído ao trocar de cena:
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para adicionar um item ao inventário
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log("Item adicionado: " + newItem.itemName);
    }

    // (Opcional) Método para remover um item do inventário
    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log("Item removido: " + itemToRemove.itemName);
        }
    }
}
