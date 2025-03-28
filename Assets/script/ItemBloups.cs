using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemBloups", menuName = "Scriptable Objects/ItemsBloups")]
public class ItemBloups : Item

{
    public override void Activation(PlayerItemManager player)
    {
        
        player.carControler.inkScreen();
    }
}
