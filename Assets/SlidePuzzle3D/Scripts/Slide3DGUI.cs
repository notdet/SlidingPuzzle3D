using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slide3DGUI : MonoBehaviour
{
    [SerializeField] GameObject gameWonObject;

    [SerializeField] float angularSpeed = 360f;

    void Update()
    {
        //cameraTransform = FindObjectOfType<Camera>().transform;
        //gameWonObject.SetActive(SlidingPuzzle3DMain.gameWon);


    }

    public void RotateLeft() // CALLED FROM BUTTON
    
    {
        //Globál Y ban kéne
        Transform camRootTrns = transform;
        transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
        

    }

    public void Restart() // CALLED FROM BUTTON
    {
        SceneManager.LoadScene("SlidePuzzle3D");
    }

    /*
    Vector3 inputDirection = new(xDirection, 0, zDirection);
    bool isWalking = inputDirection != Vector3.zero;
    playerAnimator.SetBool("IsWalking", isWalking);

        if (inputDirection != Vector3.zero)
        {
            Vector3 globalDirection = cameraTransform.TransformDirection(inputDirection);
    globalDirection.y = 0;
            globalDirection.Normalize();

            inputDirection.Normalize();

            Transform t = transform;

    Vector3 velocity = inputDirection * speed;
    t.position += velocity* Time.deltaTime;

    Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
    Quaternion currentRotation = t.rotation;

    t.rotation = Quaternion.RotateTowards(
        currentRotation, targetRotation, angularSpeed* Time.deltaTime);
        }
    */


    //void Update()
    //{
    //    int hp = damageReceiver.CurrentHp;

    //    hpText.text = hp.ToString();
    //    gpText.text = collector.CollectedValue.ToString();

    //    int maxHp = damageReceiver.MaxHp;
    //    float hpRate = (float)hp / maxHp;

    //    // hpText.color = Color.Lerp(minColor, maxColor, hpRate);
    //    hpText.color = hpGradient.Evaluate(hpRate);

    //    gameOverObject.SetActive(!damageReceiver.IsAlive());
    //}

    //public void Restart() // CALLED FROM BUTTON
    //{
    //    SceneManager.LoadScene("3DGame");
    //}

}
/*
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    [SerializeField] TMP_Text gpText;
    [SerializeField] GameObject gameOverObject;

    [SerializeField] DamageReceiver damageReceiver;
    [SerializeField] Collector collector;

    //[SerializeField] Color minColor = Color.red;
    //[SerializeField] Color maxColor = Color.green;
    [SerializeField] Gradient hpGradient;

    void Update()
    {
        int hp = damageReceiver.CurrentHp;

        hpText.text = hp.ToString();
        gpText.text = collector.CollectedValue.ToString();

        int maxHp = damageReceiver.MaxHp;
        float hpRate = (float)hp / maxHp;

        // hpText.color = Color.Lerp(minColor, maxColor, hpRate);
        hpText.color = hpGradient.Evaluate(hpRate);

        gameOverObject.SetActive(!damageReceiver.IsAlive());
    }

    public void Restart() // CALLED FROM BUTTON
    {
        SceneManager.LoadScene("3DGame");
    }

}
*/