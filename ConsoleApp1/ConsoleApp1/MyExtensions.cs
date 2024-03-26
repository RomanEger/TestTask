using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTask;

public static class MyExtensions
{
    public static string FormatToDouble(this string str) => str.Replace(',', '.');
}