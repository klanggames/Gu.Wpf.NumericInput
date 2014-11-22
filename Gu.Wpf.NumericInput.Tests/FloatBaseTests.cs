﻿using System;

namespace Gu.Wpf.NumericInput.Tests
{
    using System.Globalization;
    using NUnit.Framework;

    public abstract class FloatBaseTests<TBox,T> : NumericBoxTests<TBox,T>
        where TBox : NumericBox<T>, IDecimals
        where T : struct, IComparable<T>, IFormattable, IConvertible, IEquatable<T> 
    {
        [Test]
        public void AppendDecimalDoesNotTruncateText()
        {
            Sut.Text = "1";
            Assert.AreEqual(1, Sut.GetValue(NumericBox<T>.ValueProperty));
            Assert.AreEqual("1", Sut.Text);
            Sut.Text = "1.";
            Assert.AreEqual(1, Sut.GetValue(NumericBox<T>.ValueProperty));
            Assert.AreEqual("1.", Sut.Text);

            Sut.Text = "1.0";
            Assert.AreEqual(1, Sut.GetValue(NumericBox<T>.ValueProperty));
            Assert.AreEqual("1.0", Sut.Text);
        }

        [TestCase("sv-SE", "1,23", "en-US", "1.23")]
        [TestCase("en-US", "1.23", "sv-SE", "1,23")]
        public void Culture(string culture1, string text, string culture2, string expected)
        {
            Sut.Culture = new CultureInfo(culture1);
            Sut.Text = text;
            Sut.Culture = new CultureInfo(culture2);
            Assert.AreEqual(expected, Sut.Text);
        }

        [TestCase(2, "1.234", "1.23", 1.234)]
        public void ValueNotAffectedByDecimalDigits(int decimals, string text, string expectedText, T expected)
        {
            Sut.Text = text;
            Sut.DecimalDigits = decimals;
            Assert.AreEqual(expectedText, Sut.Text);
            Assert.AreEqual(expected, Sut.Value);
        }

        [TestCase("1.234", 1.234, "1.23", 1.23)]
        public void ValueUpdatedOnFewerDecimalDigitsFromUser(string text1, T expected1, string text2, T expected2)
        {
            Sut.DecimalDigits = 5;

            Sut.Text = text1;
            Assert.AreEqual(expected1, Sut.Value);

            Sut.Text = text2;
            Assert.AreEqual(expected2, Sut.Value);
        }

        [TestCase("1.234", 2, "1.23", 4, "1.2340")]
        public void RoundtripDecimals(string text, int decimals1, string expected1, int decimals2, string expected2)
        {
            Sut.Text = text;
            Sut.DecimalDigits = decimals1;
            Assert.AreEqual(expected1, Sut.Text);

            Sut.DecimalDigits = decimals2;
            Assert.AreEqual(expected2, Sut.Text);
        }


        [Test]
        public void AddedDigitsNotTruncated()
        {
            Sut.DecimalDigits = 2;
            Sut.Text = "1.23";
            Sut.Text = "1.234";
            Assert.AreEqual(1.234, Sut.Value);
        }

        [Test]
        public void FewerDecimalsUpdatesValue()
        {
            Sut.DecimalDigits = 4;
            Sut.Text = "1.2334";
            Sut.Text = "1.23";
            Assert.AreEqual(1.23, Sut.Value);
        }
    }
}
