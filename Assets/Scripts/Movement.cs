using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [Header("References")]
    [Tooltip("Move speed")]
    public float speed = 5f;

    [Tooltip("Game object")]
    public Transform Object; // This is the object that will be moved

    [Tooltip("Transform component")]
    public Transform target;

    public CharacterController characterController;

    private Vector3 movementSpeed = Vector3.zero;


    private Vector3 moveUp = new Vector3(0,1,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveObject();
        MoveObject2();
    }

    void MoveObject(){
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
            target.rotation = Quaternion.Slerp(target.rotation, Quaternion.LookRotation(Vector3.forward), .18f);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            target.rotation = Quaternion.Slerp(target.rotation, Quaternion.LookRotation(Vector3.forward), .18f);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            target.rotation = Quaternion.Slerp(target.rotation, Quaternion.LookRotation(Vector3.forward), .18f);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            target.rotation = Quaternion.Slerp(target.rotation, Quaternion.LookRotation(Vector3.forward), .18f);
            
        }
    }

    void MoveObject2(){
        if(Input.GetKeyDown(KeyCode.W)){
            movementSpeed.z = Mathf.Min(movementSpeed.z + speed * Time.deltaTime, speed);
        }

        if(movementSpeed.z != 0){
            characterController.Move(movementSpeed * Time.deltaTime);
        }
    }
}
