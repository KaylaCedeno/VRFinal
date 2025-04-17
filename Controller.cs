using UnityEngine;

public class Controller : MonoBehaviour
{
    public Bow myBow = null;
    public Transform hand;

    public OVRInput.Controller BowCont = OVRInput.Controller.LTouch;
    public OVRInput.Controller handCont = OVRInput.Controller.RTouch;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger, handCont)){
            myBow.Pull(hand);

        }
        if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, handCont)){
            
                myBow.Release();
            }
    }
}

