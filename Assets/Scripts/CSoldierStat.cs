using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierStat : _PhotonMonoBehaviour
{
    public enum STATE
    {
        IDLE, MOVE, ATTACK, DAMAGE, DEATH
    }
    public STATE _state;
}
