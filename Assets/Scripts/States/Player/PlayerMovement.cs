using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController player;
    public float speed;
    public float rotationSpeed;
    public Transform cam;
    public Transform Player;
    public StateMachine sm;

    private Vector3 rotation;

    public Idle idleState;
    public Walking walkingState;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        sm = gameObject.AddComponent<StateMachine>();

        idleState = new Idle(this, sm);
        walkingState = new Walking(this, sm);
    }

    private void Update()
    {
        Walk();
    }

    public void Walk()
    {
        this.rotation = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        player.Move(move * speed);
        this.transform.Rotate(this.rotation);
    }
}
