//using System.Collections;
//using System.Collections.Generic;
//using JetBrains.Annotations;
//using System.Runtime.CompilerServices;
//using static UnityEngine.RuleTile.TilingRuleOutput;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//class LookAt : MonoBehaviour
//{
//    [SerializeField] Transform target;
//    void Update()
//    {
//        // Rotation
//        Vector3 direction = target.position - transform.position;
//        transform.rotation = Quaternion.LookRotation(direction);
//    }
//}


public class SlidingPuzzle3DMain : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null; //miért private?
    private Camera _camera;

    [SerializeField] LayerMask raycastMask;

    [Space]
    [SerializeField] public float csuszajgataasSpeed = 4;
    [SerializeField] private TilesScript[] tiles;

    private int emptySpaceIndex = 8;

    [SerializeField] private Transform child1 = null; // Reference to "3x3x8" object
    [SerializeField] private Transform child2 = null;
    //int swapCounter = 0;
    public bool gameWon = false;

    [SerializeField] GameObject gameWonObject;
    //readonly bool gameWonUI = Camera.main.GetComponent<SlidingPuzzle3DMain>().gameWon;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();


    }



    void Update() //private?? //void OnMouseDown()
    //void OnMouseDown()
    {

        //bool gameWonUI = Camera.main.GetComponent<SlidingPuzzle3DMain>().gameWon;
        //gameWonObject.SetActive(gameWonUI); //miatokomkellide!!!
        if (gameWon == true)
        {
            gameWonObject.SetActive(true);
        }



        if (gameWon)
        {
            return;
        }
        Vector3 mousePos = Input.mousePosition;

        Ray ray = _camera.ScreenPointToRay(mousePos);

        bool talalat = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, raycastMask) &&
                   hit.collider.TryGetComponent<TilesScript>(out _); //<ExplosionSurface>


        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 mousePos = Input.mousePosition;
            //RaycastHit hit = Physics.Raycast(ray.origin, ray.direction); //2Ds basszameg ennek nem kell maxdistane, 3dsnek igen

            if (talalat)
            {
                //Debug.Log(talalat.transform.name);
                if (Vector3.Distance(emptySpace.position, hit.transform.position) < 4.5f)
                {
                    //Vector3 lastEmptySpacePosition = emptySpace.position;
                    //emptySpace.position = hit.transform.position;
                    //hit.transform.position = lastEmptySpacePosition;

                    //Vector3 lastEmptySpacePosition = emptySpace.position;
                    //TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    //emptySpace.position = thisTile.targetPosition;
                    //thisTile.targetPosition = lastEmptySpacePosition;

                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    (thisTile.targetPosition, emptySpace.position) = (emptySpace.position, thisTile.targetPosition); //tupple ?

                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;

                    //(hit.transform.position, emptySpace.position) = (emptySpace.position, hit.transform.position);

                    //Debug.Log(emptySpace.position);
                }
            }
        }

        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.inRightPlace)
                {
                    correctTiles++;
                }

            }

        }

        if (correctTiles == tiles.Length - 1 && !gameWon)
        {
            SwapChildrenPositions();
            gameWon = true;
        }
    }

    private void SwapChildrenPositions()
    {
        // Ensure that child1 and child2 are assigned before swapping
        if (child1 != null && child2 != null)
        {
            // Swap the Y-positions of the two children  //lehet tupple
            Vector3 tempPosition = child1.position;
            child1.position = child2.position;
            child2.position = tempPosition;
        }
        else
        {
            Debug.LogWarning("Child1 or Child2 is not assigned.");
        }
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != tiles.Length - 1)
        {
            var tileOn7LastPos = tiles[tiles.Length - 1].targetPosition; //leght helyett 7-es index volt
            tiles[tiles.Length - 1].targetPosition = emptySpace.position;
            emptySpace.position = tileOn7LastPos;
            tiles[emptySpaceIndex] = tiles[tiles.Length - 1];
            tiles[tiles.Length - 1] = null;
            emptySpaceIndex = tiles.Length - 1;
        }

        int invertion = 0;
        do
        {


            for (int i = 0; i <= tiles.Length - 1; i++)
            {
                if (tiles[i] != null)
                {
                    var lastPos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(i, tiles.Length - 1); //(i, tiles.Length - 1) volt
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
                invertion = GetInversions();
                Debug.Log("Shuffled");
                Debug.Log(invertion);
            }
        } while (invertion % 2 != 0); //!!!!!!!!!!!!!!!!!!!!!!! még mindig kever kirakhatatlant és null inversionoket ír debugba..


        // Swap the Y-positions of the two children
        //Vector3 tempPosition = child1.position;
        //child1.position = child2.position;
        //child2.position = tempPosition;
        SwapChildrenPositions();
    }

    public int findIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }


    int GetInversions()  //valószínűleg itt a hiba a shuffle-t elronthatja
    {
        int inversionsSum = 0;

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                int thisTileInvertion = 0;

                for (int j = i + 1; j < tiles.Length; j++)
                {
                    if (tiles[j] != null)
                    {
                        if (tiles[i].number > tiles[j].number && tiles[i].number != 0 && tiles[j].number != 0)
                        {
                            thisTileInvertion++;
                        }
                    }
                }

                inversionsSum += thisTileInvertion;
            }
        }

        return inversionsSum;
    }

    public void Restart() // CALLED FROM BUTTON
    {
        SceneManager.LoadScene("SlidePuzzle3D");
    }


}

