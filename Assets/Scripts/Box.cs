using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ___Plane
{
    protected override void Update()
    {
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        //Debug.Log(this.GetMethodName() + ":" + pv.isMine + ":" + pv);
        if (pv != null && pv.isMine)
        {
            base.Update();
        }
    }
}
