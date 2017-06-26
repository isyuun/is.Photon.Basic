using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierStat : Photon.MonoBehaviour
{
    public enum STATE
    {
        IDLE, MOVE, ATTACK, DAMAGE, DEATH
    }
    public STATE _state;

}
