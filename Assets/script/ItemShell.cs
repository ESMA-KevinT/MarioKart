using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemShell", menuName = "Scriptable Objects/ItemShell")]
public class ItemShell : Item
{
    public GameObject shell;

    private Rigidbody _rgb;
    
    
    public override void Activation(PlayerItemManager player)
    {
        Instantiate(shell, player.transform.position, player.transform.rotation);
        
       
    }

}
