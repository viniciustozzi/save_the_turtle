using UnityEngine;

public class DefendState : Node
{
    public Rigidbody2D mBody;

    private void Start()
    {
        mBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        mBody.velocity = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }

    private void OnDisable()
    {

    }
}
