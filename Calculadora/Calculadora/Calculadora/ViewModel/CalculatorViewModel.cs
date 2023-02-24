using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private double _firstNumber;
    private double _secondNumber;
    private string _operation;
    private double _result;

    public double FirstNumber
    {
        get => _firstNumber;
        set
        {
            if (_firstNumber != value)
            {
                _firstNumber = value;
                RaisePropertyChanged(nameof(FirstNumber));
            }
        }
    }

    public double SecondNumber
    {
        get => _secondNumber;
        set
        {
            if (_secondNumber != value)
            {
                _secondNumber = value;
                RaisePropertyChanged(nameof(SecondNumber));
            }
        }
    }

    public string Operation
    {
        get => _operation;
        set
        {
            if (_operation != value)
            {
                _operation = value;
                RaisePropertyChanged(nameof(Operation));
            }
        }
    }

    public double Result
    {
        get => _result;
        set
        {
            if (_result != value)
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }
    }

    public ICommand AddCommand => new Command(Add);

    public ICommand SubtractCommand => new Command(Subtract);

    public ICommand MultiplyCommand => new Command(Multiply);

    public ICommand DivideCommand => new Command(Divide);

    public ICommand ClearCommand => new Command(Clear);

    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Add()
    {
        CalculateResult();
        Operation = "+";
    }

    private void Subtract()
    {
        CalculateResult();
        Operation = "-";
    }

    private void Multiply()
    {
        CalculateResult();
        Operation = "*";
    }

    private void Divide()
    {
        CalculateResult();
        Operation = "/";
    }

    private void CalculateResult()
    {
        switch (Operation)
        {
            case "+":
                Result = FirstNumber + SecondNumber;
                break;
            case "-":
                Result = FirstNumber - SecondNumber;
                break;
            case "*":
                Result = FirstNumber * SecondNumber;
                break;
            case "/":
                Result = FirstNumber / SecondNumber;
                break;
            default:
                Result = 0;
                break;
        }
    }

    private void Clear()
    {
        FirstNumber = 0;
        SecondNumber = 0;
        Operation = "";
        Result = 0;
    }
}
