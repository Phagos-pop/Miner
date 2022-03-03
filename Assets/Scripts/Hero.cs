using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour 
{
    public float speed;
    public Joystick joystick;
    public Vector3Int positionVector3Int;
    public BombMaker bombMaker;
    public float invulnerabilityTime;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool invulnerability;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        invulnerability = false;
    }

    void Update()
    {
        positionVector3Int = Vector3Int.FloorToInt(this.transform.position);

        Vector2 moveInput = joystick.Direction;
        moveVelocity = moveInput * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    public void PlantingBomb()
    {
        bombMaker.PlantingBomb(transform.position);
        StartCoroutine(InvulnerabilityCountdown());
    }

    private IEnumerator InvulnerabilityCountdown()
    {
        invulnerability = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        invulnerability = false;
    }

    public void Destroy()
    {
        if (!invulnerability)
        {
            Destroy(this.gameObject);
        }
    }
}
