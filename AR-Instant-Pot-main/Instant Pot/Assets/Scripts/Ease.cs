using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ease : MonoBehaviour
{
    [SerializeField]
    GameObject modelTarget;
    [SerializeField]
    Vector3 speed;

    public void StartEase()
    {
        Transform modelTargetTransform = modelTarget.GetComponent<Transform>();
        transform.position = new Vector3(modelTargetTransform.position.x, modelTargetTransform.position.y + 1, modelTargetTransform.position.z);
        LeanTween.moveY(this.gameObject, modelTargetTransform.position.y, 2).setEaseInOutCubic().setLoopPingPong();
    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
        Transform modelTargetTransform = modelTarget.GetComponent<Transform>();
    }
}
