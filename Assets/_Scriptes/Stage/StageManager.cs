using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StageManager : Singleton<StageManager>
{
 public StageData data;
 public Blank blankPrefab;
 public Anphabet anphabetPrefab;
 public HorizontalLayoutGroup blankGroup;
 public GridLayoutGroup anphabetGroup;

 private void OnEnable()
 {
  CreateBlanks();
  CreateAnphabets();
 }

 private void CreateBlanks()
 {
  for (int i = 0; i < data.blankNumber; i++)
  {
      var blank = PoolingManager.Spawn(blankPrefab, transform.position, quaternion.identity);
      blank.transform.SetParent(blankGroup.transform);
      blank.transform.localScale = Vector3.one;
      blank.name = "Blank " + (i + 1);
  }
 }

 private void CreateAnphabets()
 {
  for (int i = 0; i < data.alphabets.Count; i++)
  {
   var anphabet = PoolingManager.Spawn(anphabetPrefab, transform.position, quaternion.identity);
   anphabet.transform.SetParent(anphabetGroup.transform);
   anphabet.transform.localScale = Vector3.one;
   anphabet.name = "Anphabet " + (i + 1);
   anphabet.image.sprite = data.alphabets[i];
  }
 }
}
