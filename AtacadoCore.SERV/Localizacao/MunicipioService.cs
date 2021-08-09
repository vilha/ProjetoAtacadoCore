﻿using AtacadoCore.POCO.Localizacao;
using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Localizacao;
using AtacadoCore.REPO.Localizacao;
using AtacadoCore.SERV.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.SERV.Localizacao
{
    public class MunicipioService :
        GenericService<DbContext, Municipio, MunicipioPoco>,
        IService<MunicipioPoco>
    {
        public MunicipioService(DbContext contexto)
        {
            this.repositorio = new MunicipioRepository(contexto);
            this.mapa = new MunicipioMap();
        }

        public MunicipioPoco Obter(int id)
        {
            Municipio dominio = this.repositorio.Read(mun => mun.MunicipioID == id);
            MunicipioPoco poco = this.mapa.GetMapper.Map<MunicipioPoco>(dominio);
            return poco;
        }

        public IEnumerable<MunicipioPoco> ObterTodos()
        {
            List<Municipio> lista = this.repositorio.Browsable().ToList();
            List<MunicipioPoco> listaPoco = this.mapa.GetMapper.Map<List<MunicipioPoco>>(lista);
            return listaPoco;
        }

        public MunicipioPoco Atualizar(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio alterada = this.repositorio.Edit(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(alterada);
            return novoPoco;
        }

        public MunicipioPoco Excluir(int id)
        {
            Municipio mun = this.repositorio.Read(reg => reg.MunicipioID == id);
            MunicipioPoco poco = this.mapa.GetMapper.Map<MunicipioPoco>(mun);
            this.repositorio.Delete(mun);
            return poco;
        }

        public MunicipioPoco Incluir(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio nova = this.repositorio.Add(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}
