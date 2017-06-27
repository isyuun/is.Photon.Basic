using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierMovement2 : CSoldierMovement
{
    private void Start()
    {
        //GameObject player = GameObject.Find(PhotonNetwork.playerName);
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject item in players)
        //{
        //    PhotonView pv = item.GetComponent<PhotonView>();
        //    if (pv == null) continue;
        //    Debug.Log(this.GetMethodName() + ":" + item + ":" + pv.name);
        //    if (pv != null && pv.isMine && pv.name == PhotonNetwork.playerName)
        //    {
        //        player = item;
        //    }
        //}
        GameObject player = gameObject;
        //Debug.LogWarning(this.GetMethodName() + ":" + PhotonNetwork.playerName + ":" + player);
        foreach (CJoystick item in GameObject.FindObjectsOfType<CJoystick>())
        {
            //Debug.Log(this.GetMethodName() + ":" + item + ":" + item.side);
            item.Init(player.GetComponent<CSoldierMovement2>());
        }
    }

    public void Move(float h, float v)
    {
        Vector3 moveDir = new Vector3(h, 0f, v);

        if (h != 0 || v != 0)
        {
            _anim.PlayAnimation(CSoldierStat.STATE.MOVE);
        }
        else
        {
            _anim.PlayAnimation(CSoldierStat.STATE.IDLE);
        }

        float speed = _speed;
        if (h != 0 && v != 0)
        {
            float degree = Mathf.Cos(45f * Mathf.Deg2Rad);
            speed = speed * degree;
        }

        moveDir *= speed;
        moveDir.y -= _gravity;

        _cc.Move(moveDir * Time.deltaTime);
    }

    public void Turn(float h, float v)
    {
        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction == Vector3.zero) return;

        Quaternion newRotation = Quaternion.LookRotation(direction);

        transform.rotation = newRotation;
    }

}
