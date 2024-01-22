using UnityEngine;
using UnityEngine.UI;

public class ActiveItem : MonoBehaviour
{

public Image activeItemSprite;
public Button removeActiveItemButton;
public Item activeitem;

private void Start()
{
    removeActiveItemButton.onClick.AddListener(RemoveButtonFunctionality);
}

public void SetActiveItem(Item item)
{
    activeitem = item;
    activeItemSprite.sprite = item.itemSprite;
}

private void RemoveButtonFunctionality()
{
    activeItemSprite.sprite = null;
    Debug.Log("Remove button pressed");
    
    Inventory.Instance.items.Add(activeitem);
    Inventory.Instance.activeItem.Clear();
    Inventory.Instance.uiChangeTriggered?.Invoke();
}
}