using UnityEngine;
using UnityEngine.UI;

public class ActiveItemSlot : MonoBehaviour
{
public Image activeItemSprite;
public Button removeActiveItemButton;
public Item activeitem;
[SerializeField] Image activeItemCanvas;


private void Awake()
{
    activeItemCanvas.gameObject.SetActive(true);
}
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
    
    Inventory.Instance.items.Add(activeitem);
    Inventory.Instance.activeItem.Clear();
    Inventory.Instance.uiChangeTriggered?.Invoke();
}
}