using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateString))]
public class AutoHingeConnector : MonoBehaviour
{
    public bool LockFirstChild = true;
    public bool LockLastChild = false;
    public float chainFlexibilityAngle = 0.0f;
    [HideInInspector] public Transform[] child = { };

    public void Connect()
    {
        Link();
    }

    private void Link()
    {
        child = GetComponentsInChildren<Transform>();
        if (LockFirstChild) {
            SetChild(child[1]);
        }

        for (int i = 2; i < child.Length; i++)
        {
            GameObject currentChild = child[i].gameObject;
            GameObject prevChild = child[i - 1].gameObject;

            Rigidbody2D rb2d = currentChild.GetComponent<Rigidbody2D>();
            if (rb2d == null)
            {
                rb2d = currentChild.AddComponent<Rigidbody2D>();
            }
            rb2d.mass = 0.5f;

            HingeJoint2D hinge = currentChild.GetComponent<HingeJoint2D>();
            if (hinge == null)
            {
                hinge = currentChild.AddComponent<HingeJoint2D>();
                hinge = currentChild.GetComponent<HingeJoint2D>();
            }

            hinge.connectedBody = prevChild.GetComponent<Rigidbody2D>();
            SetFlexibility(hinge);
        }
        if (LockLastChild) {
            SetChild(child[child.Length - 1]);
        }
    }

    private void SetChild(Transform c)
    {
        Rigidbody2D c_rb2d = c.gameObject.GetComponent<Rigidbody2D>();
        if (c_rb2d == null)
        {
            c_rb2d = c.gameObject.AddComponent<Rigidbody2D>();
        }
        c_rb2d.bodyType = RigidbodyType2D.Static;
    }

    private void SetFlexibility(HingeJoint2D hj2d)
    {
        hj2d.useLimits = true;
        JointAngleLimits2D limit = hj2d.limits;
        limit.min = -chainFlexibilityAngle;
        limit.max = chainFlexibilityAngle;
        hj2d.limits = limit;
    }

    private void OnValidate()
    {
        Connect();
    }
}
