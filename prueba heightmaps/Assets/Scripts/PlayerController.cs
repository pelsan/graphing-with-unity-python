using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aqui se puede usar un namespace para etiquetar con otro nombre la clase, o renombrarla
// using Aleatoreo = UnityEngine.Random;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePreFab;
   // public GameObject terrenoPreFab;
    public Terrain terreno = new Terrain();
    private float posX;
    private float posY;
    private float posZ;
    public float rango = 100f;
    public float volumen = 1f;
    Vector3 myVector;
    List<Vector3> miLista = new List<Vector3>();

    public int depth = 20;
    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    // PROPIEDADES
    //[HideInInspector]  Este lo ocultara del editor de Unity
    [Range(0, 20)] // Range para signar un rango en el editor de Unity
    [SerializeField] // recomendable ponerlo y usar private para dar mejor acceso seguro a la variable
    [Tooltip("Velocidad lineal maxima del coche")]
    // Aparece el texto en el editor del Editor de unity
    private float speed = 10.0f;

    [Range(0, 90),
     SerializeField,
     Tooltip("Velocidad de giro maxima del coche")]
    public float turnSpeed = 10f;

    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //La Velocidad va a ser fija 
        this.transform.Translate(speed * Time.deltaTime * Vector3.forward);
        //La entrada vertical va a controlar la rotacion en las X
        this.transform.Rotate(turnSpeed * Time.deltaTime * Vector3.right * verticalInput);
        //LA entrada horizontal va a controlas la rotacion en las Y
        this.transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);

        // Acciones del Personaje 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pruebaejes();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            PruebaAleatorea();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            speed = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            speed = 3f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            speed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            speed = 9f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CargaArchivo();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            CargaArchivoTerreno();
        }
    }
// Seccion de Metodos 
    void PruebaAleatorea()
    {
        int n = 32000;

        for (int i = 1; i <= n; i++)
        {
            // Creamos un vector que va a dar la posicion del objeto
            float posX = Random.Range(-rango, rango);
            float posY = Random.Range(-rango, rango);
            float posZ = Random.Range(-rango, rango);
            myVector = new Vector3(posX, posY, posZ);

            //Creamos objetos en el eje de las Z
            Instantiate(projectilePreFab, myVector, projectilePreFab.transform.rotation);
        }
    }

    void Pruebaejes()
    {
        // Creacion de tres ejes de esferas en el eje de las X, Y y Z
        //
        int n = 100;
        for (int i = 1; i <= n; i++)
        {
            // Creamos un vector que va a dar la posicion del objeto
            //myVector = new Vector3(0.0f, 1.0f, 0.0f);
            myVector = new Vector3((float) i, 1.0f, 0.0f);

            //Creamos objetos en el eje de las X
            Instantiate(projectilePreFab, myVector, projectilePreFab.transform.rotation);
        }

        n = 100;
        for (int i = 1; i <= n; i++)
        {
            // Creamos un vector que va a dar la posicion del objeto
            myVector = new Vector3(0.0f, (float) i, 0.0f);

            //Creamos objetos en el eje de las Y
            Instantiate(projectilePreFab, myVector, projectilePreFab.transform.rotation);
        }

        n = 100;
        for (int i = 1; i <= n; i++)
        {
            // Creamos un vector que va a dar la posicion del objeto
            myVector = new Vector3(0.0f, 1.0f, (float) i);

            //Creamos objetos en el eje de las Z
            Instantiate(projectilePreFab, myVector, projectilePreFab.transform.rotation);
        }
    }

    void CargaArchivo()
    {
        Vector3 csvVector;
        int counter = 0;
        string line;
        //string spath = "C:\Users\pelsa\Documents\Proyectos\Unity\graphing-with-unity-python\python\";
        //string spath = 'C:\Users\pelsa\Documents\Proyectos\Unity\graphing-with-unity-python\python\';
        string spath = "C:\\Users\\pelsa\\Documents\\Proyectos\\Unity\\graphing-with-unity-python\\python\\";
        string sfile = "XYZEDADTOTALES.csv";
        string cargar = spath + sfile;
        System.IO.StreamReader file = 
        new System.IO.StreamReader(@cargar);
        //new System.IO.StreamReader(@"d:\grafico.csv");
        //new System.IO.StreamReader(@"C:\Users\pelsa\TEMPOS\XYZESTADOSTOTALES.csv");


        while ((line = file.ReadLine()) != null)
        {
            //var line = reader.ReadLine();
            var values = line.Split(',');
            csvVector = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
            miLista.Add(csvVector);

            counter++;
        }

        Debug.Log("registros leidos: " + miLista.Count);
        // Vamos a graficarlos
        for (int i = 0; i < miLista.Count; i++)
        {
            //Creamos objetos en el eje de las Z
            Instantiate(projectilePreFab, miLista[i], projectilePreFab.transform.rotation);
        }
    }

    void CargaArchivoTerreno()
    {
        terreno.terrainData = GeneraTerreno(terreno.terrainData);
        //terrenoPreFab.terrainData = GeneraTerreno(terrenoPreFab.terrainData);
        myVector = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(terreno, myVector, terreno.transform.rotation);
    }

    TerrainData GeneraTerreno(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float [width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
                //Debug.Log(" Valor  x=" + x.ToString() + " y=" + y.ToString() + " altura=" + heights[x, y]);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float) x / width * scale;
        float yCoord = (float) y / height * scale;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}

