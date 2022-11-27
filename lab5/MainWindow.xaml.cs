using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
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
using org.mariuszgromada.math.mxparser;
using org.mariuszgromada.math.mxparser.mathcollection;
using org.mariuszgromada.math.mxparser.parsertokens;
using org.mariuszgromada.math.mxparser.syntaxchecker;
using Expression = org.mariuszgromada.math.mxparser.Expression;
using OxyPlot.Wpf;
using OxyPlot.Axes;
using System.Linq.Expressions;
using System.Drawing;

namespace lab5 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //private PlotModel OxyPlotModel { get; set; }
        public PlotModel MyModel { get; private set; }

        public MainWindow() {
            this.MyModel = new PlotModel { Title = "345" };

            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            //this.MyModel.InvalidatePlot(true);
        }

        private double leftBorder = 0;
        private double rigthBorder = 0;
        private double accuracy = 0;

        private void btCalculate_Click(object sender, RoutedEventArgs e) {
            if (tbInput.Text == string.Empty || tbLeftBorder.Text == string.Empty || tbRigthBorder.Text == string.Empty || tbAccuracy.Text == String.Empty) {
                MessageBox.Show("Пожалуйста, введите данные");
                return;
            }
            leftBorder = Convert.ToDouble(tbLeftBorder.Text);
            rigthBorder = Convert.ToDouble(tbRigthBorder.Text);
            accuracy = Convert.ToDouble(tbAccuracy.Text);

            MyModel.Axes.Clear();

            MyModel.Axes.

            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -20, Maximum = 80 });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 });

            MyModel.Series.Add(GetFunction());

            //MyModel.Series.Add(GetFunction());
           


            if (cbParabola.IsChecked == true || cbRectangle.IsChecked == true || cbTrapez.IsChecked == true) {
                if (cbParabola.IsChecked == true) {
                }
                if (cbTrapez.IsChecked == true) {
                }
                if (cbRectangle.IsChecked == true) {

                }
            } else {
                MessageBox.Show("Пожалуйста, выберите метод(ы)");
                return;
            }
        }
        #region парсинг
        public double getValue(double point) {
            Argument x = new Argument("x");
            x.setArgumentValue(point);
            Expression expression = new Expression(tbInput.Text.ToString(), x);
            return expression.calculate();
        }
        public FunctionSeries GetFunction() {
            double n = Convert.ToDouble(tbRigthBorder.Text);
            FunctionSeries serie = new FunctionSeries();

            for (double x = Convert.ToDouble(tbLeftBorder.Text) ; x < n; x++) {
                DataPoint data = new DataPoint(x, getValue(x));

                serie.Points.Add(data);
            }
            //returning the serie
            return serie;
        }

        private double parseMath(double point) {
            Argument x = new Argument("x");
            x.setArgumentValue(point);
            Expression expression = new Expression(tbInput.Text.ToString(), x);
            return expression.calculate();
        }
        #endregion
    }
}
