using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace BilisselBeceriler.BelgeEditor.Library.Views
{
    public partial class ShapeEditView
    {
        public ShapeEditView()
        {
            InitializeComponent();
        }

        private readonly TransformGroup _transformGrup;
        private readonly TranslateTransform _translateTransform;
        private readonly RotateTransform _rotateTransform;
        private readonly ScaleTransform _scaleTransform;
        private readonly ScaleTransform _scaleFlipTransform;
        private readonly SkewTransform _skewTransform;
        private readonly FrameworkElement _orginalElement;
        void DegerGoster(double deger)
        {
            tbMesaj.Text = deger.ToString();
        }
        public ShapeEditView(FrameworkElement element)
            : this()
        {
            _orginalElement = element;
            _orginalElement.RenderTransformOrigin = new Point(0.5, 0.5);
            #region Render Transform
            if (_orginalElement.RenderTransform != null && _orginalElement.RenderTransform is TransformGroup)
            {
                _transformGrup = _orginalElement.RenderTransform as TransformGroup;
                int i = 0;
                foreach (var transform in _transformGrup.Children)
                {
                    if (transform is TranslateTransform)
                    {
                        _translateTransform = transform as TranslateTransform;
                    }
                    else if (transform is ScaleTransform)
                    {
                        if (i == 0)
                        {
                            _scaleTransform = transform as ScaleTransform;
                            if (_scaleTransform.ScaleX == _scaleTransform.ScaleY)
                            {
                                chbKilit.IsChecked = true;
                            }
                        }
                        else
                            _scaleFlipTransform = transform as ScaleTransform;
                        i++;
                    }
                    else if (transform is RotateTransform)
                    {
                        _rotateTransform = transform as RotateTransform;

                    }
                    else if (transform is SkewTransform)
                    {
                        _skewTransform = transform as SkewTransform;
                    }
                }
            }
            else
            {
                _transformGrup = new TransformGroup();
                _translateTransform = new TranslateTransform();
                _scaleTransform = new ScaleTransform();
                _scaleFlipTransform = new ScaleTransform();
                _rotateTransform = new RotateTransform();
                _skewTransform = new SkewTransform();

                _transformGrup.Children.Add(_translateTransform);
                _transformGrup.Children.Add(_scaleTransform);
                _transformGrup.Children.Add(_scaleFlipTransform);
                _transformGrup.Children.Add(_rotateTransform);
                _transformGrup.Children.Add(_skewTransform);
                _orginalElement.RenderTransform = _transformGrup;
            }


            slTranslateX.Value = _translateTransform.X;
            slTranslateY.Value = _translateTransform.Y;

            slScaleX.Value = _scaleTransform.ScaleX;
            slScaleY.Value = _scaleTransform.ScaleY;

            slRotateAngle.Value = _rotateTransform.Angle;

            slRotateX.Value = _scaleFlipTransform.ScaleX;
            slRotateY.Value = _scaleFlipTransform.ScaleY;

            slSkewAngleX.Value = _skewTransform.AngleX;
            slSkewAngleY.Value = _skewTransform.AngleY;

            #endregion
        }

        #region Translate Transform
        private void TranslateXChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _translateTransform.X = e.NewValue;
            DegerGoster(e.NewValue);
        }

        private void TranslateYChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _translateTransform.Y = e.NewValue;
            DegerGoster(e.NewValue);
        }
        #endregion

        #region Scale Transform
        private void ScaleXChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_orginalElement == null) return;
            if (chbKilit.IsChecked.HasValue && chbKilit.IsChecked.Value)
            {
                _scaleTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
                _scaleTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
                _scaleTransform.ScaleX = e.NewValue;
                _scaleTransform.ScaleY = e.NewValue;
                slScaleY.Value = e.NewValue;
            }
            else
            {
                _scaleTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
                _scaleTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
                _scaleTransform.ScaleX = e.NewValue;
            }
            DegerGoster(e.NewValue);
        }

        private void ScaleYChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_orginalElement == null) return;
            if (chbKilit.IsChecked.HasValue && chbKilit.IsChecked.Value)
            {
                _scaleTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
                _scaleTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
                _scaleTransform.ScaleX = e.NewValue;
                _scaleTransform.ScaleY = e.NewValue;
                slScaleX.Value = e.NewValue;
            }
            else
            {
                _scaleTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
                _scaleTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
                _scaleTransform.ScaleY = e.NewValue;
            }
            DegerGoster(e.NewValue);
        }
        private void ScaleXYChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_orginalElement == null) return;
            _scaleTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            _scaleTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _scaleTransform.ScaleX = e.NewValue;
            _scaleTransform.ScaleY = e.NewValue;
            DegerGoster(e.NewValue);
        }
        #endregion

        #region Translate Transform
        private void RotateAngleChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //_rotateTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            //_rotateTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _orginalElement.RenderTransformOrigin = new Point(0.5, 0.5);
            _rotateTransform.Angle = e.NewValue;
            DegerGoster(e.NewValue);
        }

        #endregion

        #region Skew Transform
        private void SkewAngleXChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _skewTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            _skewTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _skewTransform.AngleX = e.NewValue;
            DegerGoster(e.NewValue);
        }

        private void SkewAngleYChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _skewTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            _skewTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _skewTransform.AngleY = e.NewValue;
            DegerGoster(e.NewValue);
        }
        #endregion

        #region Scale (Flip) transform
        private void RotateXChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_orginalElement == null) return;
            _scaleFlipTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            _scaleFlipTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _scaleFlipTransform.ScaleX = e.NewValue;
            DegerGoster(e.NewValue);
        }

        private void RotateYChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_orginalElement == null) return;

            _scaleFlipTransform.CenterX = _orginalElement.DesiredSize.Width / 2;
            _scaleFlipTransform.CenterY = _orginalElement.DesiredSize.Height / 2;
            _scaleFlipTransform.ScaleY = e.NewValue;
            DegerGoster(e.NewValue);
        }
        #endregion
    }
}
