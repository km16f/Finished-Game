
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {

    public string iName;
    public Sprite icon;
    public int damage;
    public bool iskey;
    public bool isWeap;
    public bool valid = false;

    int itemID; // 0 for key, 1 for weapon

    public enum Type
    {
        weapon, key, story
    }


   
}
