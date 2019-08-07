/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 1;
    public bool canShoot = true;

    [SerializeField]
    private  MeshRenderer mesh;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private Transform shotSpawn;

    private float maxLeft = -8;
    private float maxRight = 8;

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            ShootLaser();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    public void ShootLaser()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject laserShot = SpawnLaser();
        laserShot.transform.position = shotSpawn.position;
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    public GameObject SpawnLaser()
    {
        GameObject newLaser = Instantiate(laser);
        newLaser.SetActive(true);
        return newLaser;
    }

    public void MoveLeft()
    {
        transform.Translate(-Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, -3.22f, 0);
        }
    }

    public void MoveRight()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > maxRight)
        {
             transform.position = new Vector3(maxRight, -3.22f, 0);
        }
    }

    public void Explode()
    {
        mesh.enabled = false;
        explosion.SetActive(true);
        isDead = true;
    }

    public void RepairShip()
    {
        explosion.SetActive(false);
        mesh.enabled = true;
        isDead = false;
    }
}
