using UnityEngine;

public class DieDelay : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy;

    void FixedUpdate()
    {
        if (_timeBeforeDestroy > 0)
        {
            _timeBeforeDestroy = _timeBeforeDestroy - Time.fixedDeltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
