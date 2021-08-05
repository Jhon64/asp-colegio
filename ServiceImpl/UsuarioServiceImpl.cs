using EntitySQL;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTO;
using RepositoryImpl;

namespace ServiceImpl
{
    public class UsuarioServiceImpl : UsuarioService
    {
        private UsuarioRepository usuarioRepository = new ImpUsuarioRepository();

        public UsuarioServiceImpl()
        {
        }

        public IList<UsuarioDTO> listarUsuarios()
        {
            List<Usuario> listUsers = usuarioRepository.findAll().ToList();
            List<UsuarioDTO> listFormated = new List<UsuarioDTO>();
            //,mapeamos la informacion
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Usuario, UsuarioDTO>(); });
            IMapper iMapper = config.CreateMapper();


            listUsers.ForEach(elem =>
            {
                /* UsuarioDTO userDto = new UsuarioDTO();
               userDto.id = elem.Id;
                userDto.username = elem.username;
                userDto.password = elem.password;
                userDto.rol = elem.rol;
                userDto.persona_id = elem.persona_id;*/
                UsuarioDTO userDto = iMapper.Map<Usuario, UsuarioDTO>(elem);
                listFormated.Add(userDto);
            });
            return listFormated;
        }

        public UsuarioDTO findById(int id)
        {
            var usuarioSearch=usuarioRepository.findById(id);
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<Usuario, UsuarioDTO>();});
            IMapper iMapper = mapperConfiguration.CreateMapper();
            UsuarioDTO resultUsuario = iMapper.Map<Usuario, UsuarioDTO>(usuarioSearch);
            return resultUsuario;
        }

        public Usuario insert(UsuarioCreateDTO createUsuario)
        {
            MapperConfiguration configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<UsuarioCreateDTO, Usuario>();
            });
            IMapper iMapper = configuration.CreateMapper();
            Usuario newUsuario = iMapper.Map<UsuarioCreateDTO,Usuario>(createUsuario);
            var result=usuarioRepository.insert(newUsuario);
            return result;
        }

        public int update(UsuarioCreateDTO updateUsuario,int id)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}