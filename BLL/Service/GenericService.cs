using BLL.Interface;
using BLL.Response;
using DAL;
using DAL.Implements;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly GenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(ApplicationContext context, IUnitOfWork unitOfWork)
        {
            _repository = new GenericRepository<TEntity>(context);
            _unitOfWork = unitOfWork;
        }
        public GenericConsultResponse<TEntity> Consult()
        {
            try
            {
                IEnumerable<TEntity> books = _repository.Consult();
                if (books != null)
                {
                    return new GenericConsultResponse<TEntity>(books);
                }
                return new GenericConsultResponse<TEntity>($"No se han agregado registros");
            }
            catch (Exception e) { return new GenericConsultResponse<TEntity>($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(int codBook)
        {
            try
            {
                var book = _repository.GetCod(codBook);
                if (book != null)
                {
                    _repository.Delete(book);
                    _unitOfWork.Commit();
                    return "Libro eliminado satisfactoriamente";
                }
                _unitOfWork.Dispose();
                return ($"No se encuentra el Libro a eliminar");
            }
            catch (Exception e) { 
                _unitOfWork.Dispose(); 
                return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public GenericlogResponse<TEntity> Find(int codEntity)
        {
            try
            {
                var entity = _repository.GetCod(codEntity);
                if (entity != null)
                {
                    return new GenericlogResponse<TEntity>(entity);
                }
                return new GenericlogResponse<TEntity>($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new GenericlogResponse<TEntity>($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public GenericlogResponse<TEntity> Save(TEntity entity)
        {
            try
            {
                _repository.Save(entity);
                _unitOfWork.Commit();
                return new GenericlogResponse<TEntity>(entity);
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new GenericlogResponse<TEntity>
                    ($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public GenericlogResponse<TEntity> Update(int codEntity, TEntity entity)
        {
            try
            {
                var entityFind = _repository.GetCod(codEntity);
                if (entityFind != null)
                {
                    entityFind = entity;
                    _repository.Update(entityFind);
                    _unitOfWork.Commit();
                    return new GenericlogResponse<TEntity>(entityFind);
                }
                _unitOfWork.Dispose();
                return new GenericlogResponse<TEntity>($"No se encuentra registro a modificar");
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new GenericlogResponse<TEntity>($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }
    }
}
