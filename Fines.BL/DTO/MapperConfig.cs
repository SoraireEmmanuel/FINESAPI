using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fines.BL.Models;
using Fines.BL.DTO;

namespace Fines.BL.DTO
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cens, CensDTO>(); //get
                cfg.CreateMap<CensDTO, Cens>(); //post, put

                cfg.CreateMap<CompetenciaDocente, CompetenciaDocenteDTO>(); //get
                cfg.CreateMap<CompetenciaDocenteDTO, CompetenciaDocente>(); //post, put

                cfg.CreateMap<Cursada, CursadaDTO>(); //get
                cfg.CreateMap<CursadaDTO, Cursada>(); //post, put

                cfg.CreateMap<curso, CursoDTO>(); //get
                cfg.CreateMap<CursoDTO, curso>(); //post, put

                cfg.CreateMap<Materias, MateriaDTO>(); //get
                cfg.CreateMap<MateriaDTO, Materias>(); //post, put

                cfg.CreateMap<Sede, SedeDTO>(); //get
                cfg.CreateMap<SedeDTO, Sede>(); //post, put

                cfg.CreateMap<TrayectoriaAcademica, TrayectoriaAcademicaDTO>(); //get
                cfg.CreateMap<TrayectoriaAcademicaDTO, TrayectoriaAcademica>(); //post, put

                cfg.CreateMap<Usuario, UsuarioDTO>(); //get
                cfg.CreateMap<UsuarioDTO, Usuario>(); //post, put

                cfg.CreateMap<Clase, ClaseDTO>(); //get
                cfg.CreateMap<ClaseDTO, Clase>(); //post, put


                cfg.CreateMap<Asistencia, AsistenciaDTO>(); //get
                cfg.CreateMap<AsistenciaDTO, Asistencia>(); //post, put

            });
        }
    }
}
