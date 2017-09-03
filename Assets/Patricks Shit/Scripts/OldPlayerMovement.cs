using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    public float _Speed = 2; 

    [SerializeField]
    private Vector2 _Deltaforce;

    private Rigidbody2D _RGB;

    private Animator _Anim;

    private BoxCollider2D _BoxCollider;

    private void Awake()
    {
        _Anim = GetComponent<Animator>();
        _RGB = GetComponent<Rigidbody2D>();
        _BoxCollider = GetComponent<BoxCollider2D>();
    }

     void Start()
    {
        _RGB.gravityScale = 0;
        _RGB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

     void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        var Horiz = Input.GetAxisRaw("Horizontal");
        var Vert = Input.GetAxisRaw("Vertical");

        _Deltaforce = new Vector2(Horiz, Vert);

        CalculateMovement(_Deltaforce * _Speed);
    }

    void CalculateMovement(Vector2 _PlayerForce)
    {
        _RGB.velocity = Vector2.zero;

        _RGB.AddForce(_PlayerForce,ForceMode2D.Impulse);
    }

}
