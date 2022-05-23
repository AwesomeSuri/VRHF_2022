using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    // storing the hash of the trigger beforehand gives a bit of performance (good practice)
    private static readonly int Collect = Animator.StringToHash("Collect");

    public GameLogic gameLogic;

    private Animator _animator;
    private AudioSource _audio;
    
    private Transform _player;
    private Vector3 _playerStartPos;

    private void Start()
    {
        // get object bounded components
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        
        // get the player from the scene and store it's start position for later assignment
        _player = GameObject.FindWithTag("Player").transform;
        _playerStartPos = _player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // do nothing if the other object is not player
        if (!other.CompareTag("Player")) return;
        
        // otherwise trigger the collect animation and play the sound
        _animator.SetTrigger(Collect);
        _audio.Play();
        
        // increase the score
        gameLogic.GetPoints();
    }
    
    /// <summary>
    /// This function is called from the collect animation after it's done.
    /// </summary>
    public void ResetPlayer()
    {
        _player.position = _playerStartPos;
    }
}
