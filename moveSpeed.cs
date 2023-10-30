using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudMovement : MonoBehaviour

{
    public GameManager gameManager;
    // ������ �̵� �ӵ�. ������ �ִ� �ӵ� ����
    private Vector2 screenBounds;   // ȭ���� ��谪
    private void Awake()
    {
        FindObjectOfType<GameManager>().OnGameOver.AddListener(StopMoveSpeed);
    }
    private void Start()
    {
        // ȭ���� ���� ��谪�� ����ϴ�.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    private void Update()
    {
        // ������ �������� �̵�
        transform.Translate(Vector2.left * Constants.SSPEED * Time.deltaTime);

        // ������ ��ġ�� ȭ�� ���� ��躸�� ������ ������Ʈ�� ��Ȱ��ȭ
        if (transform.position.x < screenBounds.x - 1)  // -1�� ������ �ʺ�
        {
            // ������ ������Ʈ Ǯ�� ��ȯ
            gameObject.SetActive(false);
        }
    }
    public void StopMoveSpeed()
    {
        this.enabled = false;
    }
}


