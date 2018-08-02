using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {
	public static Vector2 ukuran; //pendeklarasian ukuran
	public static Vector2 ukuranMax; //pendekalarasian ukuran max
	public static Vector3 posisiMax;
	public static Vector3 posisi; //pendeklarasian posisi

	public static Vector3 ukurstamina;
	public static Vector3 posstamina;
	bool die;
	
	void Awake () {
		ukurstamina = new Vector3(8.0f,0.5f,0);
		posstamina = new Vector3(4.1f,5.2f,0f);

		ukuranMax = transform.localScale; // untuk pendeklarasian nilai max ukuran
		ukuran = transform.localScale; //ukurstamina; //untuk pendeklarasian besar ukuran
		posisiMax = transform.localPosition;
		posisi = transform.localPosition; //posstamina; //untuk pendeklarasian posisi
		GetComponent<Renderer>().material.color = Color.yellow; //untuk pemberian warna awalan kotaknapas

	}
	
	// Use this for initialization
	void Start () {
		die = false;

        //ukurstamina = GameMgr.StaminaMusuh;
	}
	
	// Update is called once per frame
	void Update () {
        //if (ukuran.x >= 7.0 && GameMgr.StaminaMusuh.x != 0.0) //initial HP
        {
          //  ukuran.x = GameMgr.StaminaMusuh.x;
        }

        if (!IsInvoking("waktu")){ //pengecekan apakah sedang menjalakan/menginvoke waktu
			Invoke ("waktu",1); //jika tidak !insinvoking maka akan menjalankan invoke waktu dengan jeda 1
		}
		transform.localScale = ukuran;// digunakan untuk mengupdate ukuran sesuai tabrakan pada playercontroller
		transform.localPosition = posisi;// digunakan untuk mengupdate posisi sesuai tabrakan pada playercontroller
		ukuran = transform.localScale; //besarnya ukuran yang telah terupdate
		posisi = transform.localPosition; //posisi yang telah terupdate
		/*
		if (transform.localScale.x <=4) {
			renderer.material.color = Color.green; //untuk pemberian warna jika kotak napas berkurang 1/2
		}
		if (transform.localScale.x <=2) {
			renderer.material.color = Color.yellow; //untuk pemberian warna jika kotak napas sisa 1/4
		}
		if (transform.localScale.x >4) {
			renderer.material.color = Color.red; //untuk pemberian warna jika kotak napas kembali penuh
		}*/
		if (transform.localScale.x <= 0) { //jika ukuran transform x < 0 maka akan mengaktifkan scene gameover
			//StartCoroutine(main2_2.dead());
			//Application.LoadLevel(1);
			//print ("Mati");

		} 
		if(transform.localScale.x <= ukuranMax.x/2 && !die){
			StartCoroutine("Mati");
		}
	}
	
	void waktu(){ 

	}
	
	IEnumerator Mati(){
		//die = true;
		//GameObject.Find ("Mati").renderer.enabled = true;
		//yield return new WaitForSeconds(.5f);
		//GameObject.Find ("Mati").renderer.enabled = false;
		yield return new WaitForSeconds(.5f);
		//die = false;
	}

}
