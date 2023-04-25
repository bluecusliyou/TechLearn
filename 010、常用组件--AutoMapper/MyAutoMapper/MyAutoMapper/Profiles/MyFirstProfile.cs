using AutoMapper;

namespace MyAutoMapper.Profiles
{
    public  class MyFirstProfile: Profile
    {
        public MyFirstProfile()
        {
            //在某个Profile生效
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<Src01, Dest01>();
        }
    }
}
