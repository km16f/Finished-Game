using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class InventoryUI : MonoBehaviour {
    public int size = 6;
    public float num;

    [SerializeField] List<GameObject> items;
    [SerializeField] SlotScript[] slots = new SlotScript[6];
    [SerializeField] Transform Parent;


    private void Update()
    {
        
    }

    public void AddItem(GameObject temp)
    {
        
       
    }

    

}
