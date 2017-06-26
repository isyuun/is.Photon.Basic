using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierAnimation : _PhotonMonoBehaviour
{
    private CSoldierStat _stat;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stat = GetComponent<CSoldierStat>();
    }

    public bool IsPlayAnimation(string animName, int layer = 0)
    {
        //if (_animator.GetCurrentAnimatorStateInfo(layer).IsName(animName))
        //{
        //    return true;
        //}
        //return false;
        return _animator.GetCurrentAnimatorStateInfo(layer).IsName(animName);
    }

    public void PlayAnimation(CSoldierStat.STATE state)
    {
        switch (state)
        {
            case CSoldierStat.STATE.IDLE:
                _animator.SetBool("Move", false);
                break;
            case CSoldierStat.STATE.MOVE:
                _animator.SetBool("Move", true);
                break;
            case CSoldierStat.STATE.ATTACK:
                break;
            case CSoldierStat.STATE.DAMAGE:
                break;
            case CSoldierStat.STATE.DEATH:
                if (IsPlayAnimation("Death", 0)) break;
                _animator.SetTrigger("Death");
                break;
            default:
                break;
        }
    }
}
