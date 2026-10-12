using CSharpFunctionalExtensions;
using Funkos.Models;

namespace Funkos.Service;

public interface IFunkoService
{
    Result<List<Funko>, string> GetAll();
    Result<Funko?, string> GetById(long id);
    Result<Funko, string> Add(Funko newFunko);
    Result<Funko?, string> Update(long id, Funko updatedFunko);
    Result<bool, string> Delete(long id);
}