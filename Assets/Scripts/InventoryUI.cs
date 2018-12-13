using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class InventoryUI : MonoBehaviour {
    public int size = 6;
    public float num = 0;
    public bool equipped;

    [SerializeField] List<GameObject> items;
    [SerializeField] SlotScript[] slots = new SlotScript[6];
    [SerializeField] Transform Parent;

   

    public void AddItem(GameObject temp)
    {
        items.Add(temp);
        updateInv(temp);
        num++;
    }

    
    void updateInv(GameObject temp)
    {
        for(int i = 0; i < 6; i++)
        {
            if(slots[i].full == false)
            {
                slots[i].gameObject.GetComponent<Image>().sprite = temp.gameObject.GetComponent<SpriteRenderer>().sprite;
                slots[i].gameObject.GetComponent<Image>().enabled = true;
                slots[i].objIn = temp;
                slots[i].slotnum = i;
                slots[i].full = true;
                break;
            }

           
        }
    }

  
}
