using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public GameObject gameObject;
    public ItemType itemType;
    public int yield;
    public enum ItemType
    {
        tool,
        resource
    }
}
