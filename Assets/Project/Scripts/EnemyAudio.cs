using UnityEngine;

public class EnemyAudio : MonoBehaviour {
    public int AudioInterval = 5;
    private float _lastAudioPlayTime = 0;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time - _lastAudioPlayTime > AudioInterval)
        {
            _lastAudioPlayTime = Time.time;
            _audioSource.Play();
        }
    }

}
