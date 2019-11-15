namespace Gu.Wpf.NumericInput.Tests
{
    using System;
    using System.Threading;

    using NUnit.Framework;

    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class UIntBoxTests : NumericBoxTests<UIntBox, uint>
    {
        protected override uint Max => 10;

        protected override uint Min => 0;

        protected override uint Increment => 1;

        protected override Func<UIntBox> Creator => () => new UIntBox();
    }
}
