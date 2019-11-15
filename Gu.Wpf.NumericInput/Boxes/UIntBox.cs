namespace Gu.Wpf.NumericInput
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;

    /// <summary>A <see cref="System.Windows.Controls.TextBox"/> for input of <see cref="uint"/>.</summary>
    [ToolboxItem(true)]
    public class UIntBox : NumericBox<uint>
    {
        static UIntBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UIntBox), new FrameworkPropertyMetadata(typeof(UIntBox)));
            NumberStylesProperty.OverrideMetadataWithDefaultValue(typeof(NumericBox<uint>), typeof(UIntBox), NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingWhite);
            IncrementProperty.OverrideMetadataWithDefaultValue<uint>(typeof(UIntBox), 1);
        }

        /// <inheritdoc />
        public override bool TryParse(string text, NumberStyles numberStyles, IFormatProvider culture, out uint result)
        {
            return uint.TryParse(text, numberStyles, culture, out result);
        }

        /// <inheritdoc />
        protected override uint Add(uint x, uint y)
        {
            return x + y;
        }

        /// <inheritdoc />
        protected override uint Subtract(uint x, uint y)
        {
            return x - y;
        }

        /// <inheritdoc />
        protected override uint TypeMin()
        {
            return uint.MinValue;
        }

        /// <inheritdoc />
        protected override uint TypeMax()
        {
            return uint.MaxValue;
        }
    }
}
