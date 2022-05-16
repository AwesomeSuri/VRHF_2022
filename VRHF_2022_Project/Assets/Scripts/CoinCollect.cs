using System;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private static readonly int Collect = Animator.StringToHash("Collect");

    private Animator _animator;
    private Transform _player;
    private Vector3 _playerStartPos;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").transform;
        _playerStartPos = _player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _animator.SetTrigger(Collect);
    }

    public void ResetPlayer()
    {
        _player.position = _playerStartPos;
    }
}
