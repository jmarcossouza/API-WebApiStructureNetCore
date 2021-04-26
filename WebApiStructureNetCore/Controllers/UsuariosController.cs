using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStructureNetCore.Data;
using WebApiStructureNetCore.Entities;
using WebApiStructureNetCore.Exceptions;
using WebApiStructureNetCore.Libraries;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly WebapiStructureDbContext _context;

        public UsuariosController(WebapiStructureDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioGetModel>>> GetUsuarios()
        {
            return await _context.Usuarios.Select(c => new UsuarioGetModel()
            {
                Id = c.Id,
                Email = c.Email,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
            }).ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioGetModel>> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.Select(c => new UsuarioGetModel()
            {
                Id = c.Id,
                Email = c.Email,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (usuario == null)
            {
                throw new NotFoundException();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioGetModel>> PutUsuario(long id, UsuarioEditModel newUsuario)
        {
            //if (id != usuario.Id)
            //{
            //    return BadRequest();
            //}

            var usuario = await FindUsuarioAsync(id);
            EntitiesLibrary.SetBasicValuesFrom(newUsuario, usuario, AllowEmptyOrWhitespacStrings: false);
            await _context.SaveChangesAsync();

            var usuarioChanged = new UsuarioGetModel()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
            };
            return Ok(usuarioChanged);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioGetModel>> PostUsuario([FromBody] UsuarioNewModel newUsuario)
        {
            Usuario usuario = new Usuario();
            EntitiesLibrary.SetBasicValuesFrom(newUsuario, usuario);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, EntitiesLibrary.SetValuesFrom(usuario, new UsuarioGetModel()));
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            var usuario = await FindUsuarioAsync(id);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("alterar-senha/{usuarioId}")]
        public async Task<ActionResult<UsuarioGetModel>> AlterarSenha([FromRoute] long usuarioId, [FromBody] UsuarioChangePassword usuarioEdit)
        {
            Usuario usuario = await FindUsuarioAsync(usuarioId);

            if (!usuario.verifyPassword(usuarioEdit.SenhaAtual))
            {
                throw new NormalException("A senha informada está incorreta.");
            } else
            {
                usuario.Senha = usuarioEdit.NovaSenha;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsuario", new { id = usuario.Id }, EntitiesLibrary.SetValuesFrom(usuario, new UsuarioGetModel()));
            }
        }

        /// <summary>
        /// Procura e retorna o usuário do ID informado.
        /// <para>Caso não seja encontrado irá dar throw na exception <c>NotFoundException</c></para>
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        private Usuario FindUsuario(long id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            return usuario;
        }

        /// <summary>
        /// Procura e retorna o usuário do ID informado.
        /// <para>Caso não seja encontrado irá dar throw na exception <c>NotFoundException</c></para>
        /// <para>Este é um método assíncrono, caso precise de uma versão síncrona do método, use <see cref="FindUsuario"/></para>
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        private async Task<Usuario> FindUsuarioAsync(long id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            return usuario;
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
