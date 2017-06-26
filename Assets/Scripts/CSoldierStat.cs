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

    private void Start()
    {
        if (photonView != null && photonView.owner != null)
        {
            _playerNameText.text = photonView.owner.NickName;
        }
    }

    public int HpDown(int damage)
    {
        _hpBarProgress.fillAmount -= (damage * 0.01f);

        return (int)(_hpBarProgress.fillAmount * 100.0f);
    }

    private void Update()
    {
        _scoreText.text = photonView.owner.GetScore().ToString();
    }
}
