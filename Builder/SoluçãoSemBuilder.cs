public class Pizza
{
    private int tamanho;
    private bool queijo;
    private bool tomate;
    private bool bacon;

    public Pizza(int tamanho)
    {
        this.tamanho = tamanho;
    }

    public Pizza(int tamanho, bool queijo)
        : this(tamanho)
    {
        this.queijo = queijo;
    }

    public Pizza(int tamanho, bool queijo, bool tomate)
        : this(tamanho, queijo)
    {
        this.tomate = tomate;
    }

    public Pizza(int tamanho, bool queijo, bool tomate, bool bacon)
        : this(tamanho, queijo, tomate)
    {
        this.bacon = bacon;
    }

    public override string ToString()
    {
        return $"Tamanho: {tamanho}, Queijo: {queijo}, Tomate: {tomate}, Bacon: {bacon}";
    }
}

public class Program
{
    public static void Main()
    {
        Pizza pizza1 = new Pizza(30);
        Pizza pizza2 = new Pizza(30, true);
        Pizza pizza3 = new Pizza(30, true, true);
        Pizza pizza4 = new Pizza(30, true, true, true);

        Console.WriteLine(pizza1);
        Console.WriteLine(pizza2);
        Console.WriteLine(pizza3);
        Console.WriteLine(pizza4);
    }
}