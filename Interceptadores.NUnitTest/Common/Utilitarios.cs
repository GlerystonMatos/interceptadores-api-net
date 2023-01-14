using AutoMapper;
using Interceptadores.Service.AutoMapper;

namespace Interceptadores.NUnitTest.Common
{
    public class Utilitarios
    {
        public static IMapper GetMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
            return mapperConfiguration.CreateMapper();
        }
    }
}