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

public class Spawner : MonoBehaviour
{
    public List<GameObject> asteroids = new List<GameObject>();

    [SerializeField]
    private GameObject asteroid1;
    [SerializeField]
    private GameObject asteroid2;
    [SerializeField]
    private GameObject asteroid3;
    [SerializeField]
    private GameObject asteroid4;

    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnAsteroid();
        StartCoroutine("Spawn");
    }

    public GameObject SpawnAsteroid()
    {
        int random = Random.Range(1, 5);
        GameObject asteroid;
        switch (random)
        {
            case 1:
                asteroid = Instantiate(asteroid1);
                break;
            case 2:
                asteroid = Instantiate(asteroid2);
                break;
            case 3:
                asteroid = Instantiate(asteroid3);
                break;
            case 4:
                asteroid = Instantiate(asteroid4);
                break;
            default:
                asteroid = Instantiate(asteroid1);
                break;
        }

        asteroid.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
        asteroid.transform.position = new Vector3(xPos, 7.35f, 0);

        asteroids.Add(asteroid);

        return asteroid;
    }

    public void ClearAsteroids()
    {
        foreach(GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }

        asteroids.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
