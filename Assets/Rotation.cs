using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float velocityRotation=1;
    [SerializeField] private Vector3 angulos;
    [SerializeField] private Quaternion qx = Quaternion.identity;
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion qz = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        angulos.y = ( angulos.y + (1* velocityRotation)) %360;
        //rotation z-> x -> y
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        transform.rotation = r;
    }
}
