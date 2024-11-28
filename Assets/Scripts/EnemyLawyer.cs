using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLawyer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite LawyerA;
    public Sprite LawyerW;
    public Sprite LawyerD;
    public Sprite LawyerS;

    public JRPGManager JRPGManager;
    public GameObject PokemonLayout;

    // Start is called before the first frame update
    void Start()
    {
        PokemonLayout = GameObject.Find("Pokemon Layout");
        JRPGManager = PokemonLayout.GetComponent<JRPGManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log(JRPGManager.enemyArgument[JRPGManager.argumentSelector]);

        SpirtingIt();
    }

    void SpirtingIt()
    {
        switch (JRPGManager.argumentSelector)
        {
            case 0:
                ChangeSpriteA(LawyerA);
                break;
            case 1:
                ChangeSpriteW(LawyerW);
                break;
            case 2:
                ChangeSpriteD(LawyerD);
                break;
            case 3:
                ChangeSpriteS(LawyerS);
                break;
        }
    }

    void ChangeSpriteA(Sprite LawyerA)
    {
        spriteRenderer.sprite = LawyerA;
    }
    void ChangeSpriteW(Sprite LawyerW)
    {
        spriteRenderer.sprite = LawyerW;
    }
    void ChangeSpriteD(Sprite LawyerD)
    {
        spriteRenderer.sprite = LawyerD;
    }
    void ChangeSpriteS(Sprite LawyerS)
    {
        spriteRenderer.sprite = LawyerS;
    }
}
