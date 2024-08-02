
public interface IObserver
{
	void Update(Noticia noticia);
}


public interface ISubject
{
	void Attach(IObserver observer);
	void Detach(IObserver observer);
	void Notify();
}

// Classe Noticia (Subject)
public class Noticia : ISubject
{
	public string Titulo { get; set; }
	public string Conteudo { get; set; }
	public DateTime Data { get; set; }
	private List<IObserver> _observadores = new List<IObserver>();
	
	public void Attach(IObserver observer)
	{
		_observadores.Add(observer);
	}
	
	public void Detach(IObserver observer)
	{
		_observadores.Remove(observer);
	}
	
	public void Notify()
	{
		foreach (var observer in _observadores)
		{
			observer.Update(this);
		}
	}
	
	public void Publicar()
	{
		Console.WriteLine($"Publicando notícia: {Titulo}");
		Notify();
	}
}

// Classe Usuario (Observer)
public class Usuario : IObserver
{
	public string Nome { get; set; }
	public string Email { get; set; }
	
	public void Update(Noticia noticia)
	{
		Console.WriteLine($"Enviando email para {Nome} ({Email}): Nova notícia - {noticia.Titulo}");
	}
}

// Classe Jornalista (Observer)
public class Jornalista : IObserver
{
	public string Nome { get; set; }
	public string Telefone { get; set; }
	
	public void Update(Noticia noticia)
	{
		Console.WriteLine($"Enviando push notification para {Nome} ({Telefone}): Nova notícia - {noticia.Titulo}");
	}
}

// Classe Administrador (Observer)
public class Administrador : IObserver
{
	public string Nome { get; set; }
	public string Telefone { get; set; }
	
	public void Update(Noticia noticia)
	{
		Console.WriteLine($"Enviando SMS para {Nome} ({Telefone}): Nova notícia - {noticia.Titulo}");
	}
}


public class Program
{
	public static void Main(string[] args)
	{
		// Criando uma nova noticia
		var noticia = new Noticia
		{
			Titulo = "Nova Descoberta Científica",
			Conteudo = "Uma nova pesquisa revela...",
			Data = DateTime.Now
		};
		
		// Criando assinantes
		var usuario = new Usuario { Nome = "Alice", Email = "alice@example.com" };
		var jornalista = new Jornalista { Nome = "Bob", Telefone = "123456789" };
		var administrador = new Administrador { Nome = "Carlos", Telefone = "987654321" };
		
		// Registrando assinantes
		noticia.Attach(usuario);
		noticia.Attach(jornalista);
		noticia.Attach(administrador);
		
		// Publicando a notícia
		noticia.Publicar();
	}
}