using UnityEngine;

public class BoomAnimation : MonoBehaviour
{
    private readonly float _delay = 0f;

    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay);
    }
}