using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    Camera camera;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
       
        camera = transform.GetChild(0).GetComponent<Camera>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();
    }
    private void PlayerMove()
    {
        if (GameManager.isOpen == false)
        {
            rigid.Move(gameObject, speed);
            rigid.PlayerRotation(gameObject, 2f);
            camera.CameraRotation(2f);
        }
    }
}
