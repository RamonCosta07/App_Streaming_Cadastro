using System.Collections.Generic;
namespace DIO.Series.Interfaces
{
    // O T é um tipo genérico Para quem for implementar essa Interface
    public interface IRepositorio<T> 
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int Proximoid();
    }
}