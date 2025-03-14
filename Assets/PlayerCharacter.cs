using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Attack()
    {
        _animator.Play("Attack");
    }
}