using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemChampignon", menuName = "Scriptable Objects/ItemsChampigon")]
public class ItemMushroom : Item

{
    public override void Activation(PlayerItemManager player)
    {
 
        player.carControler.boost();
    }
}
