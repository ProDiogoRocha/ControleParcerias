using AutoMapper;
using System.Collections.Generic;

namespace ControleDeParcerias.Web.Mappers
{
    public abstract class MapperProfile<K, V>
    {
        public MapperProfile()
        {
            MapperConfig = Mapper.CreateMapper();
        }

        public IMapper MapperConfig { get; set; }
        public virtual MapperConfiguration Mapper => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<K, V>();
            cfg.CreateMap<V, K>();
        });

        public virtual List<V> EntityToViewModel(IList<K> Ks)
        {
            List<V> Vs = new List<V>();
            foreach (K k in Ks)
            {
                Vs.Add(MapperConfig.Map<K, V>(k));
            }
            return Vs;
        }

        public virtual List<K> ViewModelToEntity(IList<V> Vs)
        {
            List<K> Ks = new List<K>();
            foreach (V v in Vs)
            {
                Ks.Add(MapperConfig.Map<V, K>(v));
            }
            return Ks;
        }
    }
}