using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;

public class CJoystick : _MonoBehaviour
{
    public enum SIDE { MOVE = 0, TURN }
    public SIDE side;
    private CSoldierMovement2 move;

    public void Init(CSoldierMovement2 move)
    {
        Debug.Log(this.GetMethodName() + ":" + this.side);
        this.move = move;
    }

    private void Move()
    {
        float h = CnInputManager.GetAxisRaw("Horizontal");
        float v = CnInputManager.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            Debug.Log(this.GetMethodName() + ":" + this.side);
        }
        this.move.Move(h, v);
    }

    private void Turn()
    {
        float h = CnInputManager.GetAxisRaw("Horizontal2");
        float v = CnInputManager.GetAxisRaw("Vertical2");

        if (h != 0 || v != 0)
        {
            Debug.Log(this.GetMethodName() + ":" + this.side);
        }
        this.move.Turn(h, v);
    }

    private void Update()
    {
        if (this.move == null) return;

        switch (this.side)
        {
            case SIDE.MOVE:
                Move();
                break;
            case SIDE.TURN:
                Turn();
                break;
            default:
                break;
        }
    }

}
