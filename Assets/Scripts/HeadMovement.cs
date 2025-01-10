using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    private Vector3 originalPosition;

    public Transform targetTransform;
    public float movementDistance = 0.5f;
    public float movementSpeed = 2f;
    public int numberOfMoves = 3;

    private AudioSource audioSource;

    void Start()
    {
        originalPosition = targetTransform.localPosition;
        audioSource = GetComponent<AudioSource>();
 
    }

    void OnMouseDown()
    {
        audioSource.Play();
        StopAllCoroutines();
        StartCoroutine(MoveHead());
    }

    private System.Collections.IEnumerator MoveHead()
    {   
        Debug.Log("Mouse Down");
        for (int i = 0; i < numberOfMoves; i++)
        {
            yield return MoveToPosition(originalPosition + Vector3.left * movementDistance);
            yield return MoveToPosition(originalPosition + Vector3.right * movementDistance);
        }
        yield return MoveToPosition(originalPosition);
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * movementSpeed);
            yield return null;
        }
        transform.localPosition = targetPosition;
    }
}