/*

 If N is odd, then puzzle instance is solvable if number of inversions is even in the input state.
If N is even, puzzle instance is solvable if 
the blank is on an even row counting from the bottom (second-last, fourth-last, etc.) and number of inversions is odd.
the blank is on an odd row counting from the bottom (last, third-last, fifth-last, etc.) and number of inversions is even.
For all other cases, the puzzle instance is not solvable.


Általánosan véve egy adott N szélességű rács esetén meg tudjuk állapítani, hogy egy N*N - 1 puzzle megoldható-e vagy sem az alábbi egyszerű szabályokkal:

- Ha N páratlan, akkor a puzzle példány megoldható, ha a fordítások száma páros a kezdeti állapotban.
- Ha N páros, a puzzle példány akkor megoldható, ha a következők közül az egyik teljesül:
1. A blank (üres) hely egy páros sorról van számolva lefelé (utolsó előtti, harmadik utolsó, stb.), és a fordítások száma páratlan.
2. A blank (üres) hely egy páratlan sorról van számolva lefelé (utolsó, harmadik utolsó, stb.), és a fordítások száma páros.

Minden más esetben a puzzle példány nem megoldható.

Mi az egy fordítás itt?
Feltételezve, hogy a csempék egyetlen sorban vannak felsorolva (1D tömb) a N sor helyett (2D tömb), egy csempe pár (a, b) alkot egy fordítást,
 ha a megjelenik b előtt, de a > b.

Példa a fenti szabályokra:
Tekintsük a csempéket egy sorban felsorolva, így: 2 1 3 4 5 6 7 8 9 10 11 12 13 14 15 X
Ebben a rácsban csak 1 fordítás található, azaz (2, 1).

Ez a szabályokon alapuló megközelítés segíthet meghatározni egy adott puzzle példány megoldhatóságát és eldönteni,
 hogy lehetséges-e az elemek helyes sorrendbe rendezése az üres hely segítségével.

  */


/*
int GetInversions() //4x4-esre működött neki
{
    int inversionsSum = 0;
    for (int i = 0; i < tiles.Length; i++)
    {
        int thisTileInvertion = 0;
        for (int j = i; j < tiles.Length; j++)
        {
            if (tiles[j] != null)
            {
                if (tiles[i].number > tiles[j].number)
                {
                    thisTileInvertion++;
                }
            }
        }
        inversionsSum += thisTileInvertion;
    }
    return inversionsSum;
}
*/

/*
void Update()
{
    Vector3 mousePos = Input.mousePosition;

    Ray ray = Camera.main.ScreenPointToRay(mousePos);

    bool canExplode = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, raycastMask) &&
                      hit.collider.TryGetComponent<ExplosionSurface>(out _);

    if (canExplode)
    {
        // Debug.Log(hit.collider.name);
        cursorObject.position = hit.point;

        if (Input.GetMouseButtonDown(0))
        {
            Explode(hit.point);
        }
    }

    cursorRenderer.enabled = canExplode;
}
*/