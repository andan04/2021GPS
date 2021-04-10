using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : It
{
    public Ittem item;

    public override void Interact()
    {
        print("abc");
        base.Interact();

        Pick();
    }

    void Pick()
    {
        Debug.Log("use Item : " + item.name);

        Destroy(gameObject);
    }
}
