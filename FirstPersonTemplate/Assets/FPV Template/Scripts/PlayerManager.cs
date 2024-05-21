using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerView _playerView;
    
    // --> Properties
    public PlayerMovement Movement => _playerMovement;
    public PlayerView View => _playerView;
    
    [Header("Inputs")]
    [SerializeField] private InputActionReference _fpvMoveAction;
    [SerializeField] private InputActionReference _fpvJumpAction;
    [SerializeField] private InputActionReference _fpvViewAction;

    // --> Properties
    public InputActionReference FpvMoveAction => _fpvMoveAction;
    public InputActionReference FpvJumpAction => _fpvJumpAction;
    public InputActionReference FpvViewAction => _fpvViewAction;
}
