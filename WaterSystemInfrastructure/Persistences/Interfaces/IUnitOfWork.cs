namespace WaterSystem.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        //transacciones para manipulacion de datos 
        //liberar objetos en meoeria 
        //declaracion de matricula de neuetsra a nievel de repostiry  
        //matroculasod
        //estamos delcarado a nuvel re repositorio para poder acceder a sus metodo aquellas intefaces 
        ISettlementRepository Settlement { get; }
        IUserRepository User { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        
    }
}
