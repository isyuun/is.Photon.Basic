using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIBillboard : _MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
