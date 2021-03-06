﻿using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mapper
{
    public class SeccionHorarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_EMPLEADO = "ID_EMPLEADO";
        private const string DB_COL_HORA_INICIO = "HORA_INICIO";
        private const string DB_COL_HORA_FINAL = "HORA_FINAL";
        private const string DB_COL_DIA_SEMANA = "DIA_SEMANA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_ESTADO = "ESTADO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SECCION_HORARIO_PR" };

            var sh = (SeccionHorario)entity;
           
            operation.AddIntParam(DB_COL_ID_EMPLEADO, sh.IdEmpleado);
            operation.AddDateTimeParam(DB_COL_HORA_INICIO, sh.HoraInicio);
            operation.AddDateTimeParam(DB_COL_HORA_FINAL, sh.HoraFinal);
            operation.AddVarcharParam(DB_COL_DESCRIPCION, sh.Descripcion);
            operation.AddIntParam(DB_COL_DIA_SEMANA, sh.DiaSemana);
            operation.AddVarcharParam(DB_COL_ESTADO, sh.Estado);


            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SECCION_HORARIO_PR" };

            var sh = (SeccionHorario)entity;
            operation.AddIntParam(DB_COL_ID, sh.Id);

            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SECCION_HORARIO_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SECCION_HORARIO_PR" };

            var sh = (SeccionHorario)entity;
            operation.AddIntParam(DB_COL_ID, sh.Id);
            operation.AddIntParam(DB_COL_ID_EMPLEADO, sh.IdEmpleado);
            operation.AddDateTimeParam(DB_COL_HORA_INICIO, sh.HoraInicio);
            operation.AddDateTimeParam(DB_COL_HORA_FINAL, sh.HoraFinal);
            operation.AddVarcharParam(DB_COL_DESCRIPCION, sh.Descripcion);
            operation.AddIntParam(DB_COL_DIA_SEMANA, sh.DiaSemana);
            operation.AddVarcharParam(DB_COL_ESTADO, sh.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_SECCION_HORARIO_PR" };

            var sh = (SeccionHorario)entity;
            operation.AddIntParam(DB_COL_ID, sh.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var seccionHorario = BuildObject(row);
                lstResults.Add(seccionHorario);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var seccionHorario = new SeccionHorario
            {
                Id = GetIntValue(row, DB_COL_ID),
                IdEmpleado = GetIntValue(row, DB_COL_ID_EMPLEADO),
                HoraInicio = GetDateValue(row, DB_COL_HORA_INICIO),
                HoraFinal = GetDateValue(row, DB_COL_HORA_FINAL),
                DiaSemana = GetIntValue(row, DB_COL_DIA_SEMANA),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return seccionHorario;
        }

        public SqlOperation GetRetriveHorarioEmpleado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SECCION_HORARIO_ID_EMPLEADO_PR" };

            var sh = (SeccionHorario)entity;
            operation.AddIntParam(DB_COL_ID_EMPLEADO, sh.IdEmpleado);
            operation.AddIntParam(DB_COL_DIA_SEMANA, sh.DiaSemana);

            return operation;
        }
    }
}
