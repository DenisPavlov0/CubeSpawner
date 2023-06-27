using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeChangeColor : MonoBehaviour
{
   [SerializeField] private float _occurrenceInterval;
   [SerializeField] private CubeSpawner _cubeSpawner;

   private Color _color;
   public void Starting()
   {
      _color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
      StartCoroutine(ChangeColor(_color));
   }

   private IEnumerator ChangeColor(Color _color)
   {

      for (var i = 0; i < _cubeSpawner._cube.Count; i++)
      {
         SpriteRenderer spriteRenderer = _cubeSpawner._cube[i].GetComponent<SpriteRenderer>();
         spriteRenderer.color = _color;
         yield return new WaitForSeconds(_occurrenceInterval);
      }
      
   }
}
