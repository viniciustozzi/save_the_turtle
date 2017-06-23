using DG.Tweening;
using UnityEngine;

public class OnBoatState : Node
{
    public GameObject boat;
    public Transform turtleOnBoat;
    public Transform turtleOnFloor;
    public Transform endOfWay;

    private void OnEnable()
    {
        transform.SetParent(boat.transform);
        transform.position = turtleOnBoat.position;
        boat.transform.DOMove(endOfWay.position, 4);

        Invoke("OnEndBoatAnimation", 5);
    }

    public void OnEndBoatAnimation()
    {
        transform.SetParent(null);
        transform.position = turtleOnFloor.position;

        if (_onChangeState != null)
            _onChangeState.Invoke(Transition.ExitBoat);
    }
}
