using FLib;
using FLib.Figures;
using FLib.Functions;
using System.Xml.Linq;

namespace OOPLAB4
{
    /// <summary>
    /// Лабаратрная работа по ООП
    /// </summary>
    public partial class Form1 : Form
    {
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();

        public Form1()
        {
            InitializeComponent();
            Init.canvas = canvas1;
            Init.bitmap = new Bitmap(canvas1.Width, canvas1.Height);
        }
        /// <summary>
        /// Обработка введенных команд в командную строку по нажатию на ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operators.Clear();
                operands.Clear();
                try
                {
                    string sourceExpression = commandLine.Text.Replace(" ", "");
                    for (int i = 0; i < sourceExpression.Length; i++)
                    {
                        if (Methods.IsNotOperation(sourceExpression[i]))
                        {
                            //добавление в стек не числового операнда
                            if (!Char.IsDigit(sourceExpression[i]))
                            {
                                operands.Push(new Operand(sourceExpression[i]));
                                while (i < sourceExpression.Length - 1 && Methods.IsNotOperation(sourceExpression[i + 1]))
                                {
                                    string temp_str = operands.Pop().value.ToString() + sourceExpression[i + 1].ToString();
                                    operands.Push(new Operand(temp_str));
                                    i++;
                                }
                            }
                            //добавление в стек числового операнда
                            else if (Char.IsDigit(sourceExpression[i]))
                            {
                                operands.Push(new Operand(sourceExpression[i].ToString()));
                                while (i < sourceExpression.Length - 1 && Char.IsDigit(sourceExpression[i + 1])
                                    && Methods.IsNotOperation(sourceExpression[i + 1]))
                                {
                                    int temp_num = Convert.ToInt32(operands.Pop().value.ToString()) * 10 +
                                        (int)Char.GetNumericValue(sourceExpression[i + 1]);
                                    operands.Push(new Operand(temp_num.ToString()));
                                    i++;
                                }
                            }
                        }
                        //проверка и добавление в стек оператора
                        else if (sourceExpression[i] == 'E')
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                            }
                        }
                        else if (sourceExpression[i] == 'M')
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                            }
                        }
                        else if (sourceExpression[i] == 'D')
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                            }
                        }
                        else if (sourceExpression[i] == 'A')
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                            }
                        }
                        else if (sourceExpression[i] == 'X')
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                            }
                        }
                        else if (sourceExpression[i] == '(')
                        {
                            operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                        }
                        else if (sourceExpression[i] == ')')
                        {
                            do
                            {
                                if (operators.Peek().symbolOperator == '(')
                                {
                                    operators.Pop();
                                    break;
                                }
                                if (operators.Count == 0)
                                {
                                    break;
                                }
                            }
                            while (operators.Peek().symbolOperator != '(');
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Аргументы введены некорректно.");
                    commandLog.Items.Add("Аргументы введены некорректно.");
                }
                //выполнение команды
                try
                {
                    SelectingPerformingOperation(operators.Peek());
                }
                catch
                {
                    MessageBox.Show("Введенной операции не существует.");
                    commandLog.Items.Add("Введенной операции не существует.");
                }
            }
        }
        /// <summary>
        /// Выполнение команды по переданному оператору
        /// </summary>
        /// <param name="op"></param>
        private void SelectingPerformingOperation(Operator op)
        {
            try
            {
                if (op.symbolOperator == 'E')
                {
                    DrawE(op);
                }
                else if (op.symbolOperator == 'M')
                {
                    MoveE(op);
                }
                else if (op.symbolOperator == 'D')
                {
                    DeleteE(op);
                }
                else if (op.symbolOperator == 'A')
                {
                    MoveA(op);
                }
                else if (op.symbolOperator == 'X')
                {
                    DeleteA(op);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Удалить все фигуры с холста
        /// </summary>
        /// <param name="op"></param>
        private void DeleteA(Operator op)
        {
            if (Flist.figures.Count == 0)
            {
                MessageBox.Show("Фигур нет");
                commandLog.Items.Add("Нет фигур для удаления");
            }
            else
            {
                if (operands.Count == 0)
                {
                    op = new Operator(Flist.DeleteAll, 'F');
                    op.operatorMethod();
                    commandLog.Items.Add($"Фигуры удалены");
                }
                else
                {
                    MessageBox.Show("Опертор F не принимает параматетры.");
                    commandLog.Items.Add("Неверное число параметров для оператора F.");
                }
            }
        }
        /// <summary>
        /// Переместить все фигуры
        /// </summary>
        /// <param name="op"></param>
        private void MoveA(Operator op)
        {
            if (Flist.figures.Count == 0)
            {
                MessageBox.Show("Фигур нет");
                commandLog.Items.Add("Нет фигур для перемещения");
            }
            else
            {
                if (operands.Count == 2)
                {
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    op = new Operator(Flist.MoveAllTo, 'A');
                    op.binaryOperator(x, y);
                    commandLog.Items.Add($"Фигуры перемещены");
                }
                else
                {
                    MessageBox.Show("Опертор A принимает 2 параматетра.");
                    commandLog.Items.Add("Неверное число параметров для оператора A.");
                }
            }
        }
        /// <summary>
        /// Удалить эллипс по имени
        /// </summary>
        /// <param name="op"></param>
        private void DeleteE(Operator op)
        {
            if (operands.Count == 1)
            {
                Ellipse figure = null;
                string name = operands.Pop().value.ToString();
                foreach (Figure f in Flist.figures)
                {
                    if (f.name == name)
                    {
                        figure = (Ellipse)f;
                    }
                }
                if (figure != null)
                {
                    figure.DeleteF(figure, true);
                    commandLog.Items.Add($"Фигура {figure.name} успешно удалена");
                }
                else
                {
                    MessageBox.Show($"Фигуры {name} не существует");
                    commandLog.Items.Add($"Фигуры {name} не существует");
                }
            }
            else
            {
                MessageBox.Show("Опертор D принимает 1 параматетр.");
                commandLog.Items.Add("Неверное число параметров для оператора D.");
            }
        }
        /// <summary>
        /// Переместить эллипс по имени
        /// </summary>
        /// <param name="op"></param>
        private void MoveE(Operator op)
        {
            if (operands.Count == 3)
            {
                Ellipse figure = null;
                int y = Convert.ToInt32(operands.Pop().value.ToString());
                int x = Convert.ToInt32(operands.Pop().value.ToString());
                string name = operands.Pop().value.ToString();
                foreach (Figure f in Flist.figures)
                {
                    if (f.name == name)
                    {
                        figure = (Ellipse)f;
                    }
                }
                if (figure != null)
                {
                    if (Methods.IsInBounds(x, y, figure.width, figure.height))
                    {
                        figure.MoveTo(x, y);
                        commandLog.Items.Add($"Фигура {figure.name} успешно перемещена");
                    }
                    else
                    {
                        MessageBox.Show("Фигура вышла за границы.");
                        commandLog.Items.Add("Фигура вышла за границы.");
                    }
                }
                else
                {
                    MessageBox.Show($"Фигуры {name} не существует");
                    commandLog.Items.Add($"Фигуры {name} не существует");
                }
            }
            else
            {
                MessageBox.Show("Опертор M принимает 3 параматетра.");
                commandLog.Items.Add("Неверное число параметров для оператора M.");
            }
        }
        /// <summary>
        /// Нарисовать эллпипс
        /// </summary>
        /// <param name="op"></param>
        private void DrawE(Operator op)
        {
            if (operands.Count == 5)
            {
                int w = Convert.ToInt32(operands.Pop().value.ToString());
                int h = Convert.ToInt32(operands.Pop().value.ToString());
                int y = Convert.ToInt32(operands.Pop().value.ToString());
                int x = Convert.ToInt32(operands.Pop().value.ToString());
                string name = operands.Pop().value.ToString();
                if (Methods.IsInBounds(x, y, w, h))
                {
                    Ellipse figure = new Ellipse(name, x, y, w, h);
                    op = new Operator(figure.Draw, 'E');
                    commandLog.Items.Add($"{figure.name} отрисован");
                    op.operatorMethod();
                }
                else
                {
                    MessageBox.Show("Фигура вышла за границы.");
                    commandLog.Items.Add("Фигура вышла за границы.");
                }
            }
            else
            {
                MessageBox.Show("Опертор E принимает 5 параматетров.");
                commandLog.Items.Add("Неверное число параметров для оператора E.");
            }
        }
    }
}