using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{

    public class ProfileUserConfiguration : EntityBaseConfiguration<ProfileUser>
    {
        public ProfileUserConfiguration()
        {
            Property(ur => ur.UserId).IsRequired();
        }
    }
}
