using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemChampignon", menuName = "Scriptable Objects/ItemsChampigon")]
public class ItemChampignon : Item

{
    public override void Activation(PlayerItemManager player)
    {
        Debug.Log("champi lancé");
    }
}
