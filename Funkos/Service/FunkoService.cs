using CSharpFunctionalExtensions;
using Funkos.Models;
using Funkos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Funkos.Service;

public class FunkoService(IFunkoRepository repository) : IFunkoService
{
    public Result<List<Funko>, string>  GetAll()
    {
        List<Funko> funkos = repository.GetAll();
        
        if(funkos.Count <= 0) return Result.Failure<List<Funko>, string>("No existen Funkos");
        
        return Result.Success<List<Funko>, string>(funkos);
    }
    
    public Result<Funko?, string> GetById(long id)
    {
        if(id <= 0) return Result.Failure<Funko?, string>("El id no existe ");
        
        Funko? funko = repository.GetById(id);
        return Result.Success<Funko?, string>(funko);
    }
    
    public Result<Funko, string> Add(Funko  newFunko)
    {
        Funko funko = repository.Create(newFunko);
        return Result.Success<Funko, string>(funko);
    }
    
    public Result<Funko?, string> Update(long id, Funko updatedFunko)
    {
        Funko? funko = repository.Update(id, updatedFunko);
        if (funko == null) throw new ArgumentException($"No existe el Funko");
        return Result.Success<Funko?, string>(funko);
    }

    public Result<bool, string> Delete(long id)
    {
        var eliminado = repository.Delete(id);
        if (eliminado == false) return Result.Failure<bool, string>("No se ha podido eliminar el Funko");
        return Result.Success<bool, string>(true);
    }
    
}