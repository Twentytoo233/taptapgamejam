using Unity.VisualScripting;
using UnityEngine;

public class HydraulicPress : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    private Vector2 StartPosition;
    private Vector2 EndPosition;
    private bool isDown;
    void Start()
    {
        StartPosition = transform.position;
        EndPosition = new Vector2(StartPosition.x, StartPosition.y - moveDistance);
        isDown = true;
    }
    private void Update()
    {
        EndPosition = new Vector2(StartPosition.x, StartPosition.y - moveDistance);
        if (Vector2.Distance(transform.position, EndPosition) < 0.1f)
        {
            isDown = false;
        }
        if (Vector2.Distance(transform.position,StartPosition) < 0.1f)
        {
            isDown = true;
        }
    }
    private void FixedUpdate()
    {
        if (isDown)
        {
            transform.position = Vector2.Lerp(transform.position, EndPosition, Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, StartPosition, Time.deltaTime);
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 size = new Vector2(GetComponent<BoxCollider2D>().size.x * gameObject.transform.localScale.x, GetComponent<BoxCollider2D>().size.y * gameObject.transform.localScale.y);
        Gizmos.DrawWireCube(gameObject.transform.position, size);
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - moveDistance), size);
    }
#endif
}
