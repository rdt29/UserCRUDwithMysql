namespace UserTrailWithMysql.Entites
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int Roleid { get; set; }

        public Role role { get; set; }
        public Account account { get; set; }
    }
}