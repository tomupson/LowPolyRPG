using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertManager : MonoBehaviour
{
    public static AlertManager instance;

    private Queue<Alert> alerts;

    [SerializeField] private GameObject alertBox;
    [SerializeField] private Text alertNameText;
    [SerializeField] private Text alertText;

    Animator animator;

    [HideInInspector] public bool showingAlert = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else Debug.LogWarning("Multiple AlertManagers in scene");
    }

    void Start()
    {
        animator = alertBox.GetComponent<Animator>();
        alerts = new Queue<Alert>();
        alertBox.SetActive(false);
    }

    public void PushAlert(Alert alert)
    {
        alerts.Enqueue(alert);
        if (!showingAlert)
        {
            NextAlert();
        }
    }

    public void NextAlert()
    {
        showingAlert = true;

        Alert currentAlert = alerts.Dequeue();

        alertNameText.text = currentAlert.alertName;
        alertText.text = currentAlert.alertText;

        FadeAlertBoxIn();

        StartCoroutine(AlertDecay(currentAlert));
    }

    IEnumerator AlertDecay(Alert currentAlert)
    {
        yield return new WaitForSeconds(currentAlert.displayTime);

        FadeAlertBoxOut();

        if (alerts.Count > 0)
        {
            NextAlert();
        } else
        {
            showingAlert = false;
        }
    }

    void FadeAlertBoxIn()
    {
        alertBox.SetActive(true);
        animator.SetBool("isOpen", true);
    }

    void FadeAlertBoxOut()
    {
        animator.SetBool("isOpen", false);
    }

    public void HideAlertBox()
    {
        alertBox.SetActive(false);
    }
}