﻿namespace Gu.Wpf.NumericInput.UITests.Helpers
{
    public static class StringExt
    {
        public static string Slice(this string text, int startIndex, int endIndex)
        {
            return text.Substring(startIndex, endIndex- startIndex);
        }
    }
}
