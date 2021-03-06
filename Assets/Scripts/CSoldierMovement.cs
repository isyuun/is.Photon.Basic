﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierMovement : _PhotonMonoBehaviour
{
    protected CharacterController _cc;

    private Vector3 moveDir = Vector3.zero;

    public float _speed;
    public float _gravity;

    protected CSoldierAnimation _anim;

    private CSoldierStat _stat;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<CSoldierStat>();
        _anim = GetComponent<CSoldierAnimation>();
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            if (_stat._state != CSoldierStat.STATE.DEATH)
            {
                //Move();
                //Turn();
            }
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = new Vector3(h, 0f, v);

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

    void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, 100f, 1 << LayerMask.NameToLayer("Floor")))
        {
            Vector3 playerToMosue = floorHit.point - transform.position;
            playerToMosue.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMosue);

            transform.rotation = newRotation;
        }
    }

}
