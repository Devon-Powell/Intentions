using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private bool isFollowing;

    Vector3 position;
    Vector3 targetPosition;
    public Vector3 offset;

    public float dampening;

    // Start is called before the first frame update
    void Start()
    {
        position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing && targetPosition != null)
        {
            position = Vector3.Lerp(position, targetPosition, dampening * Time.deltaTime);
        }
    }
}
