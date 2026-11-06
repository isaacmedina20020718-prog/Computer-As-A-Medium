using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMana : MonoBehaviour
{
    public int Mana = 100;
    public TMP_Text ManaText;
    public Animator animator;
    // Start is called once before the first execution of Update after the
    //MonoBehaviour is created
    void Start()
    {
        ManaText.text = "Mana: " + Mana;
    }
    // Update is called once per frame
    void Update()
    {
        ManaText.text = "Mana: " + Mana;
        if (Keyboard.current != null &&
                Keyboard.current.mKey.wasPressedThisFrame &&
                Mana >= 10)
        {
            Mana -= 10;
            animator.SetBool("manaAttack", true);

        }
        else
        {
            animator.SetBool("manaAttack", false);
        }

    }
}
