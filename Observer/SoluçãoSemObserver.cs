public class Noticia
{
	public string Titulo { get; set; }
	public string Conteudo { get; set; }
	public DateTime Data { get; set; }
	private List<Assinante> assinantes = new List<Assinante>();
	
	public void AdicionarAssinante(Assinante assinante)
	{
		assinantes.Add(assinante);
	}
	
	public void RemoverAssinante(Assinante assinante)
	{
		assinantes.Remove(assinante);
	}
	
	public void Publicar()
	{
		foreach (var assinante in assinantes)
		{
			if (assinante is Usuario)
			{
				EnviarEmail((Usuario)assinante);
			}
			else if (assinante is Jornalista)
			{
				EnviarPushNotification((Jornalista)assinante);
			}
			else if (assinante is Administrador)
			{
				EnviarSMS((Administrador)assinante);
			}
		}
	}
	
	private void EnviarEmail(Usuario usuario)
	{
		Console.WriteLine($"Enviando email para {usuario.Nome} ({usuario.Email})");
	}
	
	private void EnviarPushNotification(Jornalista jornalista)
	{
		Console.WriteLine($"Enviando push notification para {jornalista.Nome} ({jornalista.Telefone})");
	}
	
	private void EnviarSMS(Administrador administrador)
	{
		Console.WriteLine($"Enviando SMS para {administrador.Nome} ({administrador.Telefone})");
	}
}

public class Assinante
{
	public string Nome { get; set; }
}

public class Usuario : Assinante
{
	public string Email { get; set; }
}

public class Jornalista : Assinante
{
	public string Telefone { get; set; }
}

public class Administrador : Assinante
{
	public string Telefone { get; set; }
}