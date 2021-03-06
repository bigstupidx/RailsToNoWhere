﻿using UnityEngine;

[RequireComponent(typeof(Player))]
public class Pickup : MonoBehaviour
{
    private int pastId;

    void Start()
    {
        Player.player.InteractEvent += OnRaycastHit;
    }

    void OnRaycastHit(GameObject hit)
    {
        WorldItem objWorldItem = hit.GetComponent<WorldItem>();
        
        if (hit.GetComponent<WorldItem>() != null) {
            if (objWorldItem.Interactable == true) {
                if (pastId == hit.GetInstanceID()) Debug.LogError("Same item!");
                Player.player.Inventory.AddItem(objWorldItem.ItemID, objWorldItem.Quantity);
                Destroy(hit.gameObject);
            }
        }

        pastId = hit.GetInstanceID();
    }
}


