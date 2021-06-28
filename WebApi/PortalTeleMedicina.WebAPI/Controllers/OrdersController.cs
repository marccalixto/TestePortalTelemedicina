using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.Dominio.Servicos;
using PortalTeleMedicina.WebAPI.DTO;
using PortalTeleMedicina.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalTeleMedicina.WebAPI.Controllers
{
    [Authorize]
    public class OrdersController : CrudGenericoController<int, Venda, VendaVM>
    {
        protected readonly IServicoCrud<int, Produto> _serviceProduto;
        public OrdersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProduto = serviceProvider.GetRequiredService<IServicoCrud<int, Produto>>();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public override async Task<IActionResult> Post([FromBody] VendaVM model)
        {
            var entidade = _Mapper.Map<Venda>(model);
            foreach (var item in entidade.Items)
            {
                var produto = await _serviceProduto.GetAsync(item.Produto.Id);
                item.Produto = produto;
            }

            Venda entity = await _Service.AddAsync(entidade);

            string action = Url.Action("Get", this.ControllerContext.ActionDescriptor.ControllerName, new { id = entity.Id });

            return Created(action, _Mapper.Map<VendaVM>(entity));
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            IEnumerable<Venda> entities = await _Service.GetAllAsync();
            var usuarioId = 0;
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    Claim claim = identity.Claims.Where(p => p.Type.ToLower() == "usuarioid").FirstOrDefault();
                    if (claim != null)
                        usuarioId = Convert.ToInt32(claim.Value);
                }

                IEnumerable<VendaVM> models = _Mapper.Map<IEnumerable<VendaVM>>(entities.Where(x => x.UsuarioId == usuarioId).ToList());
                return Ok(models);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public override async Task<IActionResult> Put([FromBody] VendaVM model)
        {
            //var venda = _Mapper.Map<Venda>(model);
            var venda = await _Service.GetAsync(model.Id);
            if (venda == null)
                return NotFound();

            venda.TotalValue = model.TotalValue;
            venda.UsuarioId = model.UsuarioId;
            venda.CreationDate = model.CreationDate;

            var idsItensDaVenda = venda.Items.Select(x => x.Id).ToList();
            foreach (var id in idsItensDaVenda)
            {
                var itemVenda = venda.Items.FirstOrDefault(x => x.Id == id);
                if (itemVenda != null)
                    venda.Items.Remove(itemVenda);
            }

            foreach (var item in model.Items)
            {
                var entidadeItemVenda = _Mapper.Map<ItemVenda>(item);
                venda.Items.Add(entidadeItemVenda);
            }

            Venda entity = await _Service.UpdateAsync(venda);

            return Ok(_Mapper.Map<VendaVM>(entity));
        }

        [HttpPost("PesquisarVendasPor")]
        public async Task<IActionResult> PesquisarVendasPor([FromBody] PesquisarVendasPorDTO dados)
        {
            IEnumerable<Venda> entities = await _Service.GetByAsync(x => 
                (x.UsuarioId == dados.UsuarioId) &&
                ((!dados.DataInicial.HasValue || dados.DataInicial == DateTime.MinValue) || dados.DataInicial <= x.CreationDate) &&
                ((!dados.DataFinal.HasValue || dados.DataFinal == DateTime.MinValue) || dados.DataFinal >= x.CreationDate) &&
                ((dados.ValorInicial == 0) || dados.ValorInicial <= x.TotalValue) &&
                ((dados.ValorFinal == 0) || dados.ValorFinal >= x.TotalValue)
                );

                IEnumerable<VendaVM> models = _Mapper.Map<IEnumerable<VendaVM>>(entities.ToList());
                return Ok(models);
        }
    }
}