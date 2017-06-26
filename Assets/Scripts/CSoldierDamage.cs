using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierDamage : _PhotonMonoBehaviour
{
    private CSoldierStat _stat;

    public ParticleSystem _bloodEffect;

    private CSoldierAnimation _anim;

    private void Awake()
    {
        _stat = GetComponent<CSoldierStat>();
        _anim = GetComponent<CSoldierAnimation>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(this.GetMethodName() + ":" + collider + ":" + collider.tag);
        if (collider.tag == "Bullet")
        {
            if (_stat._state == CSoldierStat.STATE.DEATH) return;

            _anim.PlayAnimation(CSoldierStat.STATE.DAMAGE);

            if (PhotonNetwork.isMasterClient)
            {
                int bulletOwnerPId = collider.GetComponent<CBullet>()._photonViewId;

                photonView.RPC("TakeDamage", PhotonTargets.AllBufferedViaServer, bulletOwnerPId);
            }

            Destroy(collider.gameObject);
        }
    }

    [PunRPC]
    public void TakeDamage(int bulletOwnerPId)
    {
        Debug.Log(this.GetMethodName() + ":" + bulletOwnerPId);
        //if (photonView.viewID != bulletOwnerPId) return;

        _bloodEffect.Play();
        int hp = _stat.HpDown(10);

        if (hp <= 0)
        {
            PhotonView pv = PhotonView.Find(bulletOwnerPId);
            if (pv != null)
            {
                pv.owner.AddScore(1);
            }

            _anim.PlayAnimation(CSoldierStat.STATE.DEATH);
        }
    }
}
