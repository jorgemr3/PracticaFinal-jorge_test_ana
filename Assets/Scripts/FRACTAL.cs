// using UnityEngine;
// using System.Threading;

// public class CantorSet : MonoBehaviour
// {
//     public int ancho = 800;      // Ancho del conjunto de Cantor
//     public int alto = 800;     // Alto del conjunto de Cantor
//     public int iteraciones = 5;   // Número de iteraciones para generar el conjunto de Cantor
//     public float Separacion = 10f;      // Espacio entre las iteraciones en el eje Y

//     private Texture2D textura;
//     private Color[] colorcitosArray;
//     private bool actualizado;
//     private object bufferLock;

//     void Awake()
//     {
//         textura = new Texture2D(ancho, alto);
//         colorcitosArray = new Color[ancho * alto];
//         actualizado = false;
//         bufferLock = new object();
//     }

//     void Start()
//     {
//         GenerateCantorSet();
//     }

//     void Update()
//     {
//         if (actualizado) // Si el buffer contiene los colores, aplica la textura
//         {
//             ApplyBufferToTexture();
//             actualizado = false;
//         }
//     }

//     public void GenerateCantorSet()
//     {
//         ThreadStart threadStart = new ThreadStart(LockCantorSet);
//         Thread thread = new Thread(threadStart);
//         thread.Start();
//     }

//     private void LockCantorSet()
//     {
//         // Inicializa el array de colores a blanco
//         for (int i = 0; i < colorcitosArray.Length; i++)
//         {
//             colorcitosArray[i] = Color.white;
//         }

//         // Comienza a dibujar el conjunto de Cantor
//         DibujarFractal(new Vector3(0, alto / 2), ancho, iteraciones);

//         lock (bufferLock){     actualizado = true;    }
//     }

//     private void DibujarFractal(Vector3 posicionInicial, float Largo, int iteraciones)
//     {
//         if (iteraciones != 0)
//         {
//             float NuevoLargo = Largo / 3f;
//             DibujarFractal(posicionInicial, NuevoLargo, iteraciones - 1);
//             DibujarFractal(posicionInicial + new Vector3(2 * NuevoLargo, -Separacion, 0), NuevoLargo, iteraciones - 1);
//         }
//         else
//         {
//             Dibujarlinea(posicionInicial, Largo);
//         }
//     }

//     private void Dibujarlinea(Vector3 posicionInicial, float longitud)
//     {
//         int InicioEnX = Mathf.RoundToInt(posicionInicial.x);
//         int InicioEnY = Mathf.RoundToInt(posicionInicial.y);
//         int FinalenX = Mathf.RoundToInt(posicionInicial.x + longitud);

//         for (int x = InicioEnX; x < FinalenX; x++)
//         {
//             if (x >= 0 && x < ancho && InicioEnY >= 0 && InicioEnY < alto)
//             {
//                 lock (bufferLock)
//                 {
//                     colorcitosArray[x + InicioEnY * ancho] = Color.black;
//                 }
//             }
//         }
//     }

//     private void ApplyBufferToTexture()
//     {
//         lock (bufferLock)
//         {
//             textura.SetPixels(colorcitosArray);
//             textura.Apply();
//         }

//         GetComponent<Renderer>().material.mainTexture = textura;
//     }
// }

// using UnityEngine;
// using System.Threading;

// public class Mandelbrot : MonoBehaviour
// {
//     public int ancho = 800;

//     public int alto = 800;

//     public int LimiteIteraciones = 1000;
//     public float zoom = 1f;
//     public float offsetX = 0f;
//     public float offsetY = 0f;
    
//     private Texture2D fractal;
//     private Color[] ColoresArray;
//     private bool Actualizado;
//     private object bufferLock;

//     void Awake()
//     {
//         fractal = new Texture2D(ancho, alto); 
//         ColoresArray = new Color[ancho * alto];
//         Actualizado = false;
//         bufferLock = new object();
//         Debug.Log("Fractal Inicializado ");
//     }

//     void Start()
//     {
//         Debug.Log("Generando tu Fractal... ");
//         GenerarFractal();
//         Debug.Log("Fractal Generado exitosamente ");
//     }

//     void Update()
//     {
//         if (Actualizado) //si el buffer contiene los colores entonces aplica la textura
//         {
//             AplicarBufferaTextura();
//             Debug.Log("Fractal Actualizado ");
//             Actualizado = false;
//         }else{
//             Debug.Log("Fractal sin actualizar ");
//         }
//     }

