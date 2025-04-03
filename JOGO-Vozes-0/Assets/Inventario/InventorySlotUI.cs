using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    private Item currentItem;

    public void SetItem(Item newItem)
    {
        currentItem = newItem;

        if (currentItem != null && currentItem.itemIcon != null)
        {
            icon.sprite = currentItem.itemIcon;
            icon.enabled = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentItem == null) return;
        InventoryManager.Instance.UseItem(currentItem);

        var uiController = FindObjectOfType<InventoryUIController>();
        uiController?.UpdateUI();
    }
}