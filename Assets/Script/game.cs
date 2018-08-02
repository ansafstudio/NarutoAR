using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {
    float turn_speed = 1.0f;
    public GameObject[] targetObject;

    public Animator[] animObjek;

    public GameObject mainMenu;

    bool NarutoOn;
    bool SazukeOn;
    bool ItachiOn;
    bool OrochimOn;

    bool looping;

    int markerActiveCount; //counter marker aktif;

    int a = 0;
    int b = 0;

    // Use this for initialization
    void Start ()
    {
        NarutoOn = false;
        SazukeOn = false;
        ItachiOn = false;
        OrochimOn = false;

        looping = false;

        markerActiveCount = 0;

	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu.activeSelf == true)
                Application.Quit();
            else
                mainMenu.SetActive(true);
        }
        
        UpdateActiveMarker();

        if (looping == false)
        {
            UpdateAnim();
        }

        //markerActiveCount = 0;
    }

    void UpdateActiveMarker()
    {
        for (int i = 0; i < targetObject.Length; i++)
        {
            SkinnedMeshRenderer thisRender = targetObject[i].GetComponent<SkinnedMeshRenderer>();

            if (targetObject[i].activeSelf && thisRender.isVisible)
            {
                //URUTAN Objek: 1.Naruto 2.Sazuke 3.Itachi 4.Orochim
                if (i == 0)
                {
                    NarutoOn = true;
                    //animObjek[i].SetInteger("attack", 1);
                    markerActiveCount++;
                }
                else if (i == 1)
                {
                    SazukeOn = true;
                    //animObjek[i].SetInteger("attack", 1);
                    markerActiveCount++;
                }
                else if (i == 2)
                {
                    ItachiOn = true;
                    markerActiveCount++;
                }
                else if (i == 3)
                {
                    OrochimOn = true;
                    markerActiveCount++;
                }
                a++;
            }
            else
            {
                if (i == 0)
                {
                    NarutoOn = false;
                    //animObjek[i].SetInteger("attack", 0);
                    markerActiveCount--;
                }
                else if (i == 1)
                {
                    SazukeOn = false;
                    markerActiveCount--;
                }
                else if (i == 2)
                {
                    ItachiOn = false;
                    markerActiveCount--;
                }
                else if (i == 3)
                {
                    OrochimOn = false;
                    markerActiveCount--;
                }
                b++;
            }
        }

        //UpdateAnim();
    }

    void UpdateAnim()
    {
        looping = true;
       // if (markerActiveCount == 2)
       //if(a == b)
        //{
            if (NarutoOn && SazukeOn)
            {
                //animObjek[0].SetInteger("attack", 0); //Naruto
                //animObjek[1].SetInteger("attack", 0); //Sazuke
                StartCoroutine(waitAnimAttack1(0, 1));
            }
            else if (NarutoOn && ItachiOn)
            {
                StartCoroutine(waitAnimAttack1(0, 2));
            }
            else if (NarutoOn && OrochimOn)
            {
                StartCoroutine(waitAnimAttack1(0, 3));
            }
            //else if (SazukeOn && ItachiOn)
            //{
            //    StartCoroutine(waitAnimAttack1(1, 2));
            //}
            //else if (SazukeOn && OrochimOn)
            //{
            //    StartCoroutine(waitAnimAttack1(1, 3));
            //}
            //else if (ItachiOn && OrochimOn)
            //{
            //    StartCoroutine(waitAnimAttack1(2, 3));
            //}
        //}
        else
        {
            animObjek[0].SetInteger("attack", 0); //Naruto
            animObjek[1].SetInteger("attack", 0); //Sazuke
            animObjek[2].SetInteger("attack", 0); //Itachi
            animObjek[3].SetInteger("attack", 0); //Orochim
            looping = false;
        }
        
        markerActiveCount = 0;
        a = 0;
        b = 0;
    }

    IEnumerator waitAnimAttack1(int a, int b)
    {

        yield return new WaitForSeconds(2);


        animObjek[a].SetInteger("attack", 1); // Naruto menyerang
        //animObjek[1].SetInteger("attack", 0); //Sazuke
        yield return new WaitForSeconds(animObjek[a].GetCurrentAnimatorClipInfo(0).Length);
        animObjek[a].SetInteger("attack", 0); // Naruto menyerang

        //yield return new WaitForSeconds(3);
        StartCoroutine(waitAnimAttack2(a, b));
    }

    IEnumerator waitAnimAttack2(int a, int b)
    {

        yield return new WaitForSeconds(2);


        //animObjek[0].SetInteger("attack", 0); // Naruto menyerang
        animObjek[b].SetInteger("attack", 1); //Sazuke
        yield return new WaitForSeconds(animObjek[1].GetCurrentAnimatorClipInfo(0).Length);
        animObjek[b].SetInteger("attack", 0); //Sazuke

        looping = false;
        //yield return new WaitForSeconds(3);
        //StartCoroutine(waitAnimAttack1(a, b));
    }

    //void rotateTowards(Vector3 to)
    //{

    //    Quaternion _lookRotation =
    //        Quaternion.LookRotation((to - naruto.transform.position).normalized);

    //    //over time
    //    transform.rotation =
    //        Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);

    //    //instant
    //    transform.rotation = _lookRotation;
    //}
}