//     public void GenerarFractal()
//     {
//         Debug.Log("Generando el hilo para el fractal... ");
//         ThreadStart hiloSecundario = new ThreadStart(LockFractal);
//         Thread thread = new Thread(hiloSecundario);
//         Debug.Log("Hilo secundario generado ");
//         thread.Start();
//          Debug.Log("Hilo secundario iniciado! ");
//     }

//     private void LockFractal()
//     {
//         for (int x = 0; x < ancho; x++)
//         {
//             for (int y = 0; y < alto; y++)
//             {
//                 Debug.Log("Antes de normalizar ");
//                 float real = Normalizacion(x, 0, ancho, -2.5f / zoom + offsetX, 1.5f / zoom + offsetX);
//                 float imag = Normalizacion(y, 0, alto, -2f / zoom + offsetY, 2f / zoom + offsetY);
//                 Debug.Log("Despues de normalizar ");
//                 Debug.Log("Calculando el fractal... ");
//                 int Iteraciones = CalculaFractal(real, imag);
//                 Color color = Color.Lerp(Color.black, Color.white, (float)Iteraciones / LimiteIteraciones);
                
//                 lock (bufferLock)
//                 {
//                     ColoresArray[x + y * ancho] = color;
//                 }
//             }
//         }

//         lock (bufferLock)
//         {
//             Actualizado = true;
//         }
//     }

//     private void AplicarBufferaTextura()
//     {
//         lock (bufferLock)
//         {
//             fractal.SetPixels(ColoresArray);
//             Debug.Log("Aplicando colores al fractal... ");
//             fractal.Apply();
//             Debug.Log("Fractal coloreado correctamente ");
//         }
//         Debug.Log("Aplicando textura a tu fractal... ");
//         GetComponent<Renderer>().material.mainTexture = fractal;
//         Debug.Log("textura aplicada correctamente ");
//     }

//     private int CalculaFractal(float real, float imag)
//     {
//         float zr = 0f;
//         float zi = 0f;
//         int iteraciones = 0;
//         Debug.Log("valores inicializados correctamente para calcular ");

//         while (zr * zr + zi * zi < 4 && iteraciones < LimiteIteraciones)
//         {
//             Debug.Log("Calculando... ");   
//             float temporal = zr * zr - zi * zi + real;
//             zi = 2 * zr * zi + imag;
//             zr = temporal;
//             iteraciones++;
//             Debug.Log(iteraciones);
//         }
//         Debug.Log("calculado correctamente");
//         return iteraciones;
//     }

//     private float Normalizacion(int value, int min, int max, float newMin, float newMax) //nor
//     {
//         return (value - min) * (newMax - newMin) / (max - min) + newMin;
//     }
// } 

using UnityEngine; //SIN HILOS

public class Mandelbrot : MonoBehaviour
{
    public int width = 800;
    public int height = 800;
    public int maxIterations = 1000;
    public float zoom = 1f;
    public float offsetX = 0f;
    public float offsetY = 0f;
    Texture2D mandelbrotTexture;


    void Awake(){
        mandelbrotTexture = new Texture2D(width, height);
    }
    void Start()
    {
        GenerateMandelbrot();
    }

    public void GenerateMandelbrot()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float real = Map(x, 0, width, -2.5f / zoom + offsetX, 1.5f / zoom + offsetX);
                float imag = Map(y, 0, height, -2f / zoom + offsetY, 2f / zoom + offsetY);
                int iterations = CalculateMandelbrot(real, imag);
                Color color = Color.Lerp(Color.black, Color.white, (float)iterations / maxIterations);
                mandelbrotTexture.SetPixel(x, y, color);
            }
        }
        mandelbrotTexture.Apply();
        GetComponent<Renderer>().material.mainTexture = mandelbrotTexture;
    }

    int CalculateMandelbrot(float real, float imag)
    {
        float zr = 0f, zi = 0f;
        int iterations = 0;

        while (zr * zr + zi * zi < 4 && iterations < maxIterations)
        {
            float temp = zr * zr - zi * zi + real;
            zi = 2 * zr * zi + imag;
            zr = temp;
            iterations++;
        }
        return iterations;
    }

    float Map(int value, int min, int max, float newMin, float newMax)
    {
        return (value - min) * (newMax - newMin) / (max - min) + newMin;
    }
} 