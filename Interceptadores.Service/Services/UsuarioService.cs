using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Exception;
using Interceptadores.Domain.Interfaces.Data;
using Interceptadores.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace Interceptadores.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public void Criar(UsuarioDto usuario)
            => _usuarioRepository.Criar(_mapper.Map<Usuario>(usuario));

        public void Atualizar(UsuarioDto usuario)
            => _usuarioRepository.Atualizar(_mapper.Map<Usuario>(usuario));

        public void Remover(UsuarioDto usuario)
            => _usuarioRepository.Remover(_mapper.Map<Usuario>(usuario));

        public UsuarioDto PesquisarPorId(Guid id)
            => _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorId(id));

        public IQueryable<UsuarioDto> ObterTodos()
            => _usuarioRepository.ObterTodos().ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider);

        private UsuarioDto PesquisarPorLoginSenha(string login, string senha)
            => _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorLoginSenha(login, senha));

        public UsuarioDto ObterUsuarioParaAutenticacao(LoginDto loginDto)
        {
            UsuarioDto usuario = PesquisarPorLoginSenha(loginDto.Login, loginDto.Senha);

            if (usuario == null)
            {
                throw new InterceptadoresException("Usuário não localizado.");
            }

            return usuario;
        }
    }
}