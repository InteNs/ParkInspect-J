﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ParkInspect.Maps
{
    public class MapText : FrameworkElement
    {
        private GlyphRun _glyphRun;
        private Geometry _outline;

        public static readonly DependencyProperty TextProperty = TextBlock.TextProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty FontSizeProperty = TextBlock.FontSizeProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty FontFamilyProperty = TextBlock.FontFamilyProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty FontStyleProperty = TextBlock.FontStyleProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty FontWeightProperty = TextBlock.FontWeightProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty FontStretchProperty = TextBlock.FontStretchProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty ForegroundProperty = TextBlock.ForegroundProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata((o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty BackgroundProperty = TextBlock.BackgroundProperty.AddOwner(
            typeof(MapText), new FrameworkPropertyMetadata(Brushes.White, (o, e) => ((MapText)o)._glyphRun = null));

        public static readonly DependencyProperty OutlineThicknessProperty = DependencyProperty.Register(
            "OutlineThickness", typeof(double), typeof(MapText),
            new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsMeasure, (o, e) => ((MapText)o)._glyphRun = null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public FontFamily FontFamily
        {
            get { return (FontFamily)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public FontStyle FontStyle
        {
            get { return (FontStyle)GetValue(FontStyleProperty); }
            set { SetValue(FontStyleProperty, value); }
        }

        public FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }

        public FontStretch FontStretch
        {
            get { return (FontStretch)GetValue(FontStretchProperty); }
            set { SetValue(FontStretchProperty, value); }
        }

        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public double OutlineThickness
        {
            get { return (double)GetValue(OutlineThicknessProperty); }
            set { SetValue(OutlineThicknessProperty, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return CheckGlyphRun() ? _outline.Bounds.Size : new Size();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (!CheckGlyphRun()) return;
            var location = _outline.Bounds.Location;
            drawingContext.PushTransform(new TranslateTransform(-location.X, -location.Y));
            drawingContext.DrawGeometry(Background, null, _outline);
            drawingContext.DrawGlyphRun(Foreground, _glyphRun);
        }

        private bool CheckGlyphRun()
        {
            if (_glyphRun != null) return true;
            if (string.IsNullOrEmpty(Text))
            {
                return false;
            }

            var typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            GlyphTypeface glyphTypeface;

            if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
            {
                return false;
            }

            var glyphIndices = new ushort[Text.Length];
            var advanceWidths = new double[Text.Length];

            for (int i = 0; i < Text.Length; i++)
            {
                var glyphIndex = glyphTypeface.CharacterToGlyphMap[Text[i]];
                glyphIndices[i] = glyphIndex;
                advanceWidths[i] = glyphTypeface.AdvanceWidths[glyphIndex] * FontSize;
            }

            _glyphRun = new GlyphRun(glyphTypeface, 0, false, FontSize, glyphIndices, new Point(), advanceWidths, null, null, null, null, null, null);

            _outline = _glyphRun.BuildGeometry().GetWidenedPathGeometry(new Pen(null, OutlineThickness * 2d));

            return true;
        }
    }
}
