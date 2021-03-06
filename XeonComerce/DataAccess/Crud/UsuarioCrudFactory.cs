﻿using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;


namespace DataAccess.Crud
{
	public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var ent = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(ent);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public void Verification(Usuario user)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.Verification(user));
        }

        public override List<T> RetrieveAll<T>()
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lst;
        }

        public void UpdateToAdmin(Usuario usuario)
        {
            dao.ExecuteProcedure(mapper.UpdateToAdmin(usuario));
        }

        public override void Update(BaseEntity entity)
        {
            var ent = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(ent));
        }

        public override void Delete(BaseEntity entity)
        {
            var ent = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(ent));
        }
    }
}
