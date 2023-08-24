using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseService<RqDTO, TEntity, RsDTO>
       : IBaseService<RqDTO, TEntity, RsDTO> where TEntity : class

    {
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dBSet;

        public BaseService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _dBSet = dbContext.Set<TEntity>();
        }

        public virtual void Delete(int id)
        {
            var ent = _dBSet.Find(id);
            _dBSet.Remove(ent);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<RsDTO> GetAll()
        {
            var ent = _dBSet.ToList();
            var rsdto = _mapper.Map<IEnumerable<RsDTO>>(ent);
            return rsdto;
        }

        public virtual RsDTO GetById(int id)
        {
            var ent = _dBSet.Find(id);
            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public virtual RsDTO Insert(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
            _dBSet.Add(ent);
            _dbContext.SaveChanges();

            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public virtual void Update(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);

            _dBSet.Update(ent);
            _dbContext.SaveChanges();
        }
    }
}
