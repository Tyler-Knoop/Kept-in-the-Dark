using UnityEngine;

public class UnlockLoreRoomDoor : MonoBehaviour
{
    [SerializeField] private KeypadInteract keypad;
    private Animator animator;
    private ProgressManager progressManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        progressManager.LoadGameEvent += LoadDoorProgress;
        keypad.KeypadSolvedEvent += OpenDoor;
    }

    private void OpenDoor()
    {
        progressManager.Progress.OpenLoreRoom();
        AudioManager.Instance.PlaySFX("Big Door Open");
        animator.Play("DoorOpening");
    }

    private void LoadDoorProgress()
    {
        if (progressManager.Progress.GetIsLoreRoomOpen())
        {
            keypad.IsCodeEntered = true;
            animator.Play("DoorOpening");
        }
    }
}
