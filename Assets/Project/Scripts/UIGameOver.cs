using System.Linq;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

    private GameState _gameState;
    private RectTransform[] _children;
    private Animator _animator;

    private void Awake()
    {
        _children = gameObject.GetComponentsInChildren<RectTransform>()
            .Where(rt => rt.gameObject != gameObject)
            .ToArray();
        _gameState = FindObjectOfType<GameState>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        foreach (var child in _children)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_gameState.CannotWin()) {
            foreach (var child in _children)  {
                child.gameObject.SetActive(true);
                }
            }
        _animator.SetTrigger("GameOver");
    }

}
