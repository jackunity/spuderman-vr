
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using Valve.VR.InteractionSystem;
//using Valve.VR;
//using Valve.VR.Extras;

public class GrapplingHook : MonoBehaviour
{
    public Camera cam;
    public RaycastHit hit; public LayerMask cullingmask;
    public float maxDistance; public bool IsFlying;
    public Vector3 loc; public float speed = 20;
    //public Transform hand; //public FirstPersonController FPC;
    //[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
    //public SteamVR_Input_Sources inputSource;
    
   

   
    
    //private Hand vrhand;
    //public LineRenderer LR;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
	//vrhand = GetComponent<Hand>();
    }
    public void Update()
    {
        
        /*if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(inputSource))
        {
            Findspot();
        }*/
        //if (vrhand.)
	//if (vrhand.controller.GetHairTriggerDown())
        // {
        //     Debug.Log("Trigger");
        // }	
        if (Input.GetButton("Fire1") || Input.GetButton("RightTrigger")) {
            print("pressed spiderman button");
            Findspot();
        }
        if (IsFlying)
            Flying(); 
        if (Input.GetKey(KeyCode.Space) && IsFlying)
        {
            IsFlying = false;
            //FPC.CanMove = true;
            //LR.enabled = false;
        }
    }
    public void Findspot()
    {
        print("trying to find spot");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, cullingmask))
        {
            print("raycast completed");
            IsFlying = true;
            loc = hit.point;
            //FPC.CanMove = false;
            //LR.enabled = true;
            //LR.SetPosition(1, loc);
        }
    }
    public void Flying()
    {
        transform.position = Vector3.Lerp(transform.position, loc, speed * 10 / 10 / Vector3.Distance(transform.position, loc));
        //LR.SetPosition(100, hand.position);
        if (Vector3.Distance(transform.position, loc) < 0.5f) {
            IsFlying = false;
        //    FPC.CanMove = true;
        //    LR.enabled = false;

        }
    }
}
