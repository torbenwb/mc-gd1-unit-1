using UnityEngine;

public class FollowCameraBehaviour : MonoBehaviour
{
    [Tooltip("A GameObject reference value determining which GameObject the Camera will follow")]
    [SerializeField] private GameObject target;
    [SerializeField] Vector3 targetOffset = Vector3.up;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float maxDistance= 5f;
    [SerializeField] float rotationSpeed = 180f;
    bool raycast = false;
    
    private Vector3 offset;
    private Vector3 Target{get => (target.transform.position + targetOffset);}

    // Start is called before the first frame update
    void Start()
    {
        if (target) offset = transform.position - (target.transform.position + targetOffset);
    }

    private void FixedUpdate()
    {
        UpdateCameraPositionRotation(Time.fixedDeltaTime);
    }

    Vector3 lastTargetPosition;

    private void UpdateCameraPositionRotation(float deltaTime){
        if (!target) return;

        Vector3 newPosition = Target + target.transform.rotation * offset;
        float distance = (newPosition - transform.position).magnitude;
        if (distance > maxDistance) newPosition = newPosition + (transform.position - newPosition).normalized * maxDistance;
        else{
            newPosition = Vector3.MoveTowards(lastTargetPosition, newPosition, (distance / maxDistance) * moveSpeed * deltaTime);
        }

        lastTargetPosition = newPosition;

        if (raycast){
            RaycastHit hit;
            Vector3 raycastDirection = (newPosition - Target).normalized;
            float raycastDistance = (newPosition - Target).magnitude;


            if (Physics.SphereCast(Target,0.1f,raycastDirection,out hit,raycastDistance)){
                newPosition = hit.point;
            }
        }
        
        transform.position = newPosition;
        
        Quaternion newRotation = Quaternion.LookRotation(Target - transform.position);
        transform.rotation = newRotation;
    }
    
}
