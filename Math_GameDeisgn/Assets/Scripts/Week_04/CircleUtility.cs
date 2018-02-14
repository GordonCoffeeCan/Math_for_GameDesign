using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleUtility {

    public static Vector3 PointOnCircle(float radius, float angle) {
        float angleInRadius = angle * Mathf.Deg2Rad;
        return new Vector3(radius * Mathf.Cos(angleInRadius), radius * Mathf.Sin(angleInRadius), 0);
    }

    public static Vector3 ParticleOnSphere(float radius, float horizontalAngle, float verticleAngle) {

        float horizontalRadians = horizontalAngle * Mathf.Deg2Rad;
        float verticalRadians = verticleAngle * Mathf.Deg2Rad;

        return new Vector3(radius * Mathf.Sin(horizontalRadians) * Mathf.Cos(verticalRadians), radius * Mathf.Sin(verticalRadians), radius * Mathf.Cos(horizontalRadians) * Mathf.Sin(verticalRadians));

    }
}
