using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveForce;
    public float maxVel;
    Rigidbody2D m_rb;
    bool m_isTrisggerd;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();

    }
    public void Trigger()
    {
        if (m_rb)
        {
            m_isTrisggerd = true;
            m_rb.isKinematic = false;
            m_rb.AddForce(new Vector2(moveForce, moveForce));
            transform.SetParent(null);
        }
    }
    private void FixedUpdate()
    {
        if (m_rb && m_isTrisggerd)
        {
            m_rb.velocity = new Vector2(Mathf.Clamp(m_rb.velocity.x, -maxVel, maxVel), Mathf.Clamp(m_rb.velocity.y, -maxVel, maxVel));
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagConsts.BRICK))
        {
            brick brick = col.gameObject.GetComponent<brick>();
            if (brick)
            {
                brick.Hit();
            }
        }
        if (col.gameObject.CompareTag(TagConsts.STICKER))
        {
            if (m_rb.velocity.x > 0)
            {
                m_rb.velocity = Vector2.zero;
                m_rb.AddForce(new Vector2(moveForce, moveForce));
            }
            else if (m_rb.velocity.x < 0)
            {
                m_rb.AddForce(new Vector2(-moveForce, moveForce));
            }
            if (col.gameObject.CompareTag(TagConsts.WALL_T))
            {
                if (m_rb.velocity.x > 0)
                {
                    m_rb.velocity = Vector2.zero;
                    m_rb.AddForce(new Vector2(moveForce, -moveForce));
                }
                else if (m_rb.velocity.x < 0)
                {
                    m_rb.AddForce(new Vector2(-moveForce, -moveForce));

                }
            }
            if (col.gameObject.CompareTag(TagConsts.WALL_L))
            {
                if (m_rb.velocity.y > 0)
                {
                    m_rb.velocity = Vector2.zero;
                    m_rb.AddForce(new Vector2(moveForce, moveForce));
                }
                else if (m_rb.velocity.y < 0)
                {
                    m_rb.AddForce(new Vector2(moveForce, -moveForce));
                    ;
                }
            }
            if (col.gameObject.CompareTag(TagConsts.WALL_R))
            {
                if (m_rb.velocity.y > 0)
                {
                    m_rb.velocity = Vector2.zero;
                    m_rb.AddForce(new Vector2(-moveForce, moveForce));
                }
                else if (m_rb.velocity.y < 0)
                {
                    m_rb.AddForce(new Vector2(-moveForce, -moveForce));

                }
            }
        }
    }
    IEnumerator OpengameoverDialog()
    {
        yield return new WaitForSeconds(1f);
        GameGUI.Ins.gameoverDialog.Show(true);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagConsts.DEADZONE))
        {
           
            CineController.Ins.ShakeTrigger();
            StartCoroutine(OpengameoverDialog());
            AudioController.Ins.PlaySound(AudioController.Ins.lose);

        }
    }
}