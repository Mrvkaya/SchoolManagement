using static SchoolManagement.ENTITIES.BaseEntities;

namespace SchoolManagement.DAL
{
    public class Login
    {
        // Kullanıcıya ait veri erişim işlemini yömneten repository sınıfımız
        public class UserRepository
        {
            private List<User> users = new() // Sistemde kayıtlı kullanıcılar geçici tutulduğu listemiz. Şimdilik sahte bir data kullandım ileride veritabanı ile değiştireceğim.
    {
        new User { Id=1, Username="ogrenci1", Password="123", Role=UserRole.Student },
        new User { Id=2, Username="ogretmen1", Password="123", Role=UserRole.Teacher },
        new User { Id=3, Username="admin", Password="123", Role=UserRole.Admin }
    };

            public User GetUser(string username, string password) // Kullanıcı adı ve şifreye göre kullanıcıyı döndüren metodumuz.
            {
                return users.FirstOrDefault(x =>
                    x.Username == username && x.Password == password);
            }
        }
    }
}
