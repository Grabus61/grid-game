using UnityEngine;
using UnityEngine.InputSystem;

public class BallCoverGame : Game
{
    [SerializeField] private InputActionReference upSelection;
    [SerializeField] private InputActionReference downSelection;
    [SerializeField] private InputActionReference leftSelection;
    [SerializeField] private InputActionReference rightSelection;

    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject downWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;

    [SerializeField] private GameObject ball;

    private bool stopped;

    void Awake()
    {
        StopGame();
    }

    void OnEnable()
    {
        upSelection.action.performed += UpSelectionPerformed;
        downSelection.action.performed += DownSelectionPerformed;
        leftSelection.action.performed += LeftSelectionPerformed;
        rightSelection.action.performed += RightSelectionPerformed;
    }

    void OnDisable()
    {
        upSelection.action.performed -= UpSelectionPerformed;
        downSelection.action.performed -= DownSelectionPerformed;
        leftSelection.action.performed -= LeftSelectionPerformed;
        rightSelection.action.performed -= RightSelectionPerformed;
    }

    private void UpSelectionPerformed(InputAction.CallbackContext context)
    {
        if(stopped) return;

        upWall.SetActive(true);
        downWall.SetActive(false);
        leftWall.SetActive(false);
        rightWall.SetActive(false);
    }

    private void DownSelectionPerformed(InputAction.CallbackContext context)
    {
        if(stopped) return;

        upWall.SetActive(false);
        downWall.SetActive(true);
        leftWall.SetActive(false);
        rightWall.SetActive(false);
    }

    private void LeftSelectionPerformed(InputAction.CallbackContext context)
    {
        if(stopped) return;

        upWall.SetActive(false);
        downWall.SetActive(false);
        leftWall.SetActive(true);
        rightWall.SetActive(false);
    }

    private void RightSelectionPerformed(InputAction.CallbackContext context)
    {
        if(stopped) return;

        upWall.SetActive(false);
        downWall.SetActive(false);
        leftWall.SetActive(false);
        rightWall.SetActive(true);
    }
    public override void StopGame(){
        base.StopGame();

        stopped = true;
    }

    public override void ContinueGame()
    {
        base.ContinueGame();

        stopped = false;
    }
}
