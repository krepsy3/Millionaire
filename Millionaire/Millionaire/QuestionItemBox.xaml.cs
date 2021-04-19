using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milionaire
{
    /// <summary>
    /// Interaction logic for QuestionItemBox.xaml
    /// </summary>
    public partial class QuestionItemBox : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion

        #region fields
        public static readonly SolidColorBrush defaultBackgroundBrush = new SolidColorBrush(new Color() { R = 0, G = 77, B = 189, A = 255});
        public static readonly SolidColorBrush defaultBorderBrush = new SolidColorBrush(new Color() { R = 155, G = 155, B = 155, A = 255});
        #endregion

        #region dprops
        public static readonly DependencyProperty DecorRatioProperty =
            DependencyProperty.Register(nameof(DecorRatio), typeof(double), typeof(QuestionItemBox), new PropertyMetadata(0.75, OnQIBPropertyChanged));
        public static readonly DependencyProperty DecorRadiusProperty =
            DependencyProperty.Register(nameof(DecorRadius), typeof(double), typeof(QuestionItemBox), new PropertyMetadata(15.0, OnQIBPropertyChanged));
        public static readonly DependencyProperty BoxStrokeProperty =
            DependencyProperty.Register(nameof(BoxStroke), typeof(double), typeof(QuestionItemBox), new PropertyMetadata(1.0, OnQIBPropertyChanged));
        public static readonly DependencyProperty ViewCaretProperty =
            DependencyProperty.Register(nameof(ViewCaret), typeof(bool), typeof(QuestionItemBox), new PropertyMetadata(false, OnQIBPropertyChanged));
        public static readonly DependencyProperty CaretOffsetProperty =
            DependencyProperty.Register(nameof(CaretOffset), typeof(double), typeof(QuestionItemBox), new PropertyMetadata(5.0, OnQIBPropertyChanged));


        public double DecorRatio
        {
            get { return (double)GetValue(DecorRatioProperty); }
            set { SetValue(DecorRatioProperty, value); }
        }

        public double DecorRadius
        {
            get { return (double)GetValue(DecorRadiusProperty); }
            set { SetValue(DecorRadiusProperty, value); }
        }

        public double BoxStroke
        {
            get { return (double)GetValue(BoxStrokeProperty); }
            set { SetValue(BoxStrokeProperty, value); }
        }

        public bool ViewCaret
        {
            get { return (bool)GetValue(ViewCaretProperty); }
            set { SetValue(ViewCaretProperty, value); }
        }

        public bool CaretOffset
        {
            get { return (bool)GetValue(CaretOffsetProperty); }
            set { SetValue(CaretOffsetProperty, value); }
        }
        #endregion

        #region props
        public Point A { get { return new Point(ActualHeight * DecorRatio, BoxStroke / 2); } }
        public Point AA { get { return new Point(ActualHeight * DecorRatio - DecorRadius, BoxStroke / 2); } }
        public Point B { get { return new Point(0, (ActualHeight + 1) / 2); } }
        public Point BB { get { return new Point(DecorRadius, (ActualHeight + 1) / 2); } }
        public Point C { get { return new Point(ActualHeight * DecorRatio, ActualHeight - (BoxStroke / 2)); } }
        public Point CC { get { return new Point(ActualHeight * DecorRatio - DecorRadius, ActualHeight - (BoxStroke / 2)); } }
        public Point D { get { return new Point(ActualWidth - (ActualHeight * DecorRatio), ActualHeight - (BoxStroke / 2)); } }
        public Point DD { get { return new Point(ActualWidth - (ActualHeight * DecorRatio) + DecorRadius, ActualHeight - (BoxStroke / 2)); } }
        public Point E { get { return new Point(ActualWidth, (ActualHeight + 1) / 2); } }
        public Point EE { get { return new Point(ActualWidth - DecorRadius, (ActualHeight + 1) / 2); } }
        public Point F { get { return new Point(ActualWidth - (ActualHeight * DecorRatio), BoxStroke / 2); } }
        public Point FF { get { return new Point(ActualWidth - (ActualHeight * DecorRatio) + DecorRadius, BoxStroke / 2); } }
        #endregion

        #region dprop notifying
        private static void OnQIBPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == DecorRadiusProperty)
            {
                ((QuestionItemBox)d).OnPropertyChange(nameof(AA));
                ((QuestionItemBox)d).OnPropertyChange(nameof(BB));
                ((QuestionItemBox)d).OnPropertyChange(nameof(CC));
                ((QuestionItemBox)d).OnPropertyChange(nameof(DD));
                ((QuestionItemBox)d).OnPropertyChange(nameof(EE));
                ((QuestionItemBox)d).OnPropertyChange(nameof(FF));
            }

            else if ((e.Property == DecorRatioProperty) || (e.Property == BoxStrokeProperty))
            {
                ((QuestionItemBox)d).OnPropertyChange(nameof(A));
                ((QuestionItemBox)d).OnPropertyChange(nameof(AA));
                ((QuestionItemBox)d).OnPropertyChange(nameof(C));
                ((QuestionItemBox)d).OnPropertyChange(nameof(CC));
                ((QuestionItemBox)d).OnPropertyChange(nameof(D));
                ((QuestionItemBox)d).OnPropertyChange(nameof(DD));
                ((QuestionItemBox)d).OnPropertyChange(nameof(F));
                ((QuestionItemBox)d).OnPropertyChange(nameof(FF));
            }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
            {
                OnPropertyChange(nameof(A));
                OnPropertyChange(nameof(AA));
                OnPropertyChange(nameof(B));
                OnPropertyChange(nameof(BB));
                OnPropertyChange(nameof(C));
                OnPropertyChange(nameof(CC));
            }

            if (e.HeightChanged || e.WidthChanged)
            {
                OnPropertyChange(nameof(D));
                OnPropertyChange(nameof(DD));
                OnPropertyChange(nameof(E));
                OnPropertyChange(nameof(EE));
                OnPropertyChange(nameof(F));
                OnPropertyChange(nameof(FF));
            }
        }
        #endregion

        static QuestionItemBox()
        {
            BackgroundProperty.OverrideMetadata(typeof(QuestionItemBox), new FrameworkPropertyMetadata(defaultBackgroundBrush));
            BorderBrushProperty.OverrideMetadata(typeof(QuestionItemBox), new FrameworkPropertyMetadata(defaultBorderBrush));
        }

        public QuestionItemBox()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}

/*
 Example:
  _______________________________
 /                               \
< <> A:  Vozovna Střelná Hora     >
 \_______________________________/


Defining points:

A' A_______________F  F'
  /                \
B<  B'           E' >E
  \________________/
C' C               D  D'


A  (ActualHeight*DecorRatio; BoxStroke/2)
A' (ActualHeight*DecorRatio - DecorRadius; BoxStroke/2)
B  (0; (ActualHeight+1)/2)
B' (DecorRadius; (ActualHeight+1)/2)
C  (ActualHeight*DecorRatio; ActualHeight - (BoxStroke/2))
C' (ActualHeight*DecorRatio - DecorRadius; ActualHeight - (BoxStroke/2))
D  (ActualWidth - (ActualHeight*DecorRatio); ActualHeight - (BoxStroke/2))
D' (ActualWidth - (ActualHeight*DecorRatio) + DecorRadius; ActualHeight - (BoxStroke/2))
E  (ActualWidth; (ActualHeight+1)/2)
E' (ActualWidth - DecorRadius; (ActualHeight+1)/2)
F  (ActualWidth - (ActualHeight*DecorRatio); BoxStroke/2)
F' (ActualWidth - (ActualHeight*DecorRatio) + DecorRadius; BoxStroke/2)
*/
