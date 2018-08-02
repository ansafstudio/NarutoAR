using UnityEngine;
using System.Collections;

public class ObjectLookAt : MonoBehaviour {

    //public GameObject MarkerObject;
   // GameObject target;
    public GameObject[] targetObject;

    Quaternion[] initRot;

    //float Xaxis;
    //float Yaxis;
    //float Zaxis;

    // Use this for initialization
    void Start () {
        //initRot = MarkerObject.transform.rotation;

        //float Xaxis = MarkerObject.transform.rotation.x;
        //float Yaxis = MarkerObject.transform.rotation.y;
        //float Zaxis = MarkerObject.transform.rotation.z;


        for (int i = 0; i < targetObject.Length; i++)
        {
            initRot[i] = targetObject[i].transform.localRotation;
            //if (targetObject[i].activeSelf)
            //{
            //    print("sasa");
            //}
        }
    }
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(target);

       

       for (int i = 0; i < targetObject.Length; i++)
        {
            SkinnedMeshRenderer thisRender = targetObject[i].GetComponent<SkinnedMeshRenderer>();

            if (targetObject[i].activeSelf && thisRender.isVisible)
            {
				//target = targetObject[i];
                //print ("sasa "+i);

                this.gameObject.transform.LookAt(targetObject[i].transform);


                //transform.LookAt(target.transform);
            }
            //else
            //{
            //    this.gameObject.transform.localRotation = initRot[i];
            //}
        }        

		

        //transform.Rotate(Xaxis, Yaxis, Zaxis);


    }
}
