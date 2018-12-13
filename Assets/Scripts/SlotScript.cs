using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour{

    public int slotnum;
    public bool full;
    public bool isSelected;
    public GameObject objIn, player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void Equip()
    {
        if (gameObject.GetComponentInParent<InventoryUI>().equipped == false && objIn.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("in false");
            objIn.gameObject.GetComponent<PickupItem>().selected = true;
            objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<InventoryUI>().equipped = true;
            isSelected = true;
            player.gameObject.GetComponent<PlayerController>().armed = true;
            player.gameObject.GetComponent<PlayerController>().keyed = false;
            
        }
        else if(gameObject.GetComponentInParent<InventoryUI>().equipped == false && objIn.gameObject.CompareTag("Key"))
        {

            Debug.Log("in false");
            objIn.gameObject.GetComponent<PickupItem>().selected = true;
            objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<InventoryUI>().equipped = true;
            isSelected = true;
            player.gameObject.GetComponent<PlayerController>().keyed = true;
            player.gameObject.GetComponent<PlayerController>().armed = false;
        }
        else if(GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<InventoryUI>().equipped = true && isSelected == true && objIn.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("in true");
            objIn.gameObject.GetComponent<PickupItem>().selected = false;
            objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            isSelected = false;
            player.gameObject.GetComponent<PlayerController>().armed = false;
        }
        else if(GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<InventoryUI>().equipped = true && isSelected == true && objIn.gameObject.CompareTag("Key"))
        {
            Debug.Log("in true");
            objIn.gameObject.GetComponent<PickupItem>().selected = false;
            objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            isSelected = false;
            player.gameObject.GetComponent<PlayerController>().keyed = false;
        }
        else if(GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<InventoryUI>().equipped = true && isSelected == false)
        {

        }
    }

    private void Update()
    {
        if (isSelected && player.transform.localScale.x > 0 && objIn.gameObject.transform.localScale.x > 0)
        {
            if (player.GetComponent<PlayerController>().isHiding == true)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            objIn.gameObject.transform.position = player.gameObject.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            Vector3 temp = objIn.gameObject.transform.position;
            temp.x = player.transform.position.x + 0.8f;
            temp.y = player.transform.position.y - 0.068f;
            objIn.gameObject.transform.position = temp;
            Vector2 temp2 = objIn.gameObject.transform.localScale;
            temp2.x *= -1;
            objIn.gameObject.transform.localScale = temp2;
        }
        else if(isSelected && player.transform.localScale.x > 0 && objIn.gameObject.transform.localScale.x < 0)
        {
            if (player.GetComponent<PlayerController>().isHiding == true)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            objIn.gameObject.transform.position = player.gameObject.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            Vector3 temp = objIn.gameObject.transform.position;
            temp.x = player.transform.position.x + 0.8f;
            temp.y = player.transform.position.y - 0.068f;
            objIn.gameObject.transform.position = temp;
        }
        else if(isSelected && player.transform.localScale.x < 0 && objIn.gameObject.transform.localScale.x < 0)
        {
            if (player.GetComponent<PlayerController>().isHiding == true)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            objIn.gameObject.transform.position = player.gameObject.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            Vector3 temp = objIn.gameObject.transform.position;
            temp.x = player.transform.position.x - 0.8f;
            temp.y = player.transform.position.y - 0.068f;
            objIn.gameObject.transform.position = temp;
           Vector2 temp2 = objIn.gameObject.transform.localScale;
            temp2.x *= -1;
            objIn.gameObject.transform.localScale = temp2;
        }
        else if(isSelected && player.transform.localScale.x < 0 && objIn.gameObject.transform.localScale.x > 0)
        {
           if (player.GetComponent<PlayerController>().isHiding == true)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponentInParent<InventoryUI>().equipped = false;
            }
            else if (player.GetComponent<PlayerController>().isHiding == false)
            {
                objIn.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            objIn.gameObject.transform.position = player.gameObject.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            Vector3 temp = objIn.gameObject.transform.position;
            temp.x = player.transform.position.x - 0.8f;
            temp.y = player.transform.position.y - 0.068f;
            objIn.gameObject.transform.position = temp;
            
        }
            
    }
}
