using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSoldierStat : _PhotonMonoBehaviour
{
    public enum STATE
    {
        IDLE, MOVE, ATTACK, DAMAGE, DEATH
    }
    public STATE _state;

    public Text _playerNameText;

    public Image _hpBarProgress;

    public Text _scoreText;

    private CSoldierAnimation _anim;

    private void Awake()
    {
        _anim = GetComponent<CSoldierAnimation>();
    }

    private void Start()
    {
        if (photonView != null && photonView.owner != null)
        {
            _playerNameText.text = photonView.owner.NickName;
        }

        LoadStatInfo();
    }

    public int HpDown(int damage)
    {
        _hpBarProgress.fillAmount -= (damage * 0.01f);

        SaveStatInfo();

        return (int)(_hpBarProgress.fillAmount * 100.0f);
    }

    private void Update()
    {
        _scoreText.text = photonView.owner.GetScore().ToString();
    }

    public void LoadStatInfo()
    {
        if (photonView.owner != null && photonView.owner.CustomProperties.ContainsKey("hp"))
        {
            int hp = (int)photonView.owner.CustomProperties["hp"];
            _hpBarProgress.fillAmount = hp * 0.01f;
            if (hp <= 0)
            {
                _anim.PlayAnimation(CSoldierStat.STATE.DEATH);
            }
            Debug.Log(this.GetMethodName() + ":" + photonView.owner.CustomProperties["hp"] + "->" + _hpBarProgress.fillAmount);
        }
    }

    public void SaveStatInfo()
    {
        if (photonView.owner != null)
        {
            ExitGames.Client.Photon.Hashtable statinfo = new ExitGames.Client.Photon.Hashtable();
            int hp = (int)(_hpBarProgress.fillAmount * 100.0f);
            statinfo.Add("hp", hp);
            photonView.owner.SetCustomProperties(statinfo);
            Debug.Log(this.GetMethodName() + ":" + statinfo + "<-" + _hpBarProgress.fillAmount);
        }
    }
}
