//https://marosicsaba.notion.site/Sim-tott-mozg-s-1d921f34493344818f59e42dc1b11bbc
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
//using static UnityEngine.RuleTile.TilingRuleOutput;


public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    public int number;
    float csusz;
    public bool inRightPlace;

    [SerializeField] float smoothTime = 0.3f; // Csabatut
    [SerializeField] float maxSpeed = 40f; // Csabatut
    Vector3 velocity;   // Csabatut

    //public bool isMoving = false;

    //private MeshRenderer

    //[Header("Correct Position Material")]
    //[SerializeField] Material correctPositiondMaterial;
    ////[SerializeField] float correctPositiondMaterialTime = 0.5f;

    // Start is called before the first frame updatee
    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
    }

    //correctositionstuff maretialt tekergeti, nem jól <<<
    //Material[] cachedMaterial; <<<

    // Update is called once per frame

    void OnValidate()
    {
        csusz = Camera.main.GetComponent<SlidingPuzzle3DMain>().csuszajgataasSpeed;
    }
    // Update is called once per frame



    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, maxSpeed);
        // Utolsó paramétert nem írom ki mert a default value is Time.deltaTime

        //transform.position = Vector3.Lerp(transform.position, targetPosition, csusz * Time.deltaTime);  //<<< EZ VOLT EDDIGG!!!
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);

        //correctositionstuff maretialt tekergeti, nem jól <<<<<<<<<<<<<<<<<<<<<<<<
        // MeshRenderer[] allRenderers = GetComponentsInChildren<MeshRenderer>();
        //cachedMaterial = new Material[allRenderers.Length];


        if (targetPosition == correctPosition)
        {
            /*for (int i = 0; i < allRenderers.Length; i++)
            {
                //cachedMaterial[i] = allRenderers[i].material;  //correctositionstuff maretialt tekergeti, nem jól <<<<<<<<<<<<<<<<<<<<<<<<
                //allRenderers[i].material = correctPositiondMaterial;
            }*/

            inRightPlace = true;
        }
        else
        {
            /*for (int i = 0; i < allRenderers.Length; i++)
            {
                //allRenderers[i].material = cachedMaterial[i];
            }*/

            inRightPlace = false;
        }

    }

    //DÁÁÁÁÁÁH


    //Material[] cachedMaterial;

    //void StartInvincibility()
    //{
    //    Collider c = GetComponent<Collider>();
    //    c.enabled = false;

    //    MeshRenderer[] allRenderers = GetComponentsInChildren<MeshRenderer>();
    //    cachedMaterial = new Material[allRenderers.Length];

    //    for (int i = 0; i < allRenderers.Length; i++)
    //    {
    //        cachedMaterial[i] = allRenderers[i].material;
    //        allRenderers[i].material = damagedMaterial;
    //    }

    //    Invoke(nameof(EndInvincibility), damagedTime);
    //}

    //void EndInvincibility()
    //{
    //    Collider c = GetComponent<Collider>();
    //    c.enabled = true;

    //    MeshRenderer[] allRenderers = GetComponentsInChildren<MeshRenderer>();

    //    for (int i = 0; i < allRenderers.Length; i++)
    //    {
    //        allRenderers[i].material = cachedMaterial[i];
    //    }
    //}



}
//void Update()
//{

//    transform.position = Vector3.Lerp(transform.position, targetPosition, csusza * Time.deltaTime);


//    //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
//    //nextRot = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
//    //csuszajgataasSpeed


//    //MeshRenderer[] allRenderers = GetComponentsInChildren<MeshRenderer>();
//    //cachedMaterial = new Material[allRenderers.Length];


//    //if (targetPosition == correctPosition)
//    //{
//    //    for (int i = 0; i < allRenderers.Length; i++)
//    //    {
//    //        cachedMaterial[i] = allRenderers[i].material;
//    //        allRenderers[i].material = correctPositiondMaterial;
//    //    }
//    //}
//    //else
//    //{
//    //    for (int i = 0; i < allRenderers.Length; i++)
//    //    {
//    //        allRenderers[i].material = cachedMaterial[i];
//    //    }
//    //}
//    //if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
//    //{
//    //     //if (transform.position == targetPosition) {
//    //     transform.position = targetPosition;
//    //     isMoving = false;
//    //}
//}
