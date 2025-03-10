using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFood : MonoBehaviour
{
    public FoodItem foodData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(foodData);

            // Após adicionar o item, atualiza a UI do inventário
            InventoryUIController uiController = FindObjectOfType<InventoryUIController>();
            if (uiController != null)
            {
                uiController.UpdateUI();
            }

            Destroy(gameObject);
        }
    }
}
