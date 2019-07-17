using UnityEngine;

public class CoinController : MonoBehaviour{
    [SerializeField] private float bobSpeed;
    [SerializeField] private float bobRotateSpeed;
    [SerializeField] private float bobHeight;

    private Vector3 startPos;
    private Vector3 targetPos;

    private void Awake(){
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, bobHeight, 0);
    }

    private void Update(){
        HandleBob();
    }

    private void HandleBob(){
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bobSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward, bobRotateSpeed * Time.deltaTime, Space.Self);
        if (transform.position == targetPos){
            if (targetPos == startPos){
                targetPos = startPos + new Vector3(0, bobHeight, 0);
            } else if(targetPos == startPos + new Vector3(0, bobHeight, 0)){
                targetPos = startPos;
            }
        }
    }
}
