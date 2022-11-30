using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FractionCalculatorWinUI3.Models;
using FractionCalculatorWinUI3.Services;

namespace FractionCalculatorWinUI3.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    [ObservableProperty]
    int leftWhole;
    [ObservableProperty]
    int leftTop;
    [ObservableProperty]
    int leftBottom;
    [ObservableProperty]
    int rightWhole;
    [ObservableProperty]
    int rightTop;
    [ObservableProperty]
    int rightBottom;
    [ObservableProperty]
    int resultWhole;
    [ObservableProperty]
    int resultTop;
    [ObservableProperty]
    int resultBottom;
    [ObservableProperty]
    string leftAsDecimal;
    [ObservableProperty]
    string rightAsDecimal;
    [ObservableProperty]
    string resultAsDecimal;
    [ObservableProperty]
    string _operator;
    [ObservableProperty]
    bool showTutorial_1;
    public ICommand AddCommand
    {
        get;
    }
    public ICommand SubtractCommand
    {
        get;
    }
    public ICommand MultiplyCommand
    {
        get;
    }
    public ICommand DivideCommand
    {
        get;
    }
    public ICommand CalculateCommand
    {
        get;
    }
    public ICommand LearnCommand
    {
        get;
    }
    public MainViewModel()
    {
        LeftWhole = 0;
        LeftTop = 1;
        LeftBottom = 6;
        RightWhole = 1;
        RightTop = 8;
        RightBottom = 9;
        Operator = "-";
        AddCommand = new RelayCommand(Add);
        SubtractCommand = new RelayCommand(Subtract);
        DivideCommand = new RelayCommand(Divide);
        MultiplyCommand = new RelayCommand(Multiply);
        CalculateCommand = new RelayCommand(Calculate);
        LearnCommand = new RelayCommand(Learn);
        Calculate();
    }

    private void Learn()
    {
        //Start tutorial
        ShowTutorial_1 = ! ShowTutorial_1;
    }
    void Add()
    {
        Operator = "+";
        Calculate();
    }

    public void Subtract()
    {
        Operator = "-";
        Calculate();
    }

    public void Multiply()
    {
        Operator = "x";
        Calculate();
    }

    public void Divide()
    {
        Operator = "/";
        Calculate();
    }

    public void Calculate()
    {
        Fraction l = new Fraction();
        l.whole = LeftWhole;
        l.top = LeftTop;
        l.bottom = LeftBottom;
        //get right fraction
        Fraction r = new Fraction();
        r.whole = RightWhole;
        r.top = RightTop;
        r.bottom = RightBottom;
        Fraction s = new Fraction();
        bool isResultPositive = true;
        switch (Operator)
        {
            case "+":
                {
                    s = FractionOperations.Add(l, r);
                    break;
                }
            case "-":
                {
                    s = FractionOperations.Subtract(l, r);
                    break;
                }
            case "x":
                {
                    s = FractionOperations.Multiply(l, r);
                    break;
                }
            case "/":
                {
                    s = FractionOperations.Divide(l, r);
                    break;
                }
        }
        ResultWhole = s.whole;
        ResultTop = s.top;
        ResultBottom = s.bottom;
        var leftDecimal = l.GetAsDecimal();
        var rightDecimal = r.GetAsDecimal();
        LeftAsDecimal = leftDecimal.ToString("#.##");
        RightAsDecimal = rightDecimal.ToString("#.##");
        if (Operator.Equals("-"))
        {

            ResultAsDecimal = (leftDecimal >= rightDecimal) ? s.GetAsDecimal().ToString("#.##") : s.GetAsDecimal().ToString("-#.##");
            if (ResultAsDecimal.Equals(string.Empty)){ ResultAsDecimal= "0"; }
        }
        else
        {
            ResultAsDecimal = s.GetAsDecimal().ToString("#.##");
        }
    }
}
