using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Eclipse of the Labyrinth/Items/Item")]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public float itemScale = 1;
    
    public virtual void useItem()
    {
    
    }
}