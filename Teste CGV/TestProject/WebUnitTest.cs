using AutoMapper;
using Dominio.Advogado;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste_CGV.Controllers;
using Teste_CGV.ViewModels;
using Xunit;

namespace TestProject
{
    public class WebUnitTest
    {
        private AdvogadoController _advogadoController;

        public WebUnitTest()
        {

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdvogadoViewModel, Advogado>();
                cfg.CreateMap<Advogado, AdvogadoViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            _advogadoController = new AdvogadoController(new AdvogadoRepositorio(), mapper);
        }

        [Fact]
        public void Index_RetornaLista()
        {
            //Act
            var _result = _advogadoController.Index() as ViewResult;
            
            //Assert
            if (new AdvogadoRepositorio().GetAll().Count() > 0)
            {
                var _resultVM = _result.Model as List<AdvogadoViewModel>;
                Assert.True(_resultVM.Any());
            }
            else
                Assert.NotNull(_result);
        }

        [Fact]
        public void Details_RetornaDados()
        {
            //Act
            var _list = new AdvogadoRepositorio().GetAll();
            var rnd = new Random();
            Guid _anyID = _list.ElementAt(rnd.Next(_list.Count())).ID;
            var _result = _advogadoController.Details(_anyID) as ViewResult;

            //Assert
            if (!string.IsNullOrEmpty(_anyID.ToString()))
                Assert.NotNull(_result.Model);
            else
                Assert.NotNull(_result);
        }
    }
}
