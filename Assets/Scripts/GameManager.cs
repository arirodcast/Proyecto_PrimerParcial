using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public float velocidad = 2;
    public GameObject platform;
    public GameObject p_suspendida;
    public GameObject p_suspendida2;

    public GameObject pumpkin;
    public GameObject taigatree;
    public Renderer fondo;
    //public GameObject taigatalltree;

    

    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> columnas;
    public List<GameObject> fila1;
    public List<GameObject> fila2;
    public List<GameObject> obstaculos;

    // Start is called before the first frame update
    void Start()
    {
        // Creando el bucle en el mapa
        for (int i = 0; i < 21; i++)
        {
            // +i es para que se recorra un lugar 
            columnas.Add(Instantiate(platform, new Vector2(-10+i, -3),Quaternion.identity));
        }

        for (int i = 0; i < 1; i++)
        {
            fila1.Add(Instantiate(p_suspendida, new Vector2(-15, 1), Quaternion.identity));
        }

        for (int i = 0; i < 1; i++)
        {
            fila2.Add(Instantiate(p_suspendida2, new Vector2(-15, 0), Quaternion.identity));
        }

        // creando obstáculos
        obstaculos.Add(Instantiate(pumpkin, new Vector2(15, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(taigatree, new Vector2(8, -2), Quaternion.identity));
        //obstaculos.Add(Instantiate(taigatalltree, new Vector2(14, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;


            // moviendo mapa

            // moviendo la plataforma del jugador
            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].transform.position.x <= -10)
                {
                    columnas[i].transform.position = new Vector3(10, -3, 0);
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            // moviendo las pistas suspendidas del aire
            for (int i = 0; i < fila1.Count; i++)
            {
                if (fila1[i].transform.position.x <= -20)
                {
                    fila1[i].transform.position = new Vector3(20, 1, 0);
                }
                fila1[i].transform.position = fila1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            for (int i = 0; i < fila2.Count; i++)
            {
                if (fila2[i].transform.position.x <= -15)
                {
                    fila2[i].transform.position = new Vector3(15, 0, 0);
                }
                fila2[i].transform.position = fila2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }


            // moviendo obstáculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObstacle = Random.Range(8, 20);
                    obstaculos[i].transform.position = new Vector3(randomObstacle, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
