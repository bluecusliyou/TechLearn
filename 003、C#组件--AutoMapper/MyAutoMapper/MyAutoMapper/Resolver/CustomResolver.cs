using AutoMapper;

namespace MyAutoMapper
{	
	public class CustomResolver : IValueResolver<SrcResolver, DestResolver, string>
	{
        public string Resolve(SrcResolver source, DestResolver destination, string destMember, ResolutionContext context)
        {			
			return $"{source.Name}--{source.Age}";
		}
    }
}
