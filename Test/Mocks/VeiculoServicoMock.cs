using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> _veiculos = new List<Veiculo>()
    {
        new Veiculo{
            Id = 1,
            Nome = "Fiat Strada",
            Marca = "Fiat",
            Ano = 2020
        },
        new Veiculo{
            Id = 2,
            Nome = "Volkswagen Polo",
            Marca = "Volkswagen",
            Ano = 2002
        },
        new Veiculo{
            Id = 3,
            Nome = "Hyundai HB20",
            Marca = "Hyundai",
            Ano = 2012
        }

    };

    public void Apagar(Veiculo veiculo)
    {
        _veiculos.Remove(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        int index = _veiculos.FindIndex(v => v.Id == veiculo.Id);
        if (index != -1) _veiculos[index] = veiculo;
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _veiculos.Find((v) => v.Id == id) ?? null;
    }

    public void Incluir(Veiculo veiculo)
    {
        _veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        List<Veiculo> query = new List<Veiculo>();

        if (!string.IsNullOrEmpty(nome))
        {
            query.AddRange(_veiculos.FindAll(v => v.Nome.Contains(nome)));
        }

        if (!string.IsNullOrEmpty(marca))
        {
            query.AddRange(_veiculos.FindAll(v => v.Marca.Contains(marca)));
        }

        return query;
    }
}