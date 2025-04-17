using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform tip;
    public Vector3 lastPos = Vector3.zero;

    public Rigidbody rbArrow;
    
    public bool stopped = true;

    void Start()
    {
          rbArrow = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        if (stopped)
        {
            return;
        }

        if(Physics.Linecast(lastPos, tip.position, out RaycastHit info)){
            stopped = true;
            rbArrow.useGravity = false;
            rbArrow.isKinematic = true;
            rbArrow.velocity = Vector3.zero;
        }

        lastPos = tip.position;
    }

    public void Fire(float power){
       stopped = false;

       rbArrow.useGravity = true;
       rbArrow.isKinematic = false;
       transform.parent = null;

       lastPos = tip.position;
       rbArrow.AddForce(transform.forward * power * 20000);

       Destroy(gameObject, 10.0f);
   }

   public void deleteArrow(){
       Destroy(gameObject);
   }
}
