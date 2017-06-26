using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoldierShot : _PhotonMonoBehaviour
{
    private CSoldierStat _stat;

    public float _shootDelayTime;
    private float _timer;

    private CSoldierAnimation _anim;

    public GameObject _bulletPrefab;

    public Transform _shotPos;

    public float _shotPower;

    private void Awake()
    {
        _stat = GetComponent<CSoldierStat>();
        _anim = GetComponent<CSoldierAnimation>();
    }

    [PunRPC]
    private void Shot(Vector3 pos, Vector3 forward, Quaternion qt, int viewId)
    {
        if (_stat._state == CSoldierStat.STATE.DEATH) return;

        _timer = 0.0f;

        GameObject bullet = Instantiate(_bulletPrefab, pos, qt);
        bullet.GetComponentInChildren<Rigidbody>().velocity = forward * _shotPower;

        bullet.GetComponentInChildren<CBullet>()._photonViewId = viewId;

        Destroy(bullet, 0.5f);
    }

    private void Update()
    {
        if (_stat._state == CSoldierStat.STATE.DEATH) return;

        if (photonView.isMine)
        {
            _timer += Time.deltaTime;

            if (Input.GetButton("Fire1") && _timer >= _shootDelayTime && Time.timeScale != 0)
            {
                //Shot(_shotPos.position, _shotPos.forward, transform.rotation, photonView.viewID);
                photonView.RPC("Shot", PhotonTargets.All, _shotPos.position, _shotPos.forward, transform.rotation, photonView.viewID);
            }
        }
    }
}
