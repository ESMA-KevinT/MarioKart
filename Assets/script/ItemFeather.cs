using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemFeather", menuName = "Scriptable Objects/ItemsFeather")]


public class ItemFeather : Item
{
    public override void Activation(PlayerItemManager player)
    {
        Debug.Log("feather used");
        player.carControler.featherJump();
    }
}



