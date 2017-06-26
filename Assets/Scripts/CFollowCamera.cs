using UnityEngine;
using System.Collections;

public class CFollowCamera : MonoBehaviour
{
    Transform _target;

    public float _smoothing = 5f;

    public Vector3 _offset;

    // 타겟에 카메라를 설정함
    public void Init(Transform target)
    {
        _target = target;

        transform.position = Vector3.zero;

        transform.position = _target.position;

        transform.position = _target.position + _offset;
    }

    void LateUpdate()
    {
        if (_target == null) return;

        Vector3 targetCamPos = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position,
            targetCamPos, _smoothing * Time.deltaTime);
    }
}
