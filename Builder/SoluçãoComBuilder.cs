public class Pizza
{
    public int Tamanho { get; private set; }
    public bool Queijo { get; private set; }
    public bool Tomate { get; private set; }
    public bool Bacon { get; private set; }

    public Pizza(int tamanho, bool queijo, bool tomate, bool bacon)
    {
        Tamanho = tamanho;
        Queijo = queijo;
        Tomate = tomate;
        Bacon = bacon;
    }

    public override string ToString()
    {
        return $"Tamanho: {Tamanho}, Queijo: {Queijo}, Tomate: {Tomate}, Bacon: {Bacon}";
    }
}

public interface IPizzaBuilder
{
    IPizzaBuilder SetTamanho(int tamanho);
    IPizzaBuilder SetQueijo(bool queijo);
    IPizzaBuilder SetTomate(bool tomate);
    IPizzaBuilder SetBacon(bool bacon);
    Pizza Build();
}

public class PizzaBuilder : IPizzaBuilder
{
    private int _tamanho;
    private bool _queijo;
    private bool _tomate;
    private bool _bacon;

    public IPizzaBuilder SetTamanho(int tamanho)
    {
        _tamanho = tamanho;
        return this;
    }

    public IPizzaBuilder SetQueijo(bool queijo)
    {
        _queijo = queijo;
        return this;
    }

    public IPizzaBuilder SetTomate(bool tomate)
    {
        _tomate = tomate;
        return this;
    }

    public IPizzaBuilder SetBacon(bool bacon)
    {
        _bacon = bacon;
        return this;
    }

    public Pizza Build()
    {
        return new Pizza(_tamanho, _queijo, _tomate, _bacon);
    }
}

public class Program
{
    public static void Main()
    {
        IPizzaBuilder builder = new PizzaBuilder();
        Pizza pizza = builder.SetTamanho(30)
                             .SetQueijo(true)
                             .SetTomate(true)
                             .SetBacon(true)
                             .Build();

        Console.WriteLine(pizza);
    }
}