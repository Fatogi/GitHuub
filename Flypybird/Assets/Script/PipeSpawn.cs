using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeSpawn : MonoBehaviour
{
    //Global variables
    [SerializeField] private Point point;
    [SerializeField] public float holeSize = 1f;
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp,pipeDown;
    [SerializeField] private float spawnInterval = 1;
    //variable penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        // Memulai Spawning 
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSpawn()
    {
        //Menjalankan Fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Menhentikan Coroutine IeSpawn jika sebeumnya sudah di jalankan
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //menduplikasi game object pipeUp dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        //menduplikasi game object pipeDown dan menempatkan posisinya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
       
        int number2 = Random.Range(0,5);
        int number = Random.Range(5,10);
        newPipeUp.transform.position += Vector3.up * (number/2);
        newPipeDown.transform.position += Vector3.down * (number2 / 2);

        //Mengaktifkan game object newPipeUp
        newPipeUp.gameObject.SetActive(true);
        
        //Mengaktifkan game object newPipeUp
        newPipeDown.gameObject.SetActive(true);

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up;
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //Jika Burung mati maka menhentikan pembuatan Pipa Baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            //Membuat Pipa Baru
            SpawnPipe();

            //Menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public Vector3 y { get; set; }
}
