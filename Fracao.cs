using System.ComponentModel.DataAnnotations;

public class Fracao
{
    public int Numerador;
    public int Denominador;

    // Constructors //
    public Fracao(int numerador, int denominador)
    {   
        ArgumentOutOfRangeException.ThrowIfZero(denominador);

        int mdc = Math.Mdc(numerador, denominador);
        Numerador = numerador / mdc;
        Denominador = denominador / mdc;
    }
    public Fracao(int inteiro)
    {
        Numerador = inteiro;
        Denominador = 1;
    }
    public Fracao(string fracao)
    {
        string[] stringArray = fracao.Split("/");
        ArgumentOutOfRangeException.ThrowIfZero(int.Parse(stringArray[1]));

        Numerador = int.Parse(stringArray[0]);
        Denominador = int.Parse(stringArray[1]);
        int mdc = Math.Mdc(Numerador, Denominador);
        Numerador /= mdc;
        Denominador /= mdc;
    }
    public Fracao(double number)
    {
        Denominador = 1;

        while (number % 1 != 0)
        {
            number *= 10;
            Denominador *= 10;
        }
        Numerador = (int)number;

        int mdc = Math.Mdc(Numerador, Denominador);
        Numerador /= mdc;
        Denominador /= mdc;
    }

    // Int + & - Operators  //
    public static Fracao operator +(Fracao fracao, int number) => new Fracao(fracao.Numerador + number * fracao.Denominador, fracao.Denominador);

    public static Fracao operator -(Fracao fracao, int number) => new Fracao(fracao.Numerador - number * fracao.Denominador, fracao.Denominador);

    // Double + & - Operators //
    public static Fracao operator +(Fracao fracao, double number)
    {
        var fracao2 = new Fracao(number);
        return new Fracao(fracao.Numerador * fracao2.Denominador + fracao.Denominador * fracao2.Numerador, fracao.Denominador * fracao2.Denominador);
    }
    public static Fracao operator -(Fracao fracao, double number)
    {
        var fracao2 = new Fracao(number);
        return new Fracao(fracao.Numerador * fracao2.Denominador - fracao.Denominador * fracao2.Numerador, fracao.Denominador * fracao2.Denominador);
    }

    // String + & - Operators //
    public static Fracao operator +(Fracao fracao, string number)
    {
        var fracao2 = new Fracao(number);
        return new Fracao(fracao.Numerador * fracao2.Denominador + fracao.Denominador * fracao2.Numerador, fracao.Denominador * fracao2.Denominador);
    }
    public static Fracao operator -(Fracao fracao, string number)
    {
        var fracao2 = new Fracao(number);
        return new Fracao(fracao.Numerador * fracao2.Denominador - fracao.Denominador * fracao2.Numerador, fracao.Denominador * fracao2.Denominador);
    }

    // Bolleans Operators //
    public static bool operator ==(Fracao fracao, Fracao other) => (fracao.Numerador == other.Numerador && fracao.Denominador == other.Denominador);

    public static bool operator !=(Fracao fracao, Fracao other) => (fracao.Numerador != other.Numerador || fracao.Denominador != other.Denominador);

    // Others Operators //
    public static bool operator >(Fracao fracao, Fracao other) => ((double)fracao.Numerador / (double)fracao.Denominador > (double)other.Numerador / (double)other.Denominador);
    public static bool operator <(Fracao fracao, Fracao other) => ((double)fracao.Numerador / (double)fracao.Denominador < (double)other.Numerador / (double)other.Denominador);
    public static bool operator >=(Fracao fracao, Fracao other) => ((double)fracao.Numerador / (double)fracao.Denominador >= (double)other.Numerador / (double)other.Denominador);
    public static bool operator <=(Fracao fracao, Fracao other) => ((double)fracao.Numerador / (double)fracao.Denominador <= (double)other.Numerador / (double)other.Denominador);

    //functions//
    public override string ToString() => $"{Numerador}/{Denominador}".ToString();
    public Fracao Somar(int number) => new Fracao(Numerador + number * Denominador, Denominador);
    public override bool Equals(object? obj)
    {
        if (obj is Fracao other)
            return (Numerador == other.Numerador && Denominador == other.Denominador);
        return false;
    }
    public bool IsImpropria => Numerador > Denominador;
    public bool IsPropria => Numerador < Denominador;
    public bool IsAparente => Numerador % Denominador == 0;
    public bool IsUnitaria => Numerador == 1;
}

public static class Math
{
    public static int Mmc(int num1, int num2)
    {
        int[] array = [num1, num2];
        int MAX = num1 > num2 ? num1 : num2;
        int count = MAX;

        while (!array.All(element => count % element == 0))
            count += MAX;

        return count;
    }

    public static int Mdc(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
} 