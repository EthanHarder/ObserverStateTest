using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateHandler : MonoBehaviour
{

    public float progress = 0.0f;

    [SerializeField]
    public float fuel;

    public float currentStateTime = 0.0f;

    public PlayerState currentState;


    public float progressEventUpdaterate;
    public float progressTimer;

    public UnityEvent ProgressEvent;

    private void Start()
    {
        DriveState initDrive = new DriveState();
        initDrive.StateHandler = this;
        currentState = initDrive;


    }
    void Update()
    {
        currentStateTime += Time.deltaTime;


        currentState.StateBehaviour(GetComponent<PlayerInput>().moveVec, currentStateTime);

        fuel -= Time.deltaTime;
        if (fuel <= 0.0f)
            currentState.Transition(PlayerState.TransitionFlag.NoFuel);

        progressTimer += Time.deltaTime;

        if (progressTimer >= progressEventUpdaterate)
        {
            progressTimer -= progressEventUpdaterate;
            ProgressEvent?.Invoke();
        }
       
    }


    public void Carhit()
    {
        currentState.Transition(PlayerState.TransitionFlag.Hit);
    }




}
