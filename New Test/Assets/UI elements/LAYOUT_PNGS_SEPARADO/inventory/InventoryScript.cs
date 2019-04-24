using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public bool isClosed = true;
    public Image inventoryBG;
    Image[] invSlots;

    // Start is called before the first frame update
    void Start()
    {
        invSlots = inventoryBG.GetComponentsInChildren<Image>();

        inventoryBG.GetComponent<Image>().enabled = !isClosed;
        foreach (Image i in invSlots) i.enabled = !isClosed;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateInventory();
    }

    void ActivateInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isClosed)
            {
                inventoryBG.GetComponent<Image>().enabled = true;
                foreach (Image child in invSlots) child.enabled = true;

                isClosed = false;
            }
            else {
                inventoryBG.GetComponent<Image>().enabled = false;
                foreach (Image child in invSlots) child.enabled = false;
                isClosed = true;
            }
        }
    }

}
