﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caphyon.RcStrings.StringEnhancer
{
  public class HeaderFilesContent
  {
    private Dictionary<string, string> mHeaderElements = new Dictionary<string, string>();

    public void AddElement(string aName, string aId) => mHeaderElements.Add(aName, aId);

    public bool ContainString(string aName) => mHeaderElements.ContainsKey(aName);

    public string GetElement(string aName) => mHeaderElements[aName];

    public List<KeyValuePair<string, string>> SortByIdValue()
    {
      var elements = mHeaderElements.ToList();
      elements.Sort((pair1, pair2) =>
      {
        int id1 = -1;
        int id2 = -1;
        ParseUtility.TransformToDecimal(pair1.Value, out id1);
        ParseUtility.TransformToDecimal(pair2.Value, out id2);

        return id1.CompareTo(id2);
      });
      return elements;
    }

  }
}